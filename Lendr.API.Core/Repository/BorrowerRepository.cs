using AutoMapper;
using AutoMapper.QueryableExtensions;
using Lendr.API.Core.Contracts;
using Lendr.API.Core.DTO.Borrower;
using Lendr.API.Core.Exceptions;
using Lendr.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Lendr.API.Core.Repository
{
    public class BorrowerRepository:GenericRepository<Borrower>,IBorrowerRepository
    {
        private readonly LendrDBContext _context;
        private readonly IMapper _mapper;

        public BorrowerRepository(LendrDBContext context,IMapper mapper):base(context, mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public async Task<BorrowerDto> GetDetails(int id)
        {
            var borrower = await _context.Borrowers.Include(c => c.CivilStatus)
                .ProjectTo<BorrowerDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (borrower == null)
            {
                throw new NotFoundException(nameof(GetDetails),id);
            }
            return borrower;
        }
    }
}
