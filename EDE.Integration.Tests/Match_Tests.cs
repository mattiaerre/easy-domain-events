using Castle.Facilities.EventWiring;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using EDE.Core.Listeners;
using EDE.Integration.Tests.Sample.Entities;
using NUnit.Framework;
using System;

namespace EDE.Integration.Tests
{
	[TestFixture]
	public class Match_Tests
	{
		private IWindsorContainer _container;

		private IMatch _match;

		private void BootstrapContainer()
		{
			_container = new WindsorContainer();

			var kernel = _container.Kernel;
			kernel.Resolver.AddSubResolver(new CollectionResolver(kernel));

			//// todo: try to register by convention all the IRaise components
			_container.Register(Component.For<IMatch>().ImplementedBy<Match>().DependsOn(new {id = Guid.NewGuid()}));
			//	.PublishEvent(p => p.Raise += null, s => s.To<DomainEventsListener>(DomainEventsListener.ComponentName, l => l.Handle(null))));

			_container.Install(FromAssembly.Named("EDE.Infrastructure")); // todo: change this

		}

		[SetUp]
		public void Given_A_Match()
		{
			BootstrapContainer();

			_match = _container.Resolve<IMatch>();
		}

		[Test]
		public void When_It_Starts_And_MatchStatusChanged_Then_LogMatchStatusChangedHandler_And_MailMatchStatusChangedHandler_Should_Handle()
		{
			_match.Starts();
			Assert.AreEqual(1, _match.Status);
		}

		[Test]
		public void When_Home_Team_Scores_And_MatchResultChanged_Then_LogMatchResultChangedHandler_Should_Handle()
		{
			_match.HomeTeamScores();
			Assert.AreEqual(1, _match.HomeTeamScore);
		}

		[TearDown]
		public void Dispose()
		{
			_container.Dispose();
		}
	}
}
