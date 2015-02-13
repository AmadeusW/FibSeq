using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCommunication
{
    public class ______Instrumentation : CodeConnect.RemoteInstrumentation._____RemoteInstrumentation
    {
        public override List<String> RunClientCode(string targetType, string targetMethod, System.Reflection.BindingFlags targetMethodFlags)
        {
            // Set up logsging
            Logs = new List<string>();

            var inspectedInstance = new PrivateObject();
            System.Reflection.MethodInfo method = System.Reflection.Assembly.GetExecutingAssembly().GetType(targetType).GetMethod(targetMethod, targetMethodFlags);
            if (method == null)
            {
                throw new InvalidOperationException("Method not found");
            }

            try
            {
                method.Invoke(inspectedInstance, null);
                return Logs;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occured", ex);
            }
        }
    }

    class PrivateObject
    {
        public PrivateObject()
        {
            System.Console.WriteLine("Hello, Side effects! (PrivateObject Constructor)");
        }

        private int privateMethod() // Modified
        {
            var x = ______Instrumentation.LogFunction<int>("x", 5);
            var y = ______Instrumentation.LogFunction<int>("a", 3);
            var z = ______Instrumentation.LogFunction<int>("z", ______Instrumentation.LogFunction<int>("x", x) + ______Instrumentation.LogFunction<int>("y", y));
            return ______Instrumentation.LogFunction<int>("return", 3);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello, World! (Main method)");
        }
    }
}
