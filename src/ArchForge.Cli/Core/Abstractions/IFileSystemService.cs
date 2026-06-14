namespace ArchForge.Core.Abstractions;

public interface IFileSystemService
{
	/// <summary>
	/// Verifica se o caminho informado existe no sistema de arquivos.
	/// </summary>
	/// <param name="path">Caminho a ser verificado.</param>
	/// <returns>True se o caminho existir; caso contrário, false.</returns>
	bool Exists(string path);

	/// <summary>
	/// Copia recursivamente um diretório de origem para um diretório de destino.
	/// </summary>
	/// <param name="source">Diretório de origem do template.</param>
	/// <param name="target">Diretório de destino onde o projeto será gerado.</param>
	void CopyDirectory(string source, string target);
}
