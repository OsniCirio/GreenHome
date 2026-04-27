using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Domain.Entities
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;

        public string VegetaisCollectionName { get; set; } = "vegetais";
        public string RegrasCollectionName { get; set; } = "regrasCultivo";
        public string DispositivosCollectionName { get; set; } = "dispositivos";
    }
}
