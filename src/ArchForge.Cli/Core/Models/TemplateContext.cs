namespace ArchForge.Core.Models;

/// <summary>
/// Contexto utilizado durante a geração de um template.
/// Contém informações como nome do projeto, template escolhido e diretório de saída.
/// </summary>
public class TemplateContext
{
	public string Name { get; init; } = default!;
	public string TemplateName { get; init; } = "minimal-api";
	public string OutputPath { get; init; } = Directory.GetCurrentDirectory();
}