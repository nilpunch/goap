using System;

namespace GOAP
{
	public readonly struct PropertyId : IEquatable<PropertyId>, IComparable<PropertyId>
	{
		public PropertyId(int id)
		{
			Id = id;
		}

		public static PropertyId Unique()
		{
			return new PropertyId(Guid.NewGuid().GetHashCode());
		}

		public int Id { get; }

		public bool Equals(PropertyId other)
		{
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			return obj is PropertyId other && Equals(other);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public int CompareTo(PropertyId other)
		{
			return Id.CompareTo(other.Id);
		}
	}
}