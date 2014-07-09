using EDE.Core.Events;
using EDE.Integration.Tests.Sample.Events;

namespace EDE.Integration.Tests.Sample.Listeners
{
	public class CommentAddedListener : ICommentAddedListener
	{
		public void Handle(IDomainEvent domainEvent)
		{
			var commentAdded = domainEvent as ICommentAdded;
			if (commentAdded != null)
			{
				CommentAdded = commentAdded;
			}
		}

		public ICommentAdded CommentAdded { get; private set; }
	}
}