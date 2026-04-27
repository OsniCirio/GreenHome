using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Domain.Entities
{

    public class LeituraSensor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("deviceId")]
        public string DeviceId { get; set; } = string.Empty;

        [BsonElement("temperatura")]
        public double Temperatura { get; set; }

        [BsonElement("umidade")]
        public double Umidade { get; set; }

        [BsonElement("luminosidade")]
        public double Luminosidade { get; set; }

        [BsonElement("dataLeitura")]
        public DateTime DataLeitura { get; set; } = DateTime.UtcNow;
    }
}
