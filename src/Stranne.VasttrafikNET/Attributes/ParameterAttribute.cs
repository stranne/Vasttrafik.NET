using System;

namespace Stranne.VasttrafikNET.Attributes
{
    internal class ParameterAttribute : Attribute
    {
        internal readonly string ParameterName;
        internal readonly object DefaultValue;
        internal readonly bool Required;
        internal readonly bool QueryString;
        internal readonly int Order;
        
        public ParameterAttribute(string parameterName = null, object defaultValue = null, bool required = false, bool queryString = true, int order = 0)
        {
            ParameterName = parameterName;
            DefaultValue = defaultValue;
            Required = required;
            QueryString = queryString;
            Order = order;
        }
    }
}
