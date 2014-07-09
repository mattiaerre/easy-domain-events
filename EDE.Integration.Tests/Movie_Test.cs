﻿using Castle.Facilities.EventWiring;
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
		private const string Title = "reservoir dogs";
		private const double Rating = 4.5;

		private IWindsorContainer _container;

		private IMovie _movie;

		[SetUp]
		public void Given_A_Movie()
		{
			BootstrapContainer();

			_movie = _container.Resolve<IMovie>();
		}

		private void BootstrapContainer()
		{
			_container = new WindsorContainer();

			_container.AddFacility<EventWiringFacility>();

			_container.Register(Component.For<IMovie>().ImplementedBy<Movie>().DependsOn(new { title = Title })
				.PublishEvent(p => p.Raise += null, s => s
					.To<RatingChangedListener>("listener", l => l.Handle(null))),
					Component.For<RatingChangedListener>().Named("listener"));
		}

		[Test]
		public void When_Rating_Changes_Then_An_Event_Is_Raised()
		{
			_movie.UpdateRating(Rating);

			Assert.AreEqual(Title, _movie.Title);
			Assert.AreEqual(Rating, _movie.Rating);
		}

		[TearDown]
		public void Dispose()
		{
			_container.Dispose();
		}
	}
}
