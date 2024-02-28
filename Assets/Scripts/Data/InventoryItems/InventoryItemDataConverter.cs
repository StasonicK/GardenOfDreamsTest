using System;
using Data.InventoryItems.ItemDatas;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Data.InventoryItems
{
    public class InventoryItemDataConverter : JsonConverter<InventoryItemData>
    {
        public override void WriteJson(JsonWriter writer, InventoryItemData value, JsonSerializer serializer)
        {
            JObject jObject = new JObject();
            var type = value.GetType();
            var fields = type.GetFields();
            foreach (var field in fields)
            {
                jObject.Add(field.Name, field.GetValue(value).ToString());
            }

            jObject.Add("Type", type.Name);
            jObject.WriteTo(writer);
        }

        public override InventoryItemData ReadJson(JsonReader reader, Type objectType, InventoryItemData existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var type = jObject.GetValue("Type");
            var result = GetSpecialType(type.ToString());
            var targetType = result.GetType();
            foreach (var field in targetType.GetFields())
            {
                if (jObject.TryGetValue(field.Name, out JToken value))
                {
                    field.SetValue(result, value.ToObject(field.FieldType));
                }
            }

            return result;
        }

        private InventoryItemData GetSpecialType(string type)
        {
            switch (type)
            {
                case "AmmoInventoryItemData":
                    return new AmmoInventoryItemData();
                case "EmptyInventoryItemData":
                    return new EmptyInventoryItemData();
                case "HeadgearInventoryItemData":
                    return new HeadgearInventoryItemData();
                case "MedicineInventoryItemData":
                    return new MedicineInventoryItemData();
                case "OuterwearInventoryItemData":
                    return new OuterwearInventoryItemData();
                default:
                    throw new Exception("Unknown type");
            }
        }
    }
}