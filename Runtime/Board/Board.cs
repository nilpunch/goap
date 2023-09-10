using System;
using System.Collections.Generic;

namespace GOAP
{
	public class Board<TKey, TValue> : IWriteBoard<TKey, TValue>
		where TKey : IComparable<TKey>
		where TValue : IEquatable<TValue>
	{
		private readonly SortedList<TKey, TValue> _data;

		public Board()
		{
			_data = new SortedList<TKey, TValue>();
		}

		private Board(SortedList<TKey, TValue> data)
		{
			_data = data;
		}
		
		public TValue this[TKey key]
		{
			get => _data[key];
			set => _data[key] = value;
		}

		public IWriteBoard<TKey, TValue> CloneAsWriteable()
		{
			return new Board<TKey, TValue>(new SortedList<TKey, TValue>(_data));
		}

		public bool Equals(IBoard<TKey, TValue> other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return ListEquals(_data, ((Board<TKey, TValue>)other)._data);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != this.GetType())
				return false;
			return Equals((Board<TKey, TValue>)obj);
		}

		public override int GetHashCode()
		{
			return ListHashCode(_data);
		}

		private static bool ListEquals(SortedList<TKey, TValue> a, SortedList<TKey, TValue> b)
		{
			if (a.Count != b.Count)
			{
				return false;
			}

			var aValues = a.Values;
			var aKeys = a.Keys;
			var bValues = b.Values;
			var bKeys = b.Keys;
			for (var i = 0; i < a.Count; i++)
			{
				if (!aValues[i].Equals(bValues[i]) || !aKeys[i].Equals(bKeys[i]))
				{
					return false;
				}
			}

			return true;
		}
		
		private static int ListHashCode(SortedList<TKey, TValue> list)
		{
			var hash = 0;

			var values = list.Values;
			var keys = list.Keys;
			for (var i = 0; i < list.Count; i++)
			{
				hash ^= HashCode.Combine(values[i], keys[i]);
			}

			return hash;
		}
	}
}