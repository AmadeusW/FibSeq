using System;
using System.Collections.Generic;
using System.Reflection;

namespace CodeConnect.RemoteRunner
{
    public class Invoker : MarshalByRefObject
    {
        // An intermediate step that needs better description (TODO)
        // params: "AppDomainCommunication", "PrivateObject", "privateMethod", BindingFlags.NonPublic | BindingFlags.Instance
        public List<String> RunMethod(string assembly, string targetType, string targetMethod, BindingFlags targetMethodFlags)
        {
            Assembly targetAssembly = Assembly.Load(assembly);
            Type instrumentationType = targetAssembly.GetType("______Instrumentation");
            MethodInfo instrumentationMethod = instrumentationType.GetMethod("RunClientCode", BindingFlags.Public | BindingFlags.Instance);
            object results = instrumentationMethod.Invoke(instrumentationType, new object[] { targetType, targetMethod, targetMethodFlags });
            return results as List<String>;
        }
    }
}
