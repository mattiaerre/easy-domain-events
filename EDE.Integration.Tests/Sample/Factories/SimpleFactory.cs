using EDE.Core.Listeners;
using EDE.Integration.Tests.Sample.Entities;

namespace EDE.Integration.Tests.Sample.Factories
{
    public class SimpleFactory : ISimpleFactory
    {
        private readonly IDomainEventsListener _domainEventsListener;

        public SimpleFactory(IDomainEventsListener domainEventsListener)
        {
            _domainEventsListener = domainEventsListener;
        }

        public ISimple Make()
        {
            var simple = new Simple(815);
            simple.Raise += e => _domainEventsListener.Handle(e);
            return simple;
        }
    }
}