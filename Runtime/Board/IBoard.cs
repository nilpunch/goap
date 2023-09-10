using System;
using System.Diagnostics.Contracts;

namespace GOAP
{
	public interface IBoard<TKey, TValue> : IEquatable<IBoard<TKey, TValue>>
	{
		TValue this[TKey key] { get; }
		
		[Pure]
		IWriteBoard<TKey, TValue> CloneAsWriteable();
	}
}