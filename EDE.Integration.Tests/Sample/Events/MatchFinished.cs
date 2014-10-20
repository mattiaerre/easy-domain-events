using EDE.Core.Events;

namespace EDE.Integration.Tests.Sample.Events
{
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