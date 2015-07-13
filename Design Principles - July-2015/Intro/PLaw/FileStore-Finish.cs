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
		var file = this.GetFileName(id);
		File.WriteAllText(file, message);
	}

	public Maybe<string> Read(int id)
	{
		var file = this.GetFileName(id);
		if(!file.Exists)
			return new Maybe<string>();
		
		var message = File.ReadAllText(file);
		return new Maybe<string>(message);
	}
	
	public string GetFileName(int id)
	{
		return Path.Combine(this.WorkingDirectory, id + ".txt");
	}
}