using System.Collections.Generic;
using EDE.Core.Events;
using EDE.Core.Handlers;

namespace EDE.Core.Listeners
{
	public class DomainEventsListener : IDomainEventsListener
	{
		public const string ComponentName = "easy-domain-events-listener";

		private readonly IEnumerable<IDomainEventHandler> _handlers;

		public DomainEventsListener(IEnumerable<IDomainEventHandler> handlers)
		{
			_handlers = handlers;
		}

		public void Handle(IDomainEvent domainEvent)
		{
			foreach (var handler in _handlers)
				handler.When(domainEvent);
		}
	}
}