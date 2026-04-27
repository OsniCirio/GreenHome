using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.DTO
{
  

    public class CriarVegetalDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
    }

    public class AtualizarVegetalDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
    }
}
