using System;
using System.Linq;
using System.Reflection;

namespace MvvmLightUwpExample.Helpers.Extensions
{
    public static class TypeExtensions
    {
        public static bool ImplementsInterface(this Type type, Type interfaceType)
        {
            return type.GetInterfaces().Any(i => i.FullName == interfaceType.FullName);
        }
    }
}
