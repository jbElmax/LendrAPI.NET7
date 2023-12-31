﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lendr.API.Data;
using Lendr.API.Models;
using Lendr.API.Core.Contracts;
using AutoMapper;
using System.Collections;
using Lendr.API.Core.DTO.Borrower;
using Microsoft.AspNetCore.Authorization;
using Lendr.API.Core.Exceptions;

using Lendr.API.Core.Models;

namespace Lendr.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/borrowers")]
    [ApiVersion("1.0",Deprecated = true)]
    [ApiController]
    
    [Authorize]
    public class BorrowersController : ControllerBase
    {
        private readonly IBorrowerRepository _borrowerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BorrowersController> _logger;

        public BorrowersController(IBorrowerRepository borrowerRepository, IMapper mapper,ILogger<BorrowersController> logger)
        {

            _borrowerRepository = borrowerRepository;
            _mapper = mapper;
            this._logger = logger;
        }

        // GET: api/Borrowers/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<BorrowerDto>>> GetBorrowers()
        {
            var borrowers =await _borrowerRepository.GetAllAsync<BorrowerDto>();
            //var borrowerList = _mapper.Map<IEnumerable<BorrowerDto>>(borrowers);
            return Ok(borrowers);
        }
        // GET: api/Borrowers/?StartIndex=0&pageSize=25&PageNumber=1
        [HttpGet]
        public async Task<ActionResult<PagedResult<BorrowerDto>>> GetPagedBorrowers([FromQuery] QueryParameters queryParameters)
        {
            var pagedBorrowerResult = await _borrowerRepository.GetAllAsync<BorrowerDto>(queryParameters);
            //var borrowerList = _mapper.Map<IEnumerable<BorrowerDto>>(borrowers);
            return Ok(pagedBorrowerResult);
        }

        // GET: api/Borrowers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetBorrowerDto>> GetBorrower(int id)
        {
            var borrower = await _borrowerRepository.GetDetails(id);
            return Ok(borrower);
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

            try
            {
                await _borrowerRepository.UpdateAsync(id, borrower);
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
        public async Task<ActionResult<BorrowerDto>> PostBorrower(CreateBorrowerDto newBorrower)
        {
            var borrower = await _borrowerRepository.AddAsync<CreateBorrowerDto,BorrowerDto>(newBorrower);
            return CreatedAtAction("GetBorrower", new { id = borrower.Id }, borrower);
        }

        // DELETE: api/Borrowers/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteBorrower(int id)
        {

            await _borrowerRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> BorrowerExists(int id)
        {
            return await _borrowerRepository.Exists(id);

        }
    }
}
