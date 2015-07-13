public class StoreLogger: IStoreLogger, IStoreWriter, IStoreReader
{
	private readonly IStoreWriter writer;
	private readonly IStoreReader reader;
	
	public StoreLogger(IStoreWriter writer, IStoreReader reader)
	{
		this.writer = writer;
		this.reader = reader;
	}
	
	public Save(int id, string message)
	{
		Log.Information("Saving message {id}.", id);
		this.writer.Saved(id, message);
		Log.Information("Saved message {id}.", id);
	}
	
	public Maybe<string> Read(int id)
	{
		Log.Debug("Reading message {id}", id);
		var retVal = this.reader.Read(id);
		if (retVal.Any())
			Log.Debug("Returning message {id}.", id);
		else
			Log.Debug("No message {id} found.", id);
		return retVal;			
	}
	
	public void Saving(int id)
	{
		Log.Information("Saving message {id}.", id);
	}
	
	public void Saved(int id)
	{
		Log.Information("Saved message {id}.", id);
	}
	
	public void Reading(int id)
	{
		Log.Debug("Reading message {id}", id);
	}
	
	public void DidNotFind(int id)
	{
		Log.Debug("No message {id} found.", id);
	}
	
	public void Returning(int id)
	{
		Log.Debug("Returning message {id}.", id);
	}
}