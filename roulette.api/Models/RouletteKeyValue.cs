using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using roulette.api.Repository;

namespace roulette.api.Models
{
    public class RouletteKeyValue : IIdentifable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]// this one makes it possible to keep Id property as string
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("key")]
        public string Key { get; set; }

        [BsonElement("value")]
        public string Value { get; set; }
    }
}