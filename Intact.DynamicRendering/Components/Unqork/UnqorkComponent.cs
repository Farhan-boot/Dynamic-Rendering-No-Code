namespace Intact.DynamicRendering.Components.Unqork
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;


    public abstract class UnqorkComponent
    {
        public string Key { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // set per UnqorkComponent
        public bool Persistent { get; set; }
        public string CustomClass { get; set; } = string.Empty; // likely not going to change
        public List<string> Ancestors { get; set; } = [];
    }

    public class DataObjectType
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }


    class ObjectTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<DataObjectType>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            return existingValue ?? string.Empty;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            JObject jo = [];

            if (value != null)
            {
                List<DataObjectType> decisionObjectTypes = (List<DataObjectType>)value;
                foreach (var decisionObjectType in decisionObjectTypes)
                {
                    jo.Add(decisionObjectType.Key, decisionObjectType.Value);
                }
            }
            jo.WriteTo(writer);
        }

        public static class UnqorkComponentConverter
        {
            public static readonly JsonSerializerSettings Settings = new()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = {
                    ObjectTypeConverter.objectTypeConverter
                },
            };
        }

        public static readonly ObjectTypeConverter objectTypeConverter = new();

    }
}
