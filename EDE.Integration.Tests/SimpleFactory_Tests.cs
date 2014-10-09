using Castle.Facilities.EventWiring;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using EDE.Core.Handlers;
using EDE.Core.Listeners;
using EDE.Integration.Tests.Sample.Entities;
using EDE.Integration.Tests.Sample.Factories;
using NUnit.Framework;

namespace EDE.Integration.Tests
{
    [TestFixture]
    public class SimpleFactory_Tests
    {
        private IWindsorContainer _container;

        private ISimple _simple;
        private ISimpleFactory _factory;

        private void BootstrapContainer()
        {
            _container = new WindsorContainer();

            var kernel = _container.Kernel;
            kernel.Resolver.AddSubResolver(new CollectionResolver(kernel));

            _container.AddFacility<EventWiringFacility>();

            _container.Register(Classes.FromThisAssembly().BasedOn<IDomainEventHandler>().WithService.AllInterfaces());

            //_container.Register(Component.For<ISimple>().ImplementedBy<Simple>().DependsOn(new { Id = 815 })
            //    .PublishEvent(p => p.Raise += null, s => s.To<DomainEventsListener>(DomainEventsListener.ComponentName, l => l.Handle(null))));

            _container.Register(Component.For<ISimpleFactory>().ImplementedBy<SimpleFactory>());

            _container.Register(Component.For<IDomainEventsListener>().ImplementedBy<DomainEventsListener>().Named(DomainEventsListener.ComponentName));
        }

        [SetUp]
        public void Given_A_Simple()
        {
            BootstrapContainer();

            _factory = _container.Resolve<ISimpleFactory>();

            _simple = _factory.Make();
        }

        [Test]
        public void When_Activate_And_SimpleHasBeenActivated_Then_LogSimpleHasBeenActivatedHandler_Should_Handle()
        {
            _simple.Activate();
            Assert.IsTrue(_simple.IsActive);
        }

        [TearDown]
        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
