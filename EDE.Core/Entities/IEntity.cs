namespace EDE.Core.Entities
{
	public interface IEntity<out T>
	{
		T Id { get; }
	}
}