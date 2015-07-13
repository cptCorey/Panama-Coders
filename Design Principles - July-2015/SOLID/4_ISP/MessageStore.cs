public class MessageStore
{
	private readonly ConcurrentDictionary<int, string> cache;
	private readonly IStoreLogger log;
	private readonly IStoreCache cache;
	private readonly IStore fileStore;
	private readonly IFileLocator fileLocator;
	
	
	// Constructor
	public MessageStore(DirectoryInfo workingDirectory) // Make it a requirement
	{		
		this.WorkingDirectory = workingDirectory;
		this.log = new StoreLogger();
		this.cache = new StoreCache();
		var f = new FileStore(WorkingDirectory);
		this.fileStore = f;
		this.fileLocator = f; 
	}
	
	public DirectoryInfo WorkingDirectory { get; private set; }

	public void Save(int id, string message)
	{
		new LogSavingStoreWriter().Save(id, message);
		this.Store.Save(id, message);
		this.Cache.Save(id, message);
		new LogSavedStoreWriter().Save(id, message);
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
	
	public FileInfo GetFileInfo(int id)
	{
		return this.FileLocator.GetFileInfo(id, this.WorkingDirectory.FullName);
	}
	
	protected virtual IStore Store
	{
		get { return this.fileStore; }
	}
	
	protected virtual IStoreCache Cache
	{
		get { return this.cache; }
	}
	
	protected virtual IStoreLogger Log
	{
		get { return this.log; }
	}
	
	protected virtual IFileLocator FileLocator
	{
		get { return this.fileLocator; }
	}
}