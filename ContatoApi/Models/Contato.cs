using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContatoApi.Models
{
    public class Contato
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Telefone")]
        public long Telefone { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }
    }
}
