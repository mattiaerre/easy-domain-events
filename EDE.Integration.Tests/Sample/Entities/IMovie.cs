using System.Collections.Generic;
using EDE.Core.Entities;

namespace EDE.Integration.Tests.Sample.Entities
{
	public interface IMovie : IEntity<int>, IRaise
	{
		string Title { get; }
		double Rating { get; }
		ICollection<string> Comments { get; }
		void UpdateRating(double rating);
		void AddComment(string comment);
	}
}