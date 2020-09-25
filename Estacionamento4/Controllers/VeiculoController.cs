using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento4.Data;
using Estacionamento4.Entities;
using Estacionamento4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento4.Controllers
{
    [Route("api/veiculo")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        EstacionamentoContext bd = new EstacionamentoContext();

        [HttpGet("{placa}")]
        public ActionResult<VerificaModel> VerificaPlaca(string placa)
        {
            var carro = new Veiculo();

            var query =
                (from v in bd.Veiculos
                 where (v.Placa == placa)
                 select new VerificaModel { Placa = v.Placa, Marca = v.Marca, Modelo = v.Modelo, Cor = v.Cor }).SingleOrDefault();

            return Ok(query);
        }

        [HttpPost("{placa}")]
        public ActionResult<string> Adiciona([FromBody] AdicionaModel request)
        {
            var placa = request.Placa;

            var veiculo = new Veiculo();


            var query =
                (from v in bd.Veiculos
                 where (v.Placa == placa)
                 select v.Placa).Any();

            if (query == true)
            {
                return BadRequest("Veiculo ja existente!");
            }

            veiculo.Placa = request.Placa;
            veiculo.Marca = request.Marca;
            veiculo.Modelo = request.Modelo;
            veiculo.Cor = request.Cor;

            bd.Veiculos.Add(veiculo);
            bd.SaveChanges();


            return Ok("Veiculo Adicionado!");
        }

        [HttpGet]
        public List<AtivosModel> Ativos()
        {
            var query =
                (from p in bd.Patios
                 join v in bd.Veiculos on p.VeiculoPlaca equals v.Placa
                 where p.DataFim == null
                 select new AtivosModel { Placa = v.Placa, Marca = v.Marca, Modelo = v.Modelo, Cor = v.Cor, Entrada = p.DataInicio }).ToList();

            return query;
        }
    }
}

