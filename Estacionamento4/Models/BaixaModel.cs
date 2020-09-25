using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento4.Models
{
    public class BaixaModel
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public double Tempo { get; set; }
        public float Valor { get; set; }

    }
}
