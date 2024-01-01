using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4C.Model
{
    public class History
    {
        [JsonProperty("priceUsd")]
        public double PriceUsd { get; set; }
        [JsonProperty("time")]
        public long TimeUnix { get; set; }

        [JsonIgnore]
        public DateTime Time
        {
            get { return DateTimeOffset.FromUnixTimeMilliseconds(TimeUnix).UtcDateTime; }
        }
    }
}
