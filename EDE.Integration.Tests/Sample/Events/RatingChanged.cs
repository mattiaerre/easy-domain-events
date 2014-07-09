namespace EDE.Integration.Tests.Sample.Events
{
	public class RatingChanged : IRatingChanged
	{
		public string Title { get; private set; }
		public double Rating { get; private set; }

		public RatingChanged(string title, double rating)
		{
			Title = title;
			Rating = rating;
		}
	}
}