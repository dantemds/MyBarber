﻿using Aplicacao.Comandos;
using Aplicacao.ObjetosDeTransferencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.CasosDeUso.Interfaces
{
    public interface IGerarRelatorioGeralJson
    {
        Task<RelatorioGeralJson> Executar(ComandoGerarRelatorioJson comando);
    }
}