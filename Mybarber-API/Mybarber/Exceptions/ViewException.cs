using System;

namespace Mybarber.Exceptions
{
    public class ViewException:Exception
    {
        public ViewException(string message) : base(message)
        {

        }
        public ViewException(string message, string ex) : base(message)
        {

        }

        public class DbException : Exception
        {
            public DbException(string message) : base(message)
            {

            }
            public DbException(string message, string ex) : base(message)
            {
                
            }

        }
    }
}
