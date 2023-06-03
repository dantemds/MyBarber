using Aplicacao.CasosDeUso.Interfaces;
using Aplicacao.Comandos;
using Aplicacao.ObjetosDeTransferencia;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Infraestrutura.Controladores
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/relatorio")]
    public class RelatorioControladora : ControllerBase
    {
        private readonly IGerarRelatorioGeralPdf _gerarRelatorioGeralPdf;

        public RelatorioControladora(IGerarRelatorioGeralPdf gerarRelatorioGeralPdf)
        {
            _gerarRelatorioGeralPdf = gerarRelatorioGeralPdf;
        }

        [HttpPost]
        public async Task<IActionResult> ObterRelatorioGeralPdf(RelatorioGeralPdf entrada)
        {
            ComandoGerarRelatorioGeralPdf comando = new ComandoGerarRelatorioGeralPdf(entrada.Inicio, entrada.Fim);
            await _gerarRelatorioGeralPdf.Executar(comando);
            return Ok();
        }
    }
}
