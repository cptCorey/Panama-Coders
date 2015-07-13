public class FileStore
{
	// Constructor
	public FileStore(string workingDirectory) // Make it a requirement
	{
		if (workingDirectory == null)
			throw new ArgumentNullException("workingDirectory");
			
		if(!Directory.Exists(workingDirectory)))
			throw new ArgumentException("Invalid working directory, directory does not exist!","workingDirectory");
					
		this.WorkingDirectory = workingDirectory;
	}
	
	public string WorkingDirectory { get; private set; }
	
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