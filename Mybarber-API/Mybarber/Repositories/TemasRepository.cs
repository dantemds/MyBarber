using Mybarber.Persistencia;
using Mybarber.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class TemasRepository:ITemasRepository
    {
        private readonly Context _context;



        public TemasRepository(Context context)
        {
            _context = context;

        }
    }
}
