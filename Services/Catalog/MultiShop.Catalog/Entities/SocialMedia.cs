using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class SocialMedia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SocialMediaId { get; set; }
        public string SocialMediaName { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
    }
}
