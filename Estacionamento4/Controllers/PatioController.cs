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
    [Route("api/patio")]
    [ApiController]
    public class PatioController : ControllerBase
    {
        EstacionamentoContext bd = new EstacionamentoContext();


        [HttpPut("entrada/{placa}")]
        public ActionResult<string> Entrada(string placa)
        {
            var patio = new Patio();

            var verificaCadastro =
                (from v in bd.Veiculos
                 where (v.Placa == placa)
                 select v);

            if (!verificaCadastro.Any())
                return BadRequest("Veiculo nao cadastrado!");


            var verificaAtivo =
                (from p in bd.Patios
                 where p.VeiculoPlaca == placa && p.DataFim == null
                 select p);



            if (verificaAtivo.Any())
                return BadRequest("Veiculo ja esta no patio!");

            var dataAtual = DateTime.Now;

            patio.DataInicio = dataAtual;
            patio.VeiculoPlaca = placa;

            bd.Add(patio);
            bd.SaveChanges();

            return Ok("Veiculo adicionado ao Patio!");

        }

        [HttpPut("baixa/{placa}")]
        public ActionResult<BaixaModel> Baixa(string placa)
        {
            var veiculo = new Veiculo();
            var patio = new Patio();

            var query =
                (from p in bd.Patios
                 where p.VeiculoPlaca == placa && p.DataFim == null
                 select p).SingleOrDefault();

            if (query == null)
                return BadRequest("Esse veiculo nao esta no patio!");

            patio = query;

            var dataAtual = DateTime.Now;
            double duracao;
            float valor;
            TimeSpan castDuracao;
            DateTime dataIni;

            dataIni = patio.DataInicio;

            castDuracao = dataAtual - dataIni;

            duracao = (int)castDuracao.TotalMinutes;

            if (duracao <= 30)
                valor = 5;
            else
            {
                valor = (int)(duracao / 30) * 5;
            }

            patio.Tempo = duracao;
            patio.DataFim = dataAtual;
            patio.Valor = valor;

            bd.Update(patio);
            bd.SaveChanges();

            // var teste = patio.veiculoPlaca;

            var saida =
                (from p in bd.Patios
                 join v in bd.Veiculos on p.VeiculoPlaca equals v.Placa
                 where v.Placa == placa && p.Id == patio.Id

                 select new BaixaModel
                 {
                     placa = v.Placa,
                     marca = v.Marca,
                     modelo = v.Modelo,
                     cor = v.Cor,
                     entrada = p.DataInicio,
                     saida = p.DataFim.Value,
                     tempo = p.Tempo.Value,
                     valor = p.Valor.Value
                 }).SingleOrDefault();


            return Ok(saida);
        }
    }
}
