public interface IStore
{
	void Save(int id, string message)
		
	Maybe<string> ReadAllText(int id)
}