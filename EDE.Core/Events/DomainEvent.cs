using System;

namespace EDE.Core.Events
{
    public abstract class DomainEvent : IDomainEvent
    {
        private readonly DateTime _occurredOn;
        protected DomainEvent()
            : this(DateTime.UtcNow)
        {
        }
        protected DomainEvent(DateTime occurredOn)
        {
            _occurredOn = occurredOn;
        }
        public virtual string Message
        {
            get { return string.Format("domain event of type {0} occurred on: {1}", GetType(), OccurredOn); }
        }
        public DateTime OccurredOn
        {
            get { return _occurredOn; }
        }
    }
}