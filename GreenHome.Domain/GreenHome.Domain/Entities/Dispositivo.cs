using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Domain.Entities
{
    public class Dispositivo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("deviceId")]
        public string DeviceId { get; set; } = string.Empty;

        [BsonElement("vegetalId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string VegetalId { get; set; } = string.Empty;

        [BsonElement("localizacao")]
        public string? Localizacao { get; set; }

        [BsonElement("ativo")]
        public bool Ativo { get; set; } = true;

        [BsonElement("dataCriacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [BsonElement("dataAtualizacao")]
        public DateTime? DataAtualizacao { get; set; }
    }
}
