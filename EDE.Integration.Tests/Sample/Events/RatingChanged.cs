namespace EDE.Integration.Tests.Sample.Events
{
	public class RatingChanged : IRatingChanged
	{
		public int Id { get; private set; }
		public double Rating { get; private set; }

		public RatingChanged(int id, double rating)
		{
			Id = id;
			Rating = rating;
		}
	}
}