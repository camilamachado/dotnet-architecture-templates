using ArchForge.Core.Models;

namespace ArchForge.Core.Abstractions;

public interface ITemplateEngine
{
	/// <summary>
	/// Gera um novo projeto a partir do contexto informado, copiando o template base
	/// e aplicando substituição de tokens e renomeação de estrutura.
	/// </summary>
	/// <param name="context">Contexto contendo nome do projeto, template e diretório de saída.</param>
	/// <param name="cancellationToken">Token para cancelamento da operação.</param>
	Task GenerateAsync(TemplateContext context, CancellationToken cancellationToken);
}