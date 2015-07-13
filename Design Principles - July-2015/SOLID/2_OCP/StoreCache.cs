public class StoreCache
{
	private readonly ConcurrentDictionary<int, string> cache;
	
	public StoreCache()
	{
		this.cache = new ConcurrentDictionary<int, string>();
	}
	
	public virtual void AddOrUpdate(int id, string message)
	{
		this.cache.AddOrUpdate(id, message, (i, s) => message);
	}
	
	public virtual string GetOrAdd(int id, Func<int, string> messageFactory)
	{
		return this.cache.GetOrAdd(id, messageFactory);
	}
}