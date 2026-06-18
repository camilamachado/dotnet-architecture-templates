using ArchForge.Templates;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArchForge.Commands;

/// <summary>
/// Command responsável por listar os templates disponíveis
/// </summary>
public sealed class TemplatesCommand : Command
{
	protected override int Execute(CommandContext context, CancellationToken cancellationToken)
	{
		var table = new Table();

		table.Border(TableBorder.Rounded);

		table.AddColumn("[yellow]Template[/]");
		table.AddColumn("[yellow]Descrição[/]");

		foreach (var template in TemplateCatalog.Available)
		{
			table.AddRow(
				template.Name,
				template.Description);
		}

		AnsiConsole.Write(table);

		return 0;
	}
}