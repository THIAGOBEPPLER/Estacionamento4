﻿// <auto-generated />
using System;
using Estacionamento4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Estacionamento4.Migrations
{
    [DbContext(typeof(EstacionamentoContext))]
    partial class EstacionamentoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Estacionamento4.Entities.Patio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("dataFim");

                    b.Property<DateTime>("dataInicio");

                    b.Property<double?>("tempo");

                    b.Property<float?>("valor");

                    b.Property<string>("veiculoPlaca");

                    b.HasKey("id");

                    b.HasIndex("veiculoPlaca");

                    b.ToTable("Patios");
                });

            modelBuilder.Entity("Estacionamento4.Entities.Veiculo", b =>
                {
                    b.Property<string>("placa")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("cor");

                    b.Property<string>("marca");

                    b.Property<string>("modelo");

                    b.HasKey("placa");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Estacionamento4.Entities.Patio", b =>
                {
                    b.HasOne("Estacionamento4.Entities.Veiculo", "veiculo")
                        .WithMany("patio")
                        .HasForeignKey("veiculoPlaca");
                });
#pragma warning restore 612, 618
        }
    }
}
