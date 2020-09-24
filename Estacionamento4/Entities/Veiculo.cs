using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento4.Entities
{
    public class Veiculo
    {
        [Key]
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string cor { get; set; }
        public List<Patio> patio { get; set; }

    }
}
