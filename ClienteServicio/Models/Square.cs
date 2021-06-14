using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ClienteServicio.Models
{
    public partial class Square
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("side")]
        public long Side { get; set; }

        [JsonProperty("area")]
        public long Area { get; set; }

        [JsonProperty("perimeter")]
        public long Perimeter { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        public Square(long side)
        {
            this.Side = side;
        }

    }
    public partial class Square
    {
        public static Square FromJson(string json) => JsonConvert.DeserializeObject<Square>(json, ClienteServicio.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Square self) => JsonConvert.SerializeObject(self, ClienteServicio.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
