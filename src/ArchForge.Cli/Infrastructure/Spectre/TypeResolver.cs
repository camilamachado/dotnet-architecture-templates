using Spectre.Console.Cli;

namespace ArchForge.Infrastructure.Spectre;

/// <summary>
/// Implementação de <see cref="ITypeResolver"/> baseada em <see cref="IServiceProvider"/>,
/// responsável por resolver dependências registradas no contêiner durante a execução dos comandos.
/// </summary>
public sealed class TypeResolver(IServiceProvider provider) : ITypeResolver, IDisposable
{
	private readonly IServiceProvider _provider = provider;

	public object? Resolve(Type? type)
		=> type == null ? null : _provider.GetService(type);

	public void Dispose()
	{
		if (_provider is IDisposable d)
			d.Dispose();
	}
}