using EDE.Core.Events;

namespace EDE.Core.Handlers
{
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
}