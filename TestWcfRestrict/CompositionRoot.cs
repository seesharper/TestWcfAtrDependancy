using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWcfRestrict
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IService1, Service1>();
            serviceRegistry.Register<IExternalService,ExternalService >();
            
        }
    }
}