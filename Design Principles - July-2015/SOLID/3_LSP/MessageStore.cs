public class MessageStore
{
	private readonly ConcurrentDictionary<int, string> cache;
	private readonly StoreLogger log;
	private readonly StoreCache cache;
	private readonly IStore fileStore;
	
	// Constructor
	public MessageStore(DirectoryInfo workingDirectory) // Make it a requirement
	{		
		this.WorkingDirectory = workingDirectory;
		this.log = new StoreLogger();
		this.cache = new StoreCache();
		this.fileStore = new FileStore(WorkingDirectory);
	}
	
	public DirectoryInfo WorkingDirectory { get; private set; }

	public void Save(int id, string message)
	{
		this.Log.Saving(id);
		this.Store.WriteAllText(id, message);
		this.Cache.AddOrUpdate(id, message);
		this.Log.Saved(id);
	}

	public Maybe<string> Read(int id)
	{
		this.Log.Reading(id);
		var message = this.Cache.GetOrAdd(id, _ => File.ReadAllText(id));
		if (message.any())
			this.Log.Returning(id);
		else
			this.Log.DidNotFind(id);	
		return message;
	}
	
	//public FileInfo GetFileInfo(int id)
	//{
	//	return this.Store.GetFileInfo(id, this.WorkingDirectory.FullName);
	//}
	
	protected virtual IStore Store
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