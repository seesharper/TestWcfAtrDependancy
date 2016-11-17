using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWcfRestrict
{
    using System.ServiceModel.Description;

    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            UserLoggingServiceElement.AttributeFactory =
                () => ((ServiceContainer) serviceRegistry).GetInstance<MyInspectorAttribute>();

            serviceRegistry.Register<IServiceBehavior>(factory => new ServiceMetadataBehavior() {HttpGetEnabled = true});
            serviceRegistry.Register<MyInspectorAttribute>();
            serviceRegistry.Register<IService1, Service1>();
            serviceRegistry.Register<IExternalService,ExternalService >();
            
        }
    }
}