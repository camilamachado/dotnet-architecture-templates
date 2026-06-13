namespace ArchForge.Templates;

/// <summary>
/// Responsável por localizar templates disponíveis no sistema de arquivos.
/// </summary>
public static class TemplateLocator
{
	public static string Get(string templateName)
	{
		var path = Path.Combine(AppContext.BaseDirectory, "templates", templateName);

		if (!Directory.Exists(path))
		{
			throw new DirectoryNotFoundException($"Template '{templateName}' não encontrado.");
		}

		return path;
	}
}