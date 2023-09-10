using System;

namespace GOAP.Test.Movement
{
	public class WorldState : IEquatable<WorldState>
	{
		public WorldState(BotState bot, IBoard<PropertyId, InterestState> interests)
		{
			Bot = bot;
			Interests = interests;
		}

		public BotState Bot { get; }

		public IBoard<PropertyId, InterestState> Interests { get; }

		public bool Equals(WorldState other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return Bot.Equals(other.Bot) && Equals(Interests, other.Interests);
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
			return HashCode.Combine(Bot, Interests);
		}
	}
}