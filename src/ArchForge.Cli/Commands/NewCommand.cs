using ArchForge.Core.Abstractions;
using ArchForge.Core.Models;
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
		[CommandArgument(0, "<name>")]
		public string Name { get; set; } = string.Empty;
	}

	protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
	{
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
						Name = settings.Name
					}, cancellationToken).GetAwaiter().GetResult();
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