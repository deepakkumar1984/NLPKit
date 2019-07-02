using System;
using System.Collections.Generic;
using System.Text;

namespace NLPKit.Internals
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class DeprecatedAttribute : System.Attribute
    {
        public override bool Match(object obj)
        {
            Console.WriteLine(obj.GetType().FullName + " is deprecated!");
            return base.Match(obj);
        }
    }
}
