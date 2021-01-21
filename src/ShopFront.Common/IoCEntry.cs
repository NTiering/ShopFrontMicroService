using System;

namespace ShopFront.Common
{
    public class IoCEntry
    {
        public Type ImplemetationType { get; }
        public Type ServiceType { get; }

        public IoCEntry(Type serviceType, Type implemetationType)
        {
            ServiceType = serviceType;
            ImplemetationType = implemetationType;
        }

    }
   

}
