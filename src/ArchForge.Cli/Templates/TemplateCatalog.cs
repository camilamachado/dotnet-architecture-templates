namespace ArchForge.Templates;

/// <summary>
/// Catálogo centralizado de templates suportados pelo ArchForge.
/// Responsável por disponibilizar metadados, validação e consulta dos templates que podem ser utilizados na geração de projetos.
/// </summary>
public static class TemplateCatalog
{
	public static readonly TemplateDefinition MinimalApi = new(
		"minimal-api",
		"Minimal API com arquitetura em camadas, CQRS, validações, testes unitários e integração."
	);

	public static readonly TemplateDefinition MinimalApiWorker = new(
		"minimal-api-worker",
		"Minimal API com Worker Service para processamento assíncrono em background."
	);

	public static readonly IReadOnlyCollection<TemplateDefinition> Available =
	[
		MinimalApi,
		MinimalApiWorker
	];

	public static bool Exists(string templateName)
	{
		return Available.Any(x =>
			x.Name.Equals(templateName, StringComparison.OrdinalIgnoreCase));
	}

	public static TemplateDefinition Get(string templateName)
	{
		return Available.FirstOrDefault(x =>
			x.Name.Equals(templateName, StringComparison.OrdinalIgnoreCase))
			?? throw new InvalidOperationException(
				$"Template '{templateName}' não encontrado.");
	}
}
