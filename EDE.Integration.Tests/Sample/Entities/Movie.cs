using System;
using EDE.Core.Events;
using EDE.Integration.Tests.Sample.Events;

namespace EDE.Integration.Tests.Sample.Entities
{
	public class Movie : IMovie
	{
		public event Action<IDomainEvent> Raise;
		public string Title { get; private set; }
		public double Rating { get; private set; }
		public void UpdateRating(double rating)
		{
			Rating = rating;
			Raise(new RatingChanged(Title, Rating));
		}

		public Movie(string title)
		{
			Title = title;
		}
	}
}