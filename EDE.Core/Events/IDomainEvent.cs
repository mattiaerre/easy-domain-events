using System;

namespace EDE.Core.Events
{
	public interface IDomainEvent
	{
        string Message { get; }
        DateTime OccurredOn { get; }
	}
}