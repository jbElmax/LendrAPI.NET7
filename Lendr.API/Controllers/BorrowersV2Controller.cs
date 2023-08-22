using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lendr.API.Data;
using Lendr.API.Core.Contracts;
using AutoMapper;
using System.Collections;
using Lendr.API.Core.DTO.Borrower;
using Microsoft.AspNetCore.Authorization;
using Lendr.API.Core.Exceptions;
using Microsoft.AspNetCore.OData.Query;
using Lendr.API.Models;

namespace Lendr.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/borrowers")]
    [ApiVersion("2.0")]
    [ApiController]
    
    [Authorize]
    public class BorrowersV2Controller : ControllerBase
    {
        private readonly IBorrowerRepository _borrowerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BorrowersV2Controller> _logger;

        public BorrowersV2Controller(IBorrowerRepository borrowerRepository, IMapper mapper,ILogger<BorrowersV2Controller> logger)
        {

            _borrowerRepository = borrowerRepository;
            _mapper = mapper;
            this._logger = logger;
        }

        // GET: api/Borrowers
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<BorrowerDto>>> GetBorrowers()
        {
            var borrowers =await _borrowerRepository.GetAllAsync();
            var borrowerList = _mapper.Map<IEnumerable<BorrowerDto>>(borrowers);
            return Ok(borrowerList);
        }

        // GET: api/Borrowers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetBorrowerDto>> GetBorrower(int id)
        {

            var borrower = await _borrowerRepository.GetDetails(id);

            if (borrower == null)
            {
                //_logger.LogWarning($"No records found in {nameof(GetBorrower)}");
                //return NotFound();
                throw new NotFoundException(nameof(GetBorrower), id);
            }
            var borrowerDetails = _mapper.Map<GetBorrowerDto>(borrower);
            return borrowerDetails;
        }

        // PUT: api/Borrowers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles ="Administrator")]
        public async Task<IActionResult> PutBorrower(int id, BorrowerDto borrower)
        {
            if (id != borrower.Id)
            {
                return BadRequest();
            }
            var resultBorrower = await _borrowerRepository.GetAsync(id);
            if (resultBorrower == null)
            {
                return NotFound();
            }
            _mapper.Map(borrower, resultBorrower);
            try
            {
                await _borrowerRepository.UpdateAsync(resultBorrower);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BorrowerExists(id))
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

        // POST: api/Borrowers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Borrower>> PostBorrower(CreateBorrowerDto newBorrower)
        {
          if (newBorrower == null)
          {
                return BadRequest();
          }
            var formattedBorrower = _mapper.Map<Borrower>(newBorrower);
            await _borrowerRepository.AddAsync(formattedBorrower);


            return CreatedAtAction("GetBorrower", new { id = formattedBorrower.Id }, formattedBorrower);
        }

        // DELETE: api/Borrowers/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteBorrower(int id)
        {
            var borrower = await _borrowerRepository.GetAsync(id);
            if (borrower == null)
            {
                return NotFound();
            }
            await _borrowerRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> BorrowerExists(int id)
        {
            return await _borrowerRepository.Exists(id);

        }
    }
}
