using System;

namespace Mybarber.Helpers
{
    public class PageParams
    {

        public const int MaxPageSize = 36;

        public int PageNumber { get; set; } = 1;

        private int pageSize = 35;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public string NomeBarbeiro { get; set; }

        public string NomeServico { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        
        
        


    }
}
