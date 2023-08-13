using Lendr.API.Contracts;
using Lendr.API.Data;
using Lendr.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Lendr.API.Repository
{
    public class BorrowerRepository:GenericRepository<Borrower>,IBorrowerRepository
    {
        private readonly LendrDBContext _context;

        public BorrowerRepository(LendrDBContext context):base(context)
        {
            _context = context;
        }

        public async Task<Borrower> GetDetails(int id)
        {
            var borrower = await _context.Borrowers.Include(c => c.CivilStatus).SingleOrDefaultAsync(b => b.Id == id);
            if (borrower == null)
            {
                return null;
            }
            return borrower;
        }
    }
}
