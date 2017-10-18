﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Binance.Net.Objects;

namespace Binance.Net.Converters
{
    public class OrderTypeConverter : JsonConverter
    {
        private Dictionary<OrderType, string> values = new Dictionary<OrderType, string>()
        {
            { OrderType.Limit, "LIMIT" },
            { OrderType.Market, "MARKET" },
        };

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(OrderType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return values.Single(v => v.Value == (string)reader.Value).Key;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(values[(OrderType)value]);
        }
    }
}