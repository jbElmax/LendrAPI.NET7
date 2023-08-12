using Lendr.API.Contracts;
using Lendr.API.Data;
using Lendr.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Lendr.API.Repository
{
    public class CivilStatusRepository :GenericRepository<CivilStatus>,ICivilStatusRepository
    {
        private readonly LendrDBContext _context;

        public CivilStatusRepository(LendrDBContext context):base(context)
        {
            _context = context;
        }

        public async Task<CivilStatus> GetDetails(int id)
        {
            return  await _context.CivilStatuses.Include(b => b.Borrowers).Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
