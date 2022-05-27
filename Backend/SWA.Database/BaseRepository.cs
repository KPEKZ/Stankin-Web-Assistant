using System;
using System.Collections.Generic;
using System.Linq;
namespace SWA.Database
{
    public class BaseRepository
    {
        protected readonly SWADbContext? _context;
        public BaseRepository(SWADbContext context)
        {
            _context = context;
        }
    }
}



