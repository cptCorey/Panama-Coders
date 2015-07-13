public class FileStore
{
	public virtual void WriteAllText(string path, string message)
	{
		File.WriteAllText(file, message);
	}
	
	public virtual string ReadAllText(string path)
	{
		return File.ReadAllText(file.FullName);
	}
	
	public virtual FileInfo GetFileInfo(int id, string workingDirectory)
	{
		var path = Path.Combine(workingDirectory, id + ".txt");
		return new FileInfo(path);
	}
}