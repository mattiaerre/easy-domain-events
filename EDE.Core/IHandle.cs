using EDE.Core.Events;

namespace EDE.Core
{
	public interface IHandle<in T> where T : IDomainEvent
	{
		void Handle(T domainEvent);
	}
}