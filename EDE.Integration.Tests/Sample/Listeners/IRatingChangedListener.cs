using EDE.Infrastructure.Listeners;
using EDE.Integration.Tests.Sample.Events;

namespace EDE.Integration.Tests.Sample.Listeners
{
	public interface IRatingChangedListener : IListener
	{
		IRatingChanged DomainEvent { get; }
	}
}