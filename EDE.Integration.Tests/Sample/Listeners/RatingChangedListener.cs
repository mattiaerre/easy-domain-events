using EDE.Core.Events;
using EDE.Integration.Tests.Sample.Events;

namespace EDE.Integration.Tests.Sample.Listeners
{
	public class RatingChangedListener : IRatingChangedListener
	{
		public void Handle(IDomainEvent domainEvent)
		{
			DomainEvent = (IRatingChanged)domainEvent;
		}

		public IRatingChanged DomainEvent { get; private set; }
	}
}