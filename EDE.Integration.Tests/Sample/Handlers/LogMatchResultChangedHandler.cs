using System.Diagnostics;
using EDE.Core;
using EDE.Core.Handlers;
using EDE.Integration.Tests.Sample.Events;

namespace EDE.Integration.Tests.Sample.Handlers
{
	public class LogMatchResultChangedHandler : DomainEventHandler, IHandle<MatchResultChanged>
	{
		public void Handle(MatchResultChanged domainEvent)
		{
			Debug.WriteLine("log: match result changed");
		}
	}
}
