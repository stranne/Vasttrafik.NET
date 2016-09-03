using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Extensions;

namespace Stranne.VasttrafikNET.Converters
{
    internal class SingleListJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var itemType = objectType.GetTypeInfo().GetGenericArguments()[0];
            var listType = typeof(List<>);
            var constructedType = listType.MakeGenericType(itemType);

            if (reader.TokenType == JsonToken.StartArray)
            {
                return serializer.Deserialize(reader, constructedType);
            }
            
            var item = serializer.Deserialize(reader, itemType);

            var list = (IList)Activator.CreateInstance(constructedType);
            list.Add(item);

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
