using System.Diagnostics;
using EDE.Core;
using EDE.Core.Handlers;
using EDE.Integration.Tests.Sample.Events;

namespace EDE.Integration.Tests.Sample.Handlers
{
	public class MailMatchStatusChangedHandler : DomainEventHandler, IHandle<MatchStatusChanged>
	{
		public void Handle(MatchStatusChanged domainEvent)
		{
			Debug.WriteLine("mail: match status changed");
		}
	}
}