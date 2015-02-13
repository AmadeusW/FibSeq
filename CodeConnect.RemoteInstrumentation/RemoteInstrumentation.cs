using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeConnect.RemoteInstrumentation
{
    public abstract class _____RemoteInstrumentation
    {
        public abstract List<String> RunClientCode(string targetType, string targetMethod, System.Reflection.BindingFlags targetMethodFlags);

        public static List<String> Logs // Injected
        {
            get; set;
        }

        public static T LogFunction<T>(string who, T what) // Injected
        {
            Logs.Add(who + " <- " + what.ToString());
            return what;
        }
    }
}
