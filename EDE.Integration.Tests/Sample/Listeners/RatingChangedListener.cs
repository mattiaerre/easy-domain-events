using System.Diagnostics;
using EDE.Core.Events;
using EDE.Integration.Tests.Sample.Events;

namespace EDE.Integration.Tests.Sample.Listeners
{
	public class RatingChangedListener : IRatingChangedListener
	{
		public void Handle(IDomainEvent domainEvent)
		{
			var ratingChanged = (IRatingChanged) domainEvent;
			Debug.WriteLine("'{0}' has been rated {1}/5", ratingChanged.Title, ratingChanged.Rating);
		}
	}
}