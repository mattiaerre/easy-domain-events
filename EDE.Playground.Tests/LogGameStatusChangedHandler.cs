using System.Diagnostics;
using EDE.Core;
using EDE.Core.Handlers;

namespace EDE.Playground.Tests
{
	public class LogGameStatusChangedHandler : DomainEventHandler, IHandle<GameStatusChanged>
	{
		public void Handle(GameStatusChanged domainEvent)
		{
			Debug.WriteLine("log: game status changed");
		}
	}
}