using EDE.Core.Events;

namespace EDE.Integration.Tests.Sample.Events
{
	public interface ICommentAdded : IDomainEvent
	{
		int Id { get; }
		string Comment { get; }
	}
}