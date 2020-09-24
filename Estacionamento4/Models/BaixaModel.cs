﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento4.Models
{
    public class BaixaModel
    {
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string cor { get; set; }
        public DateTime entrada { get; set; }
        public DateTime saida { get; set; }
        public double tempo { get; set; }
        public float valor { get; set; }

    }
}
