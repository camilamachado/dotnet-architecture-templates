using ArchForge.Core.Abstractions;
using ArchForge.Core.Models;
using ArchForge.Templates;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArchForge.Commands;

/// <summary>
/// Command responsável por gerar um novo projeto a partir de um template.
/// Orquestra a execução do <see cref="ITemplateEngine"/> e fornece feedback no terminal.
/// </summary>
public class NewCommand(ITemplateEngine engine) : Command<NewCommand.Settings>
{
	private readonly ITemplateEngine _engine = engine;

	public class Settings : CommandSettings
	{
		[CommandArgument(0, "<template>")]
		public string Template { get; set; } = string.Empty;

		[CommandArgument(1, "<name>")]
		public string Name { get; set; } = string.Empty;
	}

	protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
	{
		if (string.IsNullOrWhiteSpace(settings.Template))
		{
			AnsiConsole.MarkupLine("[red]Você deve informar o template.[/]");
			return -1;
		}

		if (!TemplateCatalog.Exists(settings.Template))
		{
			AnsiConsole.MarkupLine($"[red]Template '{settings.Template}' não encontrado.[/]");

			AnsiConsole.MarkupLine("[yellow]Execute 'arch-forge templates' para visualizar os templates disponíveis.[/]");

			return -1;
		}

		if (string.IsNullOrWhiteSpace(settings.Name))
		{
			AnsiConsole.MarkupLine("[red]Você deve informar o nome do serviço.[/]");
			return -1;
		}

		try
		{
			AnsiConsole.Status()
				.Start("Gerando projeto...", ctx =>
				{
					_engine.GenerateAsync(new TemplateContext
					{
						Name = settings.Name,
						TemplateName = settings.Template
					}, cancellationToken);
				});

			AnsiConsole.MarkupLine("[green]Projeto criado com sucesso![/]");
			return 0;
		}
		catch (Exception ex)
		{
			AnsiConsole.WriteException(ex);
			return -1;
		}
	}
}