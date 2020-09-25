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

        [HttpGet("verificaPlaca/{placa}")]
        public ActionResult<VerificaModel> VerificaPlaca(string placa)
        {
            var carro = new Veiculo();

            var query =
                (from v in bd.Veiculos
                 where (v.Placa == placa)
                 select new VerificaModel { placa = v.Placa, marca = v.Marca, modelo = v.Modelo, cor = v.Cor }).SingleOrDefault();

            return Ok(query);
        }

        [HttpPut("adiciona/{placa}")]
        public ActionResult<string> Adiciona([FromBody] AdicionaModel request)
        {
            var placa = request.placa;

            var veiculo = new Veiculo();


            var query =
                (from v in bd.Veiculos
                 where (v.Placa == placa)
                 select v.Placa).Any();

            if (query == true)
            {
                return BadRequest("Veiculo ja existente!");
            }

            veiculo.Placa = request.placa;
            veiculo.Marca = request.marca;
            veiculo.Modelo = request.modelo;
            veiculo.Cor = request.cor;

            bd.Veiculos.Add(veiculo);
            bd.SaveChanges();


            return Ok("Veiculo Adicionado!");
        }

        [HttpGet("ativos")]
        public List<AtivosModel> Ativos()
        {
            var query =
                (from p in bd.Patios
                 join v in bd.Veiculos on p.VeiculoPlaca equals v.Placa
                 where p.DataFim == null
                 select new AtivosModel { placa = v.Placa, marca = v.Marca, modelo = v.Modelo, cor = v.Cor, entrada = p.DataInicio }).ToList();

            return query;
        }
    }
}

