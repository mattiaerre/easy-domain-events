using System;
using EDE.Core.Events;

namespace EDE.Integration.Tests.Sample.Events
{
    public class ApplicantCreated : DomainEvent
    {
        public ApplicantCreated(DateTime occurredOn)
            : base(occurredOn)
        {
        }
    }
}
