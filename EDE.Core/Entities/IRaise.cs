using System;
using EDE.Core.Events;

namespace EDE.Core.Entities
{
	public interface IRaise
	{
		event Action<IDomainEvent> Raise;
	}
}