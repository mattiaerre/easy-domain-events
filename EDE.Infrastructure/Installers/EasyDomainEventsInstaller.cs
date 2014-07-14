using Castle.Facilities.EventWiring;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EDE.Core.Entities;
using EDE.Core.Handlers;
using EDE.Core.Listeners;

namespace EDE.Infrastructure.Installers
{
	public class EasyDomainEventsInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.AddFacility<EventWiringFacility>(); // info: I will probably get rid of this

			container.Register(Component.For<IDomainEventsListener>().ImplementedBy<DomainEventsListener>().Named(DomainEventsListener.ComponentName));

			// see: http://docs.castleproject.org/Windsor.Registering-components-by-conventions.ashx
			container.Register(Classes.FromAssemblyNamed("EDE.Integration.Tests").BasedOn<IDomainEventHandler>().WithService.AllInterfaces()); // todo: change this

			//// todo: try to register by convention all the IRaise components
			//container.Register(Component.For<IRaise>().ImplementedBy<Match>().DependsOn(new { id = Guid.NewGuid() })
			//	.PublishEvent(p => p.Raise += null, s => s.To<DomainEventsListener>(DomainEventsListener.ComponentName, l => l.Handle(null))));


			container.Register(Classes.FromAssemblyNamed("EDE.Integration.Tests").BasedOn<IRaise>().WithService.AllInterfaces());
		}
	}
}
