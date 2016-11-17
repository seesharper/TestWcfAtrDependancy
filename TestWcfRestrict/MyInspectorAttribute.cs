using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace TestWcfRestrict
{
    public class MyInspectorAttribute : Attribute, IOperationBehavior, IParameterInspector, IServiceBehavior
    {
        public IExternalService ExternalServiceInstance { get; set; }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
           dispatchOperation.ParameterInspectors.Add(this); 



        }

        public void Validate(OperationDescription operationDescription)
        {
            
        }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            Console.WriteLine("Operation {0} returned: result = {1}", operationName, returnValue);
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            string r = ExternalServiceInstance.Method1(45);   //ExternalServiceInstance is no longer null.


            return null;

            // This still fails as I am not sure what is going on here 
            var myService = (Service1)OperationContext.Current.InstanceContext.GetServiceInstance();
            AuthState authState = myService.AuthState;           

            string authMethod = "Login";

            if (authState == AuthState.None)
            {
                if (operationName != "Login")
                {
                    throw new FaultException("Сначала необходимо авторизоваться");
                }
            }

            if (authState == AuthState.Authenticated)
            {
                if (operationName != "Confirm")
                {
                    throw new FaultException("Сначала необходимо выслать подтверждение");
                }
            }

            return null;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            //throw new NotImplementedException();
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            //throw new NotImplementedException();
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            IParameterInspector parameterInspector = UserLoggingServiceElement.AttributeFactory();
                

            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpointDispatcher in dispatcher.Endpoints)
                {
                    DispatchRuntime dispatchRuntime = endpointDispatcher.DispatchRuntime;
                    IEnumerable<DispatchOperation> dispatchOperations = dispatchRuntime.Operations;

                    foreach (DispatchOperation dispatchOperation in dispatchOperations)
                    {
                        dispatchOperation.ParameterInspectors.Add(parameterInspector);
                    }                   
                }
            }
        }

        
    }
}