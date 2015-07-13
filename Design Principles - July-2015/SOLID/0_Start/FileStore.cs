public class FileStore
{
	private readonly ConcurrentDictionary<int, string> cache;
	
	// Constructor
	public FileStore(string workingDirectory) // Make it a requirement
	{
		if (workingDirectory == null)
			throw new ArgumentNullException("workingDirectory");
			
		if(!Directory.Exists(workingDirectory)))
			throw new ArgumentException("Invalid working directory, directory does not exist!","workingDirectory");
					
		this.WorkingDirectory = workingDirectory;
		this.cache = new ConcurrentDictionary<int, string>();
	}
	
	public string WorkingDirectory { get; private set; }
	
	public void Save(int id, string message)
	{
		Log.Information("Saving message {id}.", id);
		var file = this.GetFileName(id);
		File.WriteAllText(file, message);
		this.cache.AddOrUpdate(id, message, (i, s) => message);
		Log.Information("Saved message {id}.", id);
	}

	public Maybe<string> Read(int id)
	{
		Log.Debug("Reading message {id}", id);
		var file = this.GetFileInfo(id);
		if(!file.Exists)
		{
			Log.Debug("No message {id} found.", id);
			return new Maybe<string>();
		}
		
		var message = this.cache.GetOrAdd(id, _ => File.ReadAllText(file.FullName));
		Log.Debug("Returning message {id}.", id);
		return new Maybe<string>(message);
	}
	
	public FileInfo GetFileInfo(int id)
	{
		var path = Path.Combine(this.WorkingDirectory, id + ".txt");
		return new FileInfo(path);
	}
}




// Areas of Concern

// Logging
// Caching
// Storage
// Orchestration