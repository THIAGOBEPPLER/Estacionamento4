using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento4.Entities
{
    public class Patio
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public Nullable<DateTime> DataFim { get; set; }
        public Nullable<double> Tempo { get; set; }
        public Nullable<float> Valor { get; set; }

        public string VeiculoPlaca { get; set; }
        public Veiculo Veiculo { get; set; }

    }
}
