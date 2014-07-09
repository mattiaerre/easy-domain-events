using EDE.Core.Events;

namespace EDE.Integration.Tests.Sample.Events
{
	public interface IRatingChanged : IDomainEvent
	{
		string Title { get; }
		double Rating { get; }
	}
}