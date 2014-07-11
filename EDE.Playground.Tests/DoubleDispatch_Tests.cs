using EDE.Core;
using EDE.Core.Events;
using EDE.Core.Handlers;
using EDE.Core.Listeners;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace EDE.Playground.Tests
{
	[TestFixture]
	public class DoubleDispatch_Tests
	{
		private IDomainEventsListener _listener;

		[SetUp]
		public void Given_A_DomainEventListener()
		{
			var handlers = new List<IDomainEventHandler> { new LogResultChangedHandler(), new MailResultChangedHandler(), new LogGameStatusChangedHandler() };
			_listener = new DomainEventsListener(handlers);
		}

		[Test]
		public void When_GameStatusChanged_Only_LogGameStatusChangedHandler_Should_Be_Called()
		{
			_listener.Handle(new GameStatusChanged());
		}

		[Test]
		public void When_ResultChanged_MailResultChangedHandler_And_LogResultChangedHandler_Should_Be_Called()
		{
			_listener.Handle(new ResultChanged());
		}
	}

	public class ResultChanged : IDomainEvent
	{
	}

	public class MailResultChangedHandler : DomainEventHandler, IHandle<ResultChanged>
	{
		public void Handle(ResultChanged domainEvent)
		{
			Debug.WriteLine("mail: result changed");
		}
	}

	public class LogResultChangedHandler : DomainEventHandler, IHandle<ResultChanged>
	{
		public void Handle(ResultChanged domainEvent)
		{
			Debug.WriteLine("log: result changed");
		}
	}
}