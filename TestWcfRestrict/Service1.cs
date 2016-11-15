using System;
using System.ServiceModel;

namespace TestWcfRestrict
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class Service1 : IService1
    {

        public AuthState AuthState { get; set; }

        public string Login(int value)
        {    
            
            if (AuthState != AuthState.None)
            {
                throw new FaultException("Login уже вызывать не нужно");
            }
                    
            if (value == 777)
            {
                AuthState = AuthState.Authenticated;
            }
            else
            {
                throw new FaultException("не удалось авторизоваться");
            }

            return null;
        }

        public bool Confirm()
        {
            if (AuthState == AuthState.Authenticated)
            {
                AuthState = AuthState.Confirmed;
            }else if (AuthState == AuthState.None)
            {
                throw new FaultException("Сначала нужно авторизоваться через Login");
            }
            else
            {
                throw new FaultException("Подтверждение уже вызвано");
            }

            return false;
        }

        public string GetDataUsingDataContract(int input)
        {
            return string.Format("result=" + input);
        }

        
    }
}
