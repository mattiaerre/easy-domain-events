using EDE.Core.Events;

namespace EDE.Integration.Tests.Sample.Events
{
	public interface IRatingChanged : IDomainEvent
	{
		int Id { get; }
		double Rating { get; }
	}
}