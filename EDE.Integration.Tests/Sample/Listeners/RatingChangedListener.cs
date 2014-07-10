using EDE.Core.Events;
using EDE.Integration.Tests.Sample.Events;

namespace EDE.Integration.Tests.Sample.Listeners
{
	public class RatingChangedListener : IRatingChangedListener
	{
		public void Handle(IDomainEvent domainEvent)
		{
			var ratingChanged = domainEvent as IRatingChanged;
			if (ratingChanged != null)
			{
				RatingChanged = ratingChanged;
			}
		}

		public IRatingChanged RatingChanged { get; private set; }
	}
}