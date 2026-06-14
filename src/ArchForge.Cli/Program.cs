using ArchForge.Commands;
using ArchForge.Core.Abstractions;
using ArchForge.Core.Services;
using ArchForge.Infrastructure.FileSystem;
using ArchForge.Infrastructure.Spectre;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

var services = new ServiceCollection();

services.AddSingleton<IFileSystemService, FileSystemService>();
services.AddSingleton<ITemplateEngine, TemplateEngine>();

var registrar = new TypeRegistrar(services);

var app = new CommandApp(registrar);

app.Configure(config =>
{
	config.SetApplicationName("arch-forge");

	config.AddCommand<NewCommand>("new").WithDescription("Cria um novo projeto a partir de um template.");

	config.AddCommand<VersionCommand>("version").WithDescription("Exibe a versão instalada do ArchForge.");
});

return app.Run(args);