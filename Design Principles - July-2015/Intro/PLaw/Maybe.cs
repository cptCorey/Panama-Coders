public class Maybe<T>: IEnumerable<T>
{	
	private readonly IEnumerable<T> values;
	
	public Maybe()
	{
		this.values = new T[0];
	}
	
	public Maybe(T value)
	{
		this.values = new[] { value };
	}
	
	public IEnumerable<T> GetEnumerator()
	{
		return this.values.GetEnumerator();
	}
	
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}