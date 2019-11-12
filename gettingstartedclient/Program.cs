using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using gettingstartedclient.ServiceReference1; //Service reference

namespace GettingStartedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(5000);
            //Step 1: Create an instance of the WCF proxy.
            CalculatorClient client = new CalculatorClient();

            // Step 2: Call the service operations.
            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

            // Custom playaround with the service

            var end = false;
            while(!end)
            {
                Console.WriteLine("Send a message to the server!");
                Console.WriteLine();
                var message = Console.ReadLine();
                var response = client.Respond(message);
                Console.WriteLine("The server responded: " + response);
                Console.WriteLine();
            }          

            // Step 3: Close the client to gracefully close the connection and clean up resources.
            Console.WriteLine("\nPress <Enter> to terminate the client.");
            Console.ReadLine();
            client.Close();
        }
    }
}