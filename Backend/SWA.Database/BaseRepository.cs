
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



