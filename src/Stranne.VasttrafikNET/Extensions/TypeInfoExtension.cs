using System;
using System.Reflection;

namespace Stranne.VasttrafikNET.Extensions
{
    internal static class TypeInfoExtension
    {
        public static Type[] GenericArguments(this TypeInfo typeInfo)
        {
            return typeInfo.IsGenericTypeDefinition
                ? typeInfo.GenericTypeParameters
                : typeInfo.GenericTypeArguments;
        }
    }
}
