public class SqlStore: IStore, IStoreWriter, IStoreReader
{
	public void Save(int id, string message)
	{
		// Write to database here
	}
	
	public Maybe<string> Read(int id)
	{
		// Read to database here
	}
}