using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace EDE.Playground.Tests
{
	[TestFixture]
	public class DoubleDispatch_Tests
	{
		private IDomainEventListener _listener;

		[SetUp]
		public void Given_A_DomainEventListener()
		{
			var handlers = new List<IDomainEventHandler> { new LogResultChangedHandler(), new MailResultChangedHandler(), new LogGameStatusChangedHandler() };
			_listener = new DomainEventListener(handlers);
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

	public class GameStatusChanged : IDomainEvent
	{
	}

	public class ResultChanged : IDomainEvent
	{
	}

	public class DomainEventListener : IDomainEventListener
	{
		private readonly IEnumerable<IDomainEventHandler> _handlers;

		public DomainEventListener(IEnumerable<IDomainEventHandler> handlers)
		{
			_handlers = handlers;
		}

		public void Handle(IDomainEvent domainEvent)
		{
			foreach (var handler in _handlers)
				handler.When(domainEvent);
		}
	}

	public abstract class DomainEventHandler : IDomainEventHandler
	{
		public void When(IDomainEvent domainEvent)
		{
			((dynamic)this).Handle((dynamic)domainEvent);
		}

		public void Handle(IDomainEvent domainEvent)
		{
		}
	}

	public class LogGameStatusChangedHandler : DomainEventHandler, IHandle<GameStatusChanged>
	{
		public void Handle(GameStatusChanged domainEvent)
		{
			Debug.WriteLine("log: game status changed");
		}
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

	public interface IDomainEvent
	{
	}

	public interface IHandle<in T> where T : IDomainEvent
	{
		void Handle(T domainEvent);
	}

	public interface IDomainEventListener : IHandle<IDomainEvent>
	{
	}

	public interface IDomainEventHandler : IHandle<IDomainEvent>
	{
		void When(IDomainEvent domainEvent);
	}
}