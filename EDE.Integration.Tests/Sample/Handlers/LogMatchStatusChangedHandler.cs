using EDE.Core;
using EDE.Core.Handlers;
using EDE.Integration.Tests.Sample.Events;
using System.Diagnostics;

namespace EDE.Integration.Tests.Sample.Handlers
{
	public class LogMatchStatusChangedHandler : DomainEventHandler, IHandle<MatchStatusChanged>
	{
		public void Handle(MatchStatusChanged domainEvent)
		{
			Debug.WriteLine("log: match status changed");
		}
	}
}