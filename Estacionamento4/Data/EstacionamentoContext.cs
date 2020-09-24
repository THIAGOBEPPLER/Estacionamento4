using Estacionamento4.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento4.Data
{
    public class EstacionamentoContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Patio> Patios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=1234;Persist Security Info=True;User ID=sa;Initial Catalog=Estacionamento4;Data Source=DESKTOP-2EBCKJD\\SQLEXPRESS");
        }
    }
}
