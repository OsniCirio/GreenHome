using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHome.Application.DTO
{
    public class TelemetriaRequestDto
    {
        public string DeviceId { get; set; } = string.Empty;
        public double Temperatura { get; set; }
        public double Umidade { get; set; }
        public double Luminosidade { get; set; }
    }

    public class ComandoLedResponseDto
    {
        public bool LigarLed { get; set; }
        public int Intensidade { get; set; }
        public int CorR { get; set; }
        public int CorG { get; set; }
        public int CorB { get; set; }
        public string Modo { get; set; } = "automatico";
        public string Mensagem { get; set; } = string.Empty;
    }
}
