using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordGrid.Models
{
    public interface IGridCharRepository
    {
        IQueryable<GridChar> GridChars { get; }
        void Save();

    }

    public class EFGridCharRepository : IGridCharRepository
    {
        private ApplicationDbContext _context;

        public EFGridCharRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<GridChar> GridChars => _context.GridChars;
    }
}
