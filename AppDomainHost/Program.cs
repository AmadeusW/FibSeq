using System;
using System.Runtime.Remoting;
using CodeConnect.RemoteRunner;
using System.Collections.Generic;
using System.Reflection;

namespace AppDomainHost
{
    class Program
    {
        static void Main(string[] args)
        {
            System.AppDomain NewAppDomain = System.AppDomain.CreateDomain("NewApplicationDomain");

            // Load the assembly and call the default entry point:
            //NewAppDomain.ExecuteAssembly(@"..\..\..\bin\Debug\AppDomainCommunication.exe");

            // Create an instance of RemoteObject:
            var handle = NewAppDomain.CreateInstanceFrom(@"..\..\..\SharedInterface\bin\Debug\CodeConnect.RemoteRunner.dll", "CodeConnect.RemoteRunner.Invoker");
            Invoker remoteInstance = (Invoker)handle.Unwrap();

            List<string> logs = remoteInstance.RunMethod(@"..\..\..\bin\Debug\AppDomainCommunication.exe", "AppDomainCommunication.______Instrumentation", "AppDomainCommunication.PrivateObject", "privateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (string log in logs)
            {
                Console.WriteLine(log);
            }
            Console.WriteLine("***");
        }
    }
}
