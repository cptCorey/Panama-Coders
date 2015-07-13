public class FileStore
{
	public void WriteAllText(string path, string message)
	{
		File.WriteAllText(file, message);
	}
	
	public string ReadAllText(string path)
	{
		return File.ReadAllText(file.FullName);
	}
	
	public FileInfo GetFileInfo(int id, string workingDirectory)
	{
		var path = Path.Combine(workingDirectory, id + ".txt");
		return new FileInfo(path);
	}
}