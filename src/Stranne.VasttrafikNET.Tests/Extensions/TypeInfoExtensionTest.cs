using System.Collections.Generic;
using System.Reflection;
using Stranne.VasttrafikNET.Extensions;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Extensions
{
    public class TypeInfoExtensionTest
    {
        [Fact]
        public void GenericTypeParameters()
        {
            var data = new KeyValuePair<string, int>();

            var actual = data.GetType().GetGenericTypeDefinition().GetTypeInfo().GenericArguments();

            Assert.Equal(2, actual.Length);
            Assert.Equal("TKey", actual[0].Name);
            Assert.Equal("TValue", actual[1].Name);
        }

        [Fact]
        public void GenericTypeArguments()
        {
            var data = new KeyValuePair<string, int>();

            var actual = data.GetType().GetTypeInfo().GenericArguments();

            Assert.Equal(2, actual.Length);
            Assert.Equal(typeof(string), actual[0]);
            Assert.Equal(typeof(int), actual[1]);
        }
    }
}
