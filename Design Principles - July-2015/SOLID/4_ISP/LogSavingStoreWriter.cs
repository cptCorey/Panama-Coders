// Temporary Solution

public class LogSavingStoreWriter: IStoreWriter
{
	public void Save(int id, string message)
	{
		Log.Information("Save message {id}", id);
	}
}

public class LogSavedStoreWriter: IStoreWriter
{
	public void Save(int id, string message)
	{
		Log.Information("Saved message {id}", id);
	}
}