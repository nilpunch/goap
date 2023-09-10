using System;

namespace GOAP.Test.MultiData
{
	public class WorldState : IEquatable<WorldState>
	{
		public WorldState(IBoard<PropertyId, bool> boolBoard, IBoard<PropertyId, int> intBoard)
		{
			BoolBoard = boolBoard;
			IntBoard = intBoard;
		}

		public IBoard<PropertyId, bool> BoolBoard { get; }

		public IBoard<PropertyId, int> IntBoard { get; }

		public bool Equals(WorldState other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return Equals(BoolBoard, other.BoolBoard) && Equals(IntBoard, other.IntBoard);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != this.GetType())
				return false;
			return Equals((WorldState)obj);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(BoolBoard, IntBoard);
		}
	}
}