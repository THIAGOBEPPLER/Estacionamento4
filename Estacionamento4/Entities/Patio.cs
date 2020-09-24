﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento4.Entities
{
    public class Patio
    {
        [Key]
        public int id { get; set; }
        public DateTime dataInicio { get; set; }
        public Nullable<DateTime> dataFim { get; set; }
        public Nullable<double> tempo { get; set; }
        public Nullable<float> valor { get; set; }

        public string veiculoPlaca { get; set; }
        public Veiculo veiculo { get; set; }

    }
}
