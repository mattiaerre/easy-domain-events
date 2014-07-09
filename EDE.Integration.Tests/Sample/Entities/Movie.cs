using System;
using System.Collections.Generic;
using EDE.Core.Events;
using EDE.Integration.Tests.Sample.Events;

namespace EDE.Integration.Tests.Sample.Entities
{
	public class Movie : IMovie
	{
		public int Id { get; private set; }
		public event Action<IDomainEvent> Raise;
		public string Title { get; private set; }
		public double Rating { get; private set; }
		public ICollection<string> Comments { get; private set; }
		public void UpdateRating(double rating)
		{
			Rating = rating;
			Raise(new RatingChanged(Id, rating));
		}

		public void AddComment(string comment)
		{
			Comments.Add(comment);
			Raise(new CommentAdded(Id, comment));
		}

		public Movie(int id, string title)
		{
			Id = id;
			Title = title;
			Comments = new List<string>();
		}
	}
}