using EDE.Core.Events;

namespace EDE.Core.Handlers
{
	public interface IDomainEventHandler : IHandle<IDomainEvent>
	{
		void When(IDomainEvent domainEvent);
	}
}