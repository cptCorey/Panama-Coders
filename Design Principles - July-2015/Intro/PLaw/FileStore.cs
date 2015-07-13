public class FileStore
{
	public string WorkingDirectory { get; set; }
	
	public void Save(int id, string message)
	{
		var path = GetFileName(id);
		File.WriteAllText(path, message);
	}

	public string Read(int id)
	{
		var path = GetFileName(id);
		var msg = File.ReadAllText(path);
		return msg;
	}
	
	public string GetFileName(int id)
	{
		return Path.Combine(this.WorkingDirectory, id + ".txt");
	}
}
