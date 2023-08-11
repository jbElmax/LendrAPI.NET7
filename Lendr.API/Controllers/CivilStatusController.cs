using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lendr.API.Data;
using Lendr.API.Models;
using Lendr.API.DTO.CivilStatus;
using AutoMapper;

namespace Lendr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CivilStatusController : ControllerBase
    {
        private readonly LendrDBContext _context;
        private readonly IMapper _mapper;

        public CivilStatusController(LendrDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CivilStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCivilStatusesDto>>> GetCivilStatuses()
        {
          if (_context.CivilStatuses == null)
          {
              return NotFound();
          }
            var civilStatuses = await _context.CivilStatuses.ToListAsync();
            var listCivilStat = _mapper.Map<IEnumerable<GetCivilStatusesDto>>(civilStatuses);
            return Ok(listCivilStat);
        }

        // GET: api/CivilStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CivilStatusDto>> GetCivilStatus(int id)
        {
          if (_context.CivilStatuses == null)
          {
              return NotFound();
          }
            var civilStatus = await _context.CivilStatuses.Include(b => b.Borrowers).Where(c =>c.Id == id).FirstOrDefaultAsync();

            if (civilStatus == null)
            {
                return NotFound();
            }
            var civilStatusDto = _mapper.Map<CivilStatusDto>(civilStatus);  
            return Ok(civilStatusDto);
        }

        // PUT: api/CivilStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCivilStatus(int id, UpdateCivilStatusDto updateCivilStatusDto)
        {
            if (id != updateCivilStatusDto.Id)
            {
                return BadRequest();
            }

            var civilStatus =await _context.CivilStatuses.FindAsync(id);
            if(civilStatus == null)
            {
                return NotFound();
            }
            _mapper.Map(updateCivilStatusDto, civilStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CivilStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CivilStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CivilStatus>> PostCivilStatus(CreateCivilStatusDto createCivilStatus)
        {
          if (_context.CivilStatuses == null)
          {
              return Problem("Entity set 'LendrDBContext.CivilStatuses'  is null.");
          }


            var civilStatus = _mapper.Map<CivilStatus>(createCivilStatus);

            _context.CivilStatuses.Add(civilStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCivilStatus", new { id = civilStatus.Id }, civilStatus);
        }

        // DELETE: api/CivilStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCivilStatus(int id)
        {
            if (_context.CivilStatuses == null)
            {
                return NotFound();
            }
            var civilStatus = await _context.CivilStatuses.FindAsync(id);
            if (civilStatus == null)
            {
                return NotFound();
            }

            _context.CivilStatuses.Remove(civilStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CivilStatusExists(int id)
        {
            return (_context.CivilStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
