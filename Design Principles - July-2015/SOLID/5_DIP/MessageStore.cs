public class MessageStore
{
	private readonly IStoreLogger log;
	private readonly IStoreCache cache;
	private readonly IStore store;
	private readonly IFileLocator fileLocator;
	private readonly IStoreWriter writer;
	private readonly IStoreReader reader;
	
	
	// Constructor
	public MessageStore(DirectoryInfo workingDirectory) // Make it a requirement
	{		
		this.WorkingDirectory = workingDirectory;
		var fileStore = new FileStore(WorkingDirectory); 
		var c = new StoreCache(fileStore, fileStore);
		this.cache = c;
		var l = new StoreLogger(c, c);
		this.log = l;
		this.store = fileStore;
		this.fileLocator = fileStore;		
		this.writer = l;
		this.reader = l;
	}
	
	public DirectoryInfo WorkingDirectory { get; private set; }

	public void Save(int id, string message)
	{
		this.Writer.Save(id, message);
	}

	public Maybe<string> Read(int id)
	{
		return this.Reader.Read(id);
	}
	
	public FileInfo GetFileInfo(int id)
	{
		return this.FileLocator.GetFileInfo(id, this.WorkingDirectory.FullName);
	}
	
	protected virtual IStore Store
	{
		get { return this.store; }
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
	
	protected virtual IStoreWriter Writer
	{
		get { return this.writer; }
	}
	
	protected virtual IStoreReader Reader
	{
		get { return this.reader; }
	}
}