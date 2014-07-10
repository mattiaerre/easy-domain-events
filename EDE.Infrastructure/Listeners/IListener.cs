using EDE.Core.Events;

namespace EDE.Infrastructure.Listeners
{
	public interface IListener
	{
		void Handle(IDomainEvent domainEvent); // rodo: rename to 'When'
	}
}
