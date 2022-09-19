using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/agendaTest")]

    public class ControllerTest:ControllerBase
    {
        private readonly IAgendasServices agenda;

        public ControllerTest(IAgendasServices agenda)
        {
           
            this.agenda = agenda;
        }

        [HttpGet]
        [Route("/teste/{tenant}")]
        public async Task<IActionResult> testeData( Guid idBarbeiro, DateTime data,string dia,Guid idServico,Guid tenant )
        {
            var result =await agenda.PopularHorario(idBarbeiro,dia,data, tenant, idServico);
           
            return Ok(result);
        }
        [HttpGet]
        [Route("/testando")]
        public FrequenciaPalavras[] ContarPalavras()
        {
            var texto = "Um dois tres, vinte e quatro, vinte e cinco, trinta e três";
            
            string textoNormalizado = texto.Normalize(NormalizationForm.FormD);

            StringBuilder listaDeCaracteres = new StringBuilder();

            for (int i = 0; i < textoNormalizado.Length; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(textoNormalizado[i]);

                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    listaDeCaracteres.Append(textoNormalizado[i]);
                }
            }

            var listaPalavras = listaDeCaracteres.Replace(",", "").ToString().ToLower().Split(' ');
            
            FrequenciaPalavras[] frequenciaPalavrasObj = new FrequenciaPalavras[listaPalavras.Length];

            int totalPalavrasUsadas = 0;

            for (int i = 0; i < listaPalavras.Length; i++)
            {

                bool encontrado = false;

                for (int j = 0; j < totalPalavrasUsadas; j++)
                { 
                    if (listaPalavras[i] == frequenciaPalavrasObj[j].Palavra)
                    {
                        encontrado = true;

                        frequenciaPalavrasObj[j].Contador++;

                        break;
                    }
                }
                
                if (!encontrado)
                {
                    frequenciaPalavrasObj[totalPalavrasUsadas++] = new FrequenciaPalavras()
                    {
                        Palavra = listaPalavras[i],
                        Contador = 1
                    };
                }
            }

            FrequenciaPalavras[] listaOrdenada = frequenciaPalavrasObj.Where(n=>n !=null).OrderByDescending(x => x.Contador).ToArray();

            return listaOrdenada;
        }
        public class FrequenciaPalavras
        {
            public string Palavra { get; set; }
            public int Contador { get; set; }
        }


    }
}
