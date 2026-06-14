using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace ArchForge.Infrastructure.Spectre;

/// <summary>
/// Adaptador entre o contêiner de injeção de dependência do <see cref="Microsoft.Extensions.DependencyInjection"/> 
/// e o mecanismo de resolução de tipos utilizado pelo Spectre.Console.Cli.
/// </summary>
public sealed class TypeRegistrar(IServiceCollection services) : ITypeRegistrar
{
	private readonly IServiceCollection _services = services;

	public ITypeResolver Build()
		=> new TypeResolver(_services.BuildServiceProvider());

	public void Register(Type service, Type implementation)
		=> _services.AddSingleton(service, implementation);

	public void RegisterInstance(Type service, object implementation)
		=> _services.AddSingleton(service, implementation);

	public void RegisterLazy(Type service, Func<object> factory)
		=> _services.AddSingleton(service, _ => factory());
}