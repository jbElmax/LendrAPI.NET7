using AutoMapper;
using Lendr.API.Core.Contracts;
using Lendr.API.Data;
using Lendr.API.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Lendr.API.Core.Repository
{
    public class CivilStatusRepository :GenericRepository<CivilStatus>,ICivilStatusRepository
    {
        private readonly LendrDBContext _context;
        private readonly IMapper _mapper;

        public CivilStatusRepository(LendrDBContext context,IMapper mapper):base(context, mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public async Task<CivilStatus> GetDetails(int id)
        {
            return  await _context.CivilStatuses.Include(b => b.Borrowers).Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
