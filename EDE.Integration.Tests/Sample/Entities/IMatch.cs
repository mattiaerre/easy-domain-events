using System;
using EDE.Core.Entities;

namespace EDE.Integration.Tests.Sample.Entities
{
	public interface IMatch : IEntity<Guid>, IRaise
	{
		int Status { get; }
		int HomeTeamScore { get; }
		void Starts();
		void HomeTeamScores();
	}
}