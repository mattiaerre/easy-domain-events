using EDE.Core.Entities;

namespace EDE.Integration.Tests.Sample.Entities
{
	public interface IMovie : IRaise
	{
		string Title { get; }
		double Rating { get; }
		void UpdateRating(double rating);
	}
}