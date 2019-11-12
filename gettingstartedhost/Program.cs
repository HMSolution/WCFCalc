using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using GettingStarted;
using GettingStarted;

namespace GettingStartedHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

            // Step 2: Create a ServiceHost instance.
            //Used to host the Service, takes the service and base address
            ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            try
            {
                // Step 3: Add a service endpoint.
                // This is created/composed by a binding, an address and a service contract
                // The endpoint address is the base address with the service name appended (http://localhost:8000/GettingStarted/CalculatorService) 
                selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

                // Step 4: Enable metadata exchange.
                // Used for creating proxies for calling service operations
                // Here a "ServiceMetadataBehavior" is created and its "HttpGetEnabled" property is set to true and then added
                // to the behaviors collection, for enabling metadata exchange
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5: Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");

                // Close the ServiceHost to stop the service.
                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}