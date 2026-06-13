using ArchForge.Core.Abstractions;

namespace ArchForge.Infrastructure.FileSystem;

public class FileSystemService : IFileSystemService
{
	public bool Exists(string path) => Directory.Exists(path);

	public void CopyDirectory(string source, string target)
	{
		Directory.CreateDirectory(target);

		foreach (var file in Directory.GetFiles(source, "*", SearchOption.AllDirectories))
		{
			var relative = Path.GetRelativePath(source, file);
			var dest = Path.Combine(target, relative);

			Directory.CreateDirectory(Path.GetDirectoryName(dest)!);
			File.Copy(file, dest, true);
		}
	}
}