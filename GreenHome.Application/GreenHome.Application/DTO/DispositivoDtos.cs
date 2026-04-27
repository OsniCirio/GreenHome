using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.DTO
{
    public class CriarDispositivoDto
    {
        public string Nome { get; set; } = string.Empty;
        public string DeviceId { get; set; } = string.Empty;
        public string VegetalId { get; set; } = string.Empty;
        public string? Localizacao { get; set; }
    }

    public class AtualizarDispositivoDto
    {
        public string Nome { get; set; } = string.Empty;
        public string VegetalId { get; set; } = string.Empty;
        public string? Localizacao { get; set; }
        public bool Ativo { get; set; }
    }
}
