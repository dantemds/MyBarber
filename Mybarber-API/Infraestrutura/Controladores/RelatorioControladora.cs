﻿using Aplicacao.CasosDeUso.Interfaces;
using Aplicacao.Comandos;
using Aplicacao.ObjetosDeTransferencia;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Mime;

namespace Infraestrutura.Controladores
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/relatorio")]
    public class RelatorioControladora : ControllerBase
    {
        private readonly IGerarRelatorioGeralPdf _gerarRelatorioGeralPdf;
        private readonly IGerarRelatorioGeralJson _gerarRelatorioGeralJson;

        public RelatorioControladora(IGerarRelatorioGeralPdf gerarRelatorioGeralPdf, IGerarRelatorioGeralJson gerarRelatorioGeralJson)
        {
            _gerarRelatorioGeralPdf = gerarRelatorioGeralPdf;
            _gerarRelatorioGeralJson = gerarRelatorioGeralJson; 
        }

        [HttpPost("pdf/{idBarbearia}")]
        public async Task<IActionResult> ObterRelatorioGeralPdf(RelatorioGeralPdf entrada)
        {
            ComandoGerarRelatorioGeralPdf comando = new ComandoGerarRelatorioGeralPdf(entrada.Inicio, entrada.Fim, entrada.BarbeariaId);
            byte[] relatorioBytes = await _gerarRelatorioGeralPdf.Executar(comando);
            var tipoConteudo = MediaTypeNames.Application.Pdf;

            var stream = new MemoryStream(relatorioBytes);

            var resultado = new FileStreamResult(stream, new MediaTypeHeaderValue("application/pdf").ToString());
            Response.ContentType = new MediaTypeHeaderValue("application/pdf").ToString();
            resultado.FileDownloadName = "relatorio.pdf";
            return Ok();
        }

        [HttpPost("{idBarbearia}")]
        public async Task<IActionResult> ObterRelatorioGeralJson(RelatorioGeralPdf entrada)
        {
            ComandoGerarRelatorioJson comando = new ComandoGerarRelatorioJson(entrada.Inicio, entrada.Fim, entrada.BarbeariaId);
            return Ok(await _gerarRelatorioGeralJson.Executar(comando));
        }
    }
}
