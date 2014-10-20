using Castle.Facilities.EventWiring;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EDE.Core.Listeners;

namespace EDE.Infrastructure.Installers
{
    public class EasyDomainEventsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<EventWiringFacility>();
            container.Register(
                Component.For<IDomainEventsListener>()
                    .ImplementedBy<DomainEventsListener>()
                    .Named(DomainEventsListener.ComponentName));
        }
    }
}
