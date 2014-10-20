using EDE.Core.Events;
using EDE.Integration.Tests.Sample.Events;
using NUnit.Framework;
using System;

namespace EDE.Integration.Tests.Events
{
    public class DomainEvent_Tests
    {
        private DomainEvent _domainEvent;
        private readonly DateTime _occurredOn = new DateTime(2014, 10, 20, 11, 23, 55);

        [SetUp]
        public void Given_A_DomainEvent()
        {
            _domainEvent = new ApplicantCreated(_occurredOn);
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

            Assert.AreEqual(_occurredOn, occurredOn);
        }

        [Test]
        public void It_Should_Be_Possible_To_Override_The_Message_In_A_Derived_Class()
        {
            const string message = "AAAaaa";

            var domainEvent = new MatchFinished(message);

            Assert.AreEqual(message, domainEvent.Message);
        }
    }
}
