﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IHashSenha
    {
        byte[] BagunçarSenha(string password);
        bool VerificarSenha(string password);
    }
}