using System.Text;
using ArchForge.Core.Abstractions;
using ArchForge.Core.Models;
using ArchForge.Templates;

namespace ArchForge.Core.Services;

/// <summary>
/// Implementação responsável por gerar projetos a partir de templates.
/// </summary>
public sealed class TemplateEngine(IFileSystemService fileSystem) : ITemplateEngine
{
	private const string Placeholder = "MeuProjeto";

	private readonly IFileSystemService _fileSystem = fileSystem;

	private static readonly HashSet<string> IgnoredDirectories =
	[
		".git",
		".vs",
		"bin",
		"obj"
	];

	private static readonly HashSet<string> IgnoredFileExtensions =
	[
		".lock",
		".suo",
		".user",
		".userosscache"
	];

	/// <summary>
	/// Gera um novo projeto a partir de um template, realizando a cópia da estrutura, substituição de tokens e renomeação de arquivos e diretórios.
	/// </summary>
	public async Task GenerateAsync(TemplateContext context, CancellationToken cancellationToken)
	{
		var templateDirectory = TemplateLocator.Get(context.TemplateName);

		var targetDirectory = Path.Combine(context.OutputPath, context.Name);

		EnsureTargetDirectoryDoesNotExist(targetDirectory);

		_fileSystem.CopyDirectory(templateDirectory, targetDirectory);

		await ReplaceTokensAsync(targetDirectory, context.Name, cancellationToken);

		RenameDirectories(targetDirectory, context.Name);
		RenameFiles(targetDirectory, context.Name);
	}

	/// <summary>
	/// Garante que o diretório de destino ainda não exista antes da geração do projeto.
	/// </summary>
	private void EnsureTargetDirectoryDoesNotExist(string path)
	{
		if (_fileSystem.Exists(path))
		{
			throw new InvalidOperationException($"The directory '{path}' already exists.");
		}
	}

	/// <summary>
	/// Percorre todos os arquivos do projeto gerado substituindo os tokens definidos pelo nome informado para o novo serviço.
	/// </summary>
	private async Task ReplaceTokensAsync(string rootPath, string serviceName, CancellationToken cancellationToken)
	{
		var replacements = BuildReplacements(serviceName);

		foreach (var file in Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories))
		{
			if (ShouldIgnoreFile(file))
			{
				continue;
			}

			try
			{
				var content = await File.ReadAllTextAsync(file, Encoding.UTF8, cancellationToken);

				var updatedContent = ApplyReplacements(content, replacements);

				if (content != updatedContent)
				{
					await File.WriteAllTextAsync(file, updatedContent, cancellationToken);
				}
			}
			catch (IOException)
			{
			}
			catch (UnauthorizedAccessException)
			{
			}
		}
	}

	/// <summary>
	/// Aplica todas as substituições configuradas em um conteúdo textual.
	/// </summary>
	private static string ApplyReplacements(string content, IReadOnlyDictionary<string, string> replacements)
	{
		foreach (var (token, value) in replacements)
		{
			content = content.Replace(token, value, StringComparison.Ordinal);
		}

		return content;
	}

	/// <summary>
	/// Renomeia todos os diretórios que contenham o placeholder padrão utilizado pelo template.
	/// </summary>
	private void RenameDirectories(string rootPath, string serviceName)
	{
		var directories = Directory
			.GetDirectories(rootPath, "*", SearchOption.AllDirectories)
			.OrderByDescending(x => x.Length)
			.ToList();

		foreach (var directory in directories)
		{
			if (ShouldIgnoreDirectory(directory))
			{
				continue;
			}

			RenamePath(directory, serviceName, isDirectory: true);
		}
	}

	/// <summary>
	/// Renomeia todos os arquivos que contenham o placeholder padrão utilizado pelo template.
	/// </summary>
	private void RenameFiles(string rootPath, string serviceName)
	{
		var files = Directory
			.GetFiles(rootPath, "*", SearchOption.AllDirectories)
			.ToList();

		foreach (var file in files)
		{
			if (ShouldIgnoreFile(file))
			{
				continue;
			}

			RenamePath(file, serviceName, isDirectory: false);
		}
	}

	/// <summary>
	/// Renomeia um arquivo ou diretório substituindo o placeholder padrão pelo nome do serviço informado.
	/// </summary>
	private void RenamePath(string path, string serviceName, bool isDirectory)
	{
		if (!path.Contains(Placeholder, StringComparison.Ordinal))
		{
			return;
		}

		var newPath = path.Replace(Placeholder, serviceName, StringComparison.Ordinal);

		try
		{
			if (isDirectory)
			{
				if (Directory.Exists(path) &&
					!Directory.Exists(newPath))
				{
					Directory.Move(path, newPath);
				}

				return;
			}

			if (File.Exists(path) &&
				!File.Exists(newPath))
			{
				File.Move(path, newPath);
			}
		}
		catch
		{
			// Ignora conflitos de IO.
		}
	}

	/// <summary>
	/// Verifica se um diretório deve ser ignorado durante o processamento.
	/// </summary>
	private static bool ShouldIgnoreDirectory(string path)
	{
		var directoryName = Path.GetFileName(path);

		return IgnoredDirectories.Contains(directoryName);
	}

	/// <summary>
	/// Verifica se um arquivo deve ser ignorado durante o processamento.
	/// </summary>
	private static bool ShouldIgnoreFile(string path)
	{
		var extension = Path.GetExtension(path);

		return IgnoredFileExtensions.Contains(extension);
	}

	/// <summary>
	/// Constrói o conjunto de tokens e valores utilizados durante a geração do projeto para substituir referências ao template base.
	/// </summary>
	private static IReadOnlyDictionary<string, string> BuildReplacements(string serviceName)
	{
		var serviceNameLower = serviceName.ToLowerInvariant();

		return new Dictionary<string, string>
		{
			["MeuProjeto"] = serviceName,
			["meuprojeto"] = serviceNameLower,
			["meu-projeto"] = ToKebabCase(serviceName),

			["MeuProjeto.Api"] = $"{serviceName}.Api",
			["meuprojeto-api"] = $"{serviceNameLower}-api",
			["meuprojeto-db"] = $"{serviceNameLower}-db"
		};
	}

	/// <summary>
	/// Converte um texto em formato PascalCase ou camelCase para kebab-case.
	/// </summary>
	private static string ToKebabCase(string value)
	{
		return string.Concat(
			value.Select((character, index) =>
				index > 0 && char.IsUpper(character)
					? $"-{character}"
					: character.ToString()))
			.ToLowerInvariant();
	}
}