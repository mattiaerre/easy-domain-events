using System;
using EDE.Core.Events;
using EDE.Integration.Tests.Sample.Events;

namespace EDE.Integration.Tests.Sample.Entities
{
    public class Simple : ISimple
    {
        public int Id { get; private set; }
        public event Action<IDomainEvent> Raise;

        public Simple(int id)
        {
            Id = id;
        }

        public void Activate()
        {
            IsActive = true;
            Raise(new SimpleHasBeenActivated());
        }

        public bool IsActive { get; private set; }
    }
}
