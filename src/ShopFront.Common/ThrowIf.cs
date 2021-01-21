using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ShopFront.Common
{
    public static class ThrowIf
    {
        public static class Argument
        {
            public static void IsNull<T>(T argument, string name, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
            {
                if (argument is null)
                {
                    throw new ArgumentException($"Method '{memberName}' at line {sourceLineNumber} in {sourceFilePath.Split("\\").Last()} had a null parameter for the value '{name}'");
                }
            }

            public static void IsNullOrEmpty(string argument, string name, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
            {
                if (string.IsNullOrWhiteSpace(argument))
                {
                    throw new ArgumentException($"Method '{memberName}' at line {sourceLineNumber} in {sourceFilePath.Split("\\").Last()} had a null or empty string for the value '{name}'");

                }
            }

            public static void IsZero(int i, string varibleName)
            {
                if (i == 0) throw new ArgumentException($"{varibleName} cannot be zero");
            }
        }
    }
}
