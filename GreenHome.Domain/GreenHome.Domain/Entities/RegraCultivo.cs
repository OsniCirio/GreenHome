using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace GreenHome.Domain.Entities
{


   

    public class RegraCultivo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("vegetalId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string VegetalId { get; set; } = string.Empty;

        [BsonElement("temperaturaMinima")]
        public double TemperaturaMinima { get; set; }

        [BsonElement("temperaturaMaxima")]
        public double TemperaturaMaxima { get; set; }

        [BsonElement("umidadeMinima")]
        public double UmidadeMinima { get; set; }

        [BsonElement("umidadeMaxima")]
        public double UmidadeMaxima { get; set; }

        [BsonElement("luminosidadeMinima")]
        public double LuminosidadeMinima { get; set; }

        [BsonElement("luminosidadeMaxima")]
        public double LuminosidadeMaxima { get; set; }

        [BsonElement("corR")]
        public int CorR { get; set; }

        [BsonElement("corG")]
        public int CorG { get; set; }

        [BsonElement("corB")]
        public int CorB { get; set; }

        [BsonElement("intensidade")]
        public int Intensidade { get; set; }

        [BsonElement("ativo")]
        public bool Ativo { get; set; } = true;

        [BsonElement("dataCriacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [BsonElement("dataAtualizacao")]
        public DateTime? DataAtualizacao { get; set; }
    }
}
