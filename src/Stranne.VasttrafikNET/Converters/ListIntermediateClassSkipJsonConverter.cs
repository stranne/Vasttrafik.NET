using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stranne.VasttrafikNET.Extensions;

namespace Stranne.VasttrafikNET.Converters
{
    internal class ListIntermediateClassSkipJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var data = JObject.Load(reader);

            var itemType = objectType.GetTypeInfo().GenericArguments()[0];
            var listType = typeof(List<>);
            var constructedType = listType.MakeGenericType(itemType);
            var list = (IList)Activator.CreateInstance(constructedType);

            if (data.First.First.Type == JTokenType.Object)
            {
                var stringReader = new StringReader(data.First.First.ToString());
                var item = serializer.Deserialize(stringReader, itemType);
                list.Add(item);
                return list;
            }

            var array = (JArray)data.First.First;
            foreach (var token in array)
            {
                var item = serializer.Deserialize(new JTokenReader(token), itemType);
                list.Add(item);
            }

            return list;
        }

        public override bool CanConvert(Type objectType)
        {
            return
                objectType.GetTypeInfo().IsGenericType &&
                objectType.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }

        public override bool CanWrite => false;
    }
}
