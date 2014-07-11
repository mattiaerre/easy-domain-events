using EDE.Core.Events;

namespace EDE.Core.Listeners
{
	public interface IDomainEventsListener : IHandle<IDomainEvent>
	{
	}
}