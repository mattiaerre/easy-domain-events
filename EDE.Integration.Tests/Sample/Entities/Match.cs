using System;
using EDE.Core.Events;
using EDE.Integration.Tests.Sample.Events;

namespace EDE.Integration.Tests.Sample.Entities
{
	public class Match : IMatch
	{
		public Guid Id { get; private set; }
		public event Action<IDomainEvent> Raise;
		public int Status { get; private set; }
		public int HomeTeamScore { get; private set; }

		public void Starts()
		{
			Status = 1; // info: a better idea is using an enum
			Raise(new MatchStatusChanged());
		}

		public void HomeTeamScores()
		{
			HomeTeamScore += 1;
			Raise(new MatchResultChanged());
		}

		public Match(Guid id)
		{
			Id = id;
		}
	}
}