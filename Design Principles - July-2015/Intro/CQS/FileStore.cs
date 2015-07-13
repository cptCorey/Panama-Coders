public class FileStore
{
	public string WorkingDirectory { get; private set; }

	public FileStore(string workingDirectory)
	{
		if (workingDirectory == null)
			throw new ArgumentNullException("workingDirectory");
			
		if(!Directory.Exists(workingDirectory)))
			throw new ArgumentException("Invalid working directory, directory does not exist!","workingDirectory");
					
		
		this.WorkingDirectory = workingDirectory;
	}
	
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

var store = new FileStore(null);
store.Save(1, "Mi mensaje!");






