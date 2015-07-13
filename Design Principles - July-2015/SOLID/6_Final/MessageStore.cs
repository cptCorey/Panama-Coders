public class MessageStore
{
	private readonly IFileLocator fileLocator;
	private readonly IStoreWriter writer;
	private readonly IStoreReader reader;
	
	
	// Constructor
	public MessageStore(IStoreWriter writer,
							IStoreReader reader,
							IFileLocator fileLocator) // Make it a requirement
	{		
		if (writer == null)
			throw new ArgumentNullException("Writer");
		if (reader == null)
			throw new ArgumentNullException("Reader");
		if (fileLocator == null)
			throw new ArgumentNullException("FileLocator");
			
		this.fileLocator = fileLocator;
		this.writer = writer;
		this.reader = reader;
	}
	
	public void Save(int id, string message)
	{
		this.writer.Save(id, message);
	}

	public Maybe<string> Read(int id)
	{
		return this.Reader.Read(id);
	}
	
	public FileInfo GetFileInfo(int id)
	{
		return this.FileLocator.GetFileInfo(id);
	}
}