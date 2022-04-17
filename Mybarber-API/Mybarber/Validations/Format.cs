using Mybarber.Exceptions;
using System;

namespace Mybarber.Validations
{
    public static class Format
    {
        public static string FormatCNPJ(string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }
        public static string SemFormatacao(string Codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(Codigo))
                    throw  new ViewException("CNPJ.Missing.Info");
                return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
