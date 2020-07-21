using System;
using MongoDB.Bson.Serialization.Attributes;

namespace CzechifyNetCore.Models
{
    [BsonIgnoreExtraElements]
    public class RecentSearch
    {
        [BsonElement("Timestamp")]
        public DateTime Timestamp { get; set; }
        [BsonElement("OriginalText")]
        public string OriginalText { get; set; }
        [BsonElement("AdaptedText")]
        public string AdaptedText { get; set; }

        public override string ToString()
        {
            return $"{Timestamp}: {OriginalText} -> {AdaptedText}";
        }
    }
}
