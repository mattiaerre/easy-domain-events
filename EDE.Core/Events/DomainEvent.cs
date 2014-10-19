using System;

namespace EDE.Core.Events
{
    public abstract class DomainEvent : IDomainEvent
    {
        public virtual string Message
        {
            get { return string.Format("domain event of type {0} occurred on: {1}", GetType(), OccurredOn); }
        }
        public DateTime OccurredOn
        {
            get { return DateTime.UtcNow; }
        }
    }
}