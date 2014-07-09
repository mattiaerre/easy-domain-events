using System;

namespace EDE.Core.Events
{
	public interface IRaise
	{
		event Action<IDomainEvent> Raise;
	}
}