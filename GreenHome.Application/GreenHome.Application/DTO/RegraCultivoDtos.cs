using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.DTO
{
    public class CriarRegraCultivoDto
    {
        public string VegetalId { get; set; } = string.Empty;
        public double TemperaturaMinima { get; set; }
        public double TemperaturaMaxima { get; set; }
        public double UmidadeMinima { get; set; }
        public double UmidadeMaxima { get; set; }
        public double LuminosidadeMinima { get; set; }
        public double LuminosidadeMaxima { get; set; }
        public int CorR { get; set; }
        public int CorG { get; set; }
        public int CorB { get; set; }
        public int Intensidade { get; set; }
    }

    public class AtualizarRegraCultivoDto : CriarRegraCultivoDto
    {
    }
}
