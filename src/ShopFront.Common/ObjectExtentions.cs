using System;

namespace ShopFront.Common
{
    public static class ObjectExtentions
    {
        public static Tout As<Tout>(this object obj) where Tout : class
        {
            try
            {
                return (Tout)obj;
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException($"Unable to cast {obj.GetType().FullName} as {typeof(Tout).FullName}");
            }
        }
    }
}
