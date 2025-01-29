using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SwaggerWebApp.Models
{
    public class Course
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

        public string Name { get; set; } = "";
        public int Score { get; set; } = 0;
    }
}
