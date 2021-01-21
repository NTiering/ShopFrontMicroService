using System;
using System.Linq;
using System.Reflection;

namespace ShopFront.Common
{
    public static class AssemblyExt
    {
        public static Type[] TypesThatImplement<T>(this Assembly assembly)
        {
            var types = assembly.GetTypes()
             .Where(x => x.IsClass)
             .Where(x => x.IsAbstract == false)
             .Where(x => x.GetInterfaces().Contains(typeof(T)))
             .ToArray();

            return types;

        }
    }

}
