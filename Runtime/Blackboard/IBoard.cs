using System;

namespace GOAP
{
	public interface IBoard<TKey, TValue> : IEquatable<IBoard<TKey, TValue>>
	{
		TValue this[TKey key] { get; }
		
		IWriteBoard<TKey, TValue> CloneAsWriteable();
	}
}