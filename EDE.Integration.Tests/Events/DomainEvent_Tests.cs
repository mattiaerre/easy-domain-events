using EDE.Core.Events;
using EDE.Integration.Tests.Sample.Events;
using NUnit.Framework;
using System;

namespace EDE.Integration.Tests.Events
{
    public class DomainEvent_Tests
    {
        private DomainEvent _domainEvent;

        [SetUp]
        public void Given_A_DomainEvent()
        {
            _domainEvent = new ApplicantCreated();
        }

        [Test]
        public void It_Should_Carry_A_Message()
        {
            var message = _domainEvent.Message;

            Assert.IsTrue(message.Contains("ApplicantCreated"));
        }

        [Test]
        public void It_Should_Tell_When_The_Event_Occurred()
        {
            var occurredOn = _domainEvent.OccurredOn;

            Assert.IsTrue(occurredOn <= DateTime.UtcNow);
        }

        [Test]
        public void It_Should_Be_Possible_To_Override_The_Message_In_A_Derived_Class()
        {
            const string message = "AAAaaa";

            var domainEvent = new MatchFinished(message);

            Assert.AreEqual(message, domainEvent.Message);
        }
    }

    public class MatchFinished : DomainEvent
    {
        private readonly string _message;

        public MatchFinished(string message)
        {
            _message = message;
        }

        public override string Message
        {
            get { return _message; }
        }
    }
}
