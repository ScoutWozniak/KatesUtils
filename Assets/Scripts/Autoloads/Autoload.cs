using System;

namespace Autoloads
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoloadAttribute : Attribute
    {
        public string Name { get; set; }

        public AutoloadAttribute(string name)
        {
            Name = name;
        }
    }
}