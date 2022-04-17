using System;

namespace Mybarber.Exceptions
{
    public class BusinessException : Exception
    {

        public  class CNPJException : Exception
        {
            public CNPJException(string message) : base(message) { }
        }

        public class EmailException : Exception
        {
            public EmailException(string message) : base(message) { }
        }
        public class AgendamentoException : Exception
        {
            public AgendamentoException(string message) : base(message) { }
        }
    }
}
