public class MessageStore
{
	private readonly StoreLogger log;
	private readonly StoreCache cache;
	private readonly FileStore fileStore;
	
	// Constructor
	public FileStore(string workingDirectory) // Make it a requirement
	{
		if (workingDirectory == null)
			throw new ArgumentNullException("workingDirectory");
			
		if(!Directory.Exists(workingDirectory)))
			throw new ArgumentException("Invalid working directory, directory does not exist!","workingDirectory");
					
		this.WorkingDirectory = workingDirectory;
		this.log = new StoreLogger();
		this.cache = new StoreCache();
		this.fileStore = new FileStore();
	}
	
	public string WorkingDirectory { get; private set; }
	
	public void Save(int id, string message)
	{
		this.Log.Saving(id);
		var file = this.GetFileName(id);
		this.Store.WriteAllText(file, message);
		this.Cache.AddOrUpdate(id, message);
		this.Log.Saved(id);
	}

	public Maybe<string> Read(int id)
	{
		this.Log.Reading(id);
		var file = this.GetFileInfo(id);
		if(!file.Exists)
		{
			this.Log.DidNotFind(id);
			return new Maybe<string>();
		}		
		var message = this.Cache.GetOrAdd(id, _ => File.ReadAllText(file.FullName));
		this.Log.Returning(id);
		return new Maybe<string>(message);
	}
	
	public FileInfo GetFileInfo(int id)
	{
		return this.Store.GetFileInfo(id, this.WorkingDirectory.FullName);
	}
	
	protected virtual FileStore Store
	{
		get { return this.fileStore; }
	}
	
	protected virtual StoreCache Cache
	{
		get { return this.cache; }
	}
	
	protected virtual StoreLogger Log
	{
		get { return this.log; }
	}
}