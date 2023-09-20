using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;
using NJsonSchema;
using NJsonSchema.Generation;

namespace SprmApi.Common.NSwag
{
    /// <summary>
    /// NSwag enum processor
    /// </summary>
    public class EnumDescriptionProcessor : ISchemaProcessor
    {
        static readonly ConcurrentDictionary<Type, Tuple<string, object>[]> s_dict = new();

        /// <summary>
        /// Start process
        /// </summary>
        /// <param name="context"></param>
        public void Process(SchemaProcessorContext context)
        {
            var schema = context.Schema;
            if (context.ContextualType.Type.IsEnum)
            {
                Tuple<string, object>[] items = GetTextValueItems(context.ContextualType.Type);
                if (items.Length > 0)
                {
                    string decription = string.Join(",", items.Select(f => $"<br>{f.Item1} = {f.Item2}"));
                    schema.Description = string.IsNullOrEmpty(schema.Description) ? decription : $"{schema.Description}:{decription}";
                }
            }
            else if (context.ContextualType.Type.IsClass && context.ContextualType.Type != typeof(string))
            {
                UpdateSchemaDescription(schema);
            }
        }

        private void UpdateSchemaDescription(JsonSchema schema)
        {
            if (!schema.HasReference)
            {
                return;
            }

            JsonSchema actualSchema = schema.ActualSchema;
            if (actualSchema != null &&
                actualSchema.Enumeration != null &&
                actualSchema.Enumeration.Count > 0 &&
                !string.IsNullOrEmpty(actualSchema.Description))
            {
                string description = $"【{actualSchema.Description}】";
                if (string.IsNullOrEmpty(schema.Description) || !schema.Description.EndsWith(description))
                {
                    schema.Description += description;
                }
            }

            foreach (string key in schema.Properties.Keys)
            {
                JsonSchemaProperty subSchema = schema.Properties[key];
                UpdateSchemaDescription(subSchema);
            }
        }

        private static Tuple<string, object>[] GetTextValueItems(Type enumType)
        {
            if (s_dict.TryGetValue(enumType, out Tuple<string, object>[]? tuples) && tuples != null)
            {
                return tuples;
            }

            Array enumValues = enumType.GetEnumValues();
            List<KeyValuePair<string, object>> list = new();
            foreach (object value in enumValues)
            {
                string? valueString = value.ToString();
                if (valueString == null)
                {
                    continue;
                }
                MemberInfo memberInfo = enumType.GetMember(valueString)[0];

                DescriptionAttribute? attribute = memberInfo.GetCustomAttribute<DescriptionAttribute>();
                if (attribute == null)
                {
                    continue;
                }
                string key = attribute.Description;

                // Get underlying type of enum
                Type enumUnderlyingType = Enum.GetUnderlyingType(value.GetType());

                // Parse enum value to underlying value
                object underlyingValue = Convert.ChangeType(value, enumUnderlyingType);

                list.Add(new KeyValuePair<string, object>(key, underlyingValue));
            }

            tuples = list.OrderBy(f => f.Value)
                .Select(f => new Tuple<string, object>(f.Key, f.Value))
                .ToArray();
            s_dict.TryAdd(enumType, tuples);
            return tuples;
        }
    }
}
