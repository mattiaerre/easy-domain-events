using EDE.Core;
using EDE.Core.Handlers;
using EDE.Integration.Tests.Sample.Events;
using System.Diagnostics;

namespace EDE.Integration.Tests.Sample.Handlers
{
	public class LogSimpleHasBeenActivatedHandler : DomainEventHandler, IHandle<SimpleHasBeenActivated>
	{
		public void Handle(SimpleHasBeenActivated domainEvent)
		{
			Debug.WriteLine("log: simple has been activated");
		}
	}
}
