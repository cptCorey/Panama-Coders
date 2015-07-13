public class StoreCache: IStoreCache, IStoreWriter
{
	private readonly ConcurrentDictionary<int, Maybe<string>> cache;
	
	public StoreCache()
	{
		this.cache = new ConcurrentDictionary<int, string>();
	}
	
	public virtual void Save(int id, string message)
	{
		this.cache.AddOrUpdate(id, message, (i, s) => message);
	}
	
	public virtual Maybe<string> GetOrAdd(int id, Func<int, Maybe<string>> messageFactory)
	{
		return this.cache.GetOrAdd(id, messageFactory);
	}
}