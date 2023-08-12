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
using Lendr.API.Contracts;

namespace Lendr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CivilStatusController : ControllerBase
    {
        private readonly ICivilStatusRepository _civilStatusRepository;
        private readonly IMapper _mapper;

        public CivilStatusController(ICivilStatusRepository civilStatusRepository,IMapper mapper)
        {
            _civilStatusRepository = civilStatusRepository;
            _mapper = mapper;
        }

        // GET: api/CivilStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCivilStatusesDto>>> GetCivilStatuses()
        {

            var civilStatuses = await _civilStatusRepository.GetAllAsync();
            var listCivilStat = _mapper.Map<IEnumerable<GetCivilStatusesDto>>(civilStatuses);
            return Ok(listCivilStat);
        }

        // GET: api/CivilStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CivilStatusDto>> GetCivilStatus(int id)
        {

            var civilStatus = await _civilStatusRepository.GetDetails(id);

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

            var civilStatus =await _civilStatusRepository.GetAsync(id);
            if(civilStatus == null)
            {
                return NotFound();
            }
             _mapper.Map(updateCivilStatusDto, civilStatus);
            
            try
            {
                await _civilStatusRepository.UpdateAsync(civilStatus);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CivilStatusExists(id))
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

            var civilStatus = _mapper.Map<CivilStatus>(createCivilStatus);
            await _civilStatusRepository.AddAsync(civilStatus);


            return CreatedAtAction("GetCivilStatus", new { id = civilStatus.Id }, civilStatus);
        }

        // DELETE: api/CivilStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCivilStatus(int id)
        {
            var civilStatus = await _civilStatusRepository.GetAsync(id);
            if (civilStatus == null)
            {
                return NotFound();
            }
             await _civilStatusRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CivilStatusExists(int id)
        {
            return await _civilStatusRepository.Exists(id);
            
        }
    }
}
