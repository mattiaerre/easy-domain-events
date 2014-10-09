using EDE.Core.Entities;

namespace EDE.Integration.Tests.Sample.Entities
{
	public interface ISimple : IEntity<int>, IRaise
	{
		void Activate();
	    bool IsActive { get; }
	}
}