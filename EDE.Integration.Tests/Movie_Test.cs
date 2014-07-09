using System.Linq;
using Castle.Facilities.EventWiring;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EDE.Integration.Tests.Sample.Entities;
using EDE.Integration.Tests.Sample.Listeners;
using NUnit.Framework;

namespace EDE.Integration.Tests
{
	[TestFixture]
	public class Movie_Test
	{
		private const int Id = 815;
		private const string Title = "reservoir dogs";
		private const double Rating = 4.5;
		private const string Comment = "a comment";

		private IWindsorContainer _container;

		private IMovie _movie;
		private IRatingChangedListener _ratingChangedListener;
		private ICommentAddedListener _commentAddedListener;

		[SetUp]
		public void Given_A_Movie()
		{
			BootstrapContainer();

			_movie = _container.Resolve<IMovie>();

			_ratingChangedListener = _container.Resolve<IRatingChangedListener>();

			_commentAddedListener = _container.Resolve<ICommentAddedListener>();
		}

		private void BootstrapContainer()
		{
			_container = new WindsorContainer();

			_container.AddFacility<EventWiringFacility>();

			_container.Register(Component.For<IRatingChangedListener>().ImplementedBy<RatingChangedListener>().Named("rating"));

			_container.Register(Component.For<ICommentAddedListener>().ImplementedBy<CommentAddedListener>().Named("comment"));

			_container.Register(Component.For<IMovie>().ImplementedBy<Movie>().DependsOn(new { id = Id, title = Title })
				.PublishEvent(p => p.Raise += null, s => s
					.To<RatingChangedListener>("rating", l => l.Handle(null))
					.To<CommentAddedListener>("comment", l => l.Handle(null))));
		}

		[Test]
		public void When_Rating_Changed_Then_An_Event_Is_Raised()
		{
			_movie.UpdateRating(Rating);

			// against movie
			Assert.AreEqual(Title, _movie.Title);
			Assert.AreEqual(Rating, _movie.Rating);

			// against listener
			Assert.AreEqual(Id, _ratingChangedListener.RatingChanged.Id);
			Assert.AreEqual(Rating, _ratingChangedListener.RatingChanged.Rating);
		}

		[Test]
		public void When_Comment_Added_Then_An_Event_Is_Raised()
		{
			_movie.AddComment(Comment);

			// against movie
			Assert.AreEqual(Title, _movie.Title);
			Assert.AreEqual(Comment, _movie.Comments.First());

			// against listener
			Assert.AreEqual(Id, _commentAddedListener.CommentAdded.Id);
			Assert.AreEqual(Comment, _commentAddedListener.CommentAdded.Comment);
		}

		[TearDown]
		public void Dispose()
		{
			_container.Dispose();
		}
	}
}
