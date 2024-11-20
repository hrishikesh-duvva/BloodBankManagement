using BloodBankManagement.DTOS;
using BloodBankManagement.Models;
using BloodBankManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodBankController : ControllerBase
    {
        private readonly BloodBankService _service;

        public BloodBankController(BloodBankService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var entry = _service.GetById(id);
            if (entry == null) return NotFound();
            return Ok(entry);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BloodBankEntry entry)
        {
            _service.Add(entry);
            return CreatedAtAction(nameof(GetById), new { id = entry.Id }, entry);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] BloodBankEntry entry)
        {
            var existing = _service.GetById(id);
            if (existing == null) return NotFound();

            _service.Update(id, entry);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entry = _service.GetById(id);
            if (entry == null) return NotFound();

            _service.Delete(id);
            return NoContent();
        }

        [HttpGet("searchByName")]
        public IActionResult SearchByName([FromQuery] string donorName)
        {
            var results = _service.SearchByName(donorName);
            return Ok(results);
        }

        [HttpGet("searchByBloodType")]
        public IActionResult SearchByBloodType([FromQuery] string bloodType)
        {
            var results = _service.SearchByBloodType(bloodType);
            return Ok(results);
        }

        [HttpGet("searchByStatus")]
        public IActionResult SearchByStatus([FromQuery] string status)
        {
            var results = _service.SearchByStatus(status);
            return Ok(results);
        }


        [HttpGet("search")]
        public IActionResult Search([FromQuery] string donorName, [FromQuery] string bloodType, [FromQuery] string status)
        {
            var results = _service.Search(donorName, bloodType, status);
            return Ok(results);
        }

        [HttpGet("paginate")]
        public IActionResult GetPaginated([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var allEntries = _service.GetAll();
            var paginatedEntries = allEntries.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var result = new PaginatedResult<BloodBankEntry>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = allEntries.Count,
                Data = paginatedEntries
            };

            return Ok(result);
        }

        //[HttpGet]
        //public IActionResult GetAll([FromQuery] string sortBy, [FromQuery] string sortOrder)
        //{
        //    var results = _service.GetSorted(sortBy, sortOrder);
        //    return Ok(results);
        //}

    }
}
