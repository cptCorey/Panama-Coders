public interface IStore, IStoreWriter, IStoreReader
{
	void Save(int id, string message)
		
	Maybe<string> Read(int id)
}