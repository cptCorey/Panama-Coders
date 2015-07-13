public class StoreLogger
{
	public virtual void Saving(int id)
	{
		Log.Information("Saving message {id}.", id);
	}
	
	public virtual void Saved(int id)
	{
		Log.Information("Saved message {id}.", id);
	}
	
	public virtual void Reading(int id)
	{
		Log.Debug("Reading message {id}", id);
	}
	
	public virtual void DidNotFind(int id)
	{
		Log.Debug("No message {id} found.", id);
	}
	
	public virtual void Returning(int id)
	{
		Log.Debug("Returning message {id}.", id);
	}
}