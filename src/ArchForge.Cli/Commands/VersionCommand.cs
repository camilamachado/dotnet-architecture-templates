using System.Reflection;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArchForge.Commands;

/// <summary>
/// Exibe a versão atual da CLI.
/// </summary>
public sealed class VersionCommand : Command
{
	protected override int Execute(CommandContext context, CancellationToken cancellationToken)
	{
		var informationalVersion = Assembly
			.GetExecutingAssembly()
			.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
			?.InformationalVersion;

		var version = informationalVersion?.Split('+', StringSplitOptions.RemoveEmptyEntries)[0] ?? "desconhecida";

		AnsiConsole.MarkupLine($"[green]ArchForge[/] versão [yellow]{version}[/]");

		return 0;
	}
}