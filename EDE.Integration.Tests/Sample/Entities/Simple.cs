using System;
using EDE.Core.Events;
using EDE.Integration.Tests.Sample.Events;

namespace EDE.Integration.Tests.Sample.Entities
{
	public class Simple : ISimple
	{
		private bool _isActive;
		public int Id { get; private set; }
		public event Action<IDomainEvent> Raise;

		public Simple(int id)
		{
			Id = id;
		}

		public void Activate()
		{
			_isActive = true;
			Raise(new SimpleHasBeenActivated());
		}

		public bool IsActive()
		{
			return _isActive;
		}
	}
}
