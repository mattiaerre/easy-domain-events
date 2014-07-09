namespace EDE.Integration.Tests.Sample.Events
{
	public class CommentAdded : ICommentAdded
	{
		public int Id { get; private set; }
		public string Comment { get; private set; }

		public CommentAdded(int id, string comment)
		{
			Id = id;
			Comment = comment;
		}
	}
}