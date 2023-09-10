namespace GOAP
{
	public interface IWriteBoard<TKey, TValue> : IBoard<TKey, TValue>
	{
		new TValue this[TKey key] { get; set; }
	}
}