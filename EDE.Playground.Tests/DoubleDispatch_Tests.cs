using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace EDE.Playground.Tests
{
	[TestFixture]
	public class DoubleDispatch_Tests
	{
		private IListener _listener;

		[SetUp]
		public void Given_A_GlobalListener()
		{
			var handlers = new List<DomainEventHandler> { new LogResultChangedHandler(), new MailResultChangedHandler(), new LogGameStatusChangedHandler() };
			_listener = new Listener(handlers);
		}

		[Test]
		public void When_GameStatusChanged_Only_LogGameStatusChangedHandler_Should_Be_Called()
		{
			_listener.When(new GameStatusChanged());
		}
		
		[Test]
		public void When_ResultChanged_MailResultChangedHandler_And_LogResultChangedHandler_Should_Be_Called()
		{
			_listener.When(new ResultChanged());
		}
	}

	public class GameStatusChanged : IDomainEvent
	{
	}

	public class ResultChanged : IDomainEvent
	{
	}

	public class Listener : IListener
	{
		private readonly IEnumerable<DomainEventHandler> _handlers;

		public Listener(IEnumerable<DomainEventHandler> handlers)
		{
			_handlers = handlers;
		}

		public void When(IDomainEvent domainEvent)
		{
			foreach (var handler in _handlers)
				handler.Apply(domainEvent);
		}
	}

	public interface IListener
	{
		void When(IDomainEvent domainEvent);
	}

	public interface IDomainEvent
	{
	}

	public abstract class DomainEventHandler
	{
		public void Apply(IDomainEvent domainEvent)
		{
			((dynamic)this).Handle((dynamic)domainEvent);
		}

		public void Handle(IDomainEvent domainEvent)
		{
		}
	}

	public class LogGameStatusChangedHandler : DomainEventHandler, IHandler<GameStatusChanged>
	{
		public void Handle(GameStatusChanged domainEvent)
		{
			Debug.WriteLine("log: game status changed");
		}
	}

	public class MailResultChangedHandler : DomainEventHandler, IHandler<ResultChanged>
	{
		public void Handle(ResultChanged domainEvent)
		{
			Debug.WriteLine("mail: result changed");
		}
	}

	public class LogResultChangedHandler : DomainEventHandler, IHandler<ResultChanged>
	{
		public void Handle(ResultChanged domainEvent)
		{
			Debug.WriteLine("log: result changed");
		}
	}

	public interface IHandler<T> where T : IDomainEvent
	{
		void Handle(T domainEvent);
	}
}
