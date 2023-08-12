// ProxyPattern.
// A 'placeholder' for an 'original' object that controls access to the 'original' object.
// Instead of directly 'calling' the original object, you call the placeholder object who then calls the original object'.
// In this example, MyService is the original object we want to call. 

using System;
using System.Text;

namespace ProxyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Directly call 'myService'
            MyRealService myService = new MyRealService();
            myService.Request();

            // By proxy calling 'myService'
            Proxy proxy = new Proxy(myService);
            proxy.Request();

            Console.ReadLine();
        }
    }

    interface IService
    {
        void Request();
    }

    public class MyRealService : IService
    {
        public void Request()
        {
            Console.WriteLine("[MyRealService] Handling request");
        }
    }

    public class Proxy : IService
    {
        private MyRealService _myRealService;
        
        public Proxy(MyRealService myRealService)
        {
            _myRealService = myRealService;
        }

        public void Request()
        {
            Console.WriteLine("[Proxy] proxying request to: [MyRealService]");
            if (ValidateAccess())
            {
                Console.WriteLine("[Proxy] Credentials valid");
                _myRealService.Request();
            }
        }

        public bool ValidateAccess()
        {
            Console.WriteLine("[Proxy] Validating credentials");
            return true;
        }
    }
}

// Outputs:
// [MyRealService] Handling request
// [Proxy] proxying request to: [MyRealService]
// [Proxy] Validating credentials
// [Proxy] Credentials valid
// [MyRealService] Handling request
