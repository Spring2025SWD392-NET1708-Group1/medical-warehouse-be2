using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;
        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Submission>>> GetAllSubmissions()
        {
            return Ok(await _submissionService.GetAllSubmissionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubmissionViewDTO>> GetSubmissionById(Guid id)
        {
            var submission = await _submissionService.GetSubmissionByIdAsync(id);
            if (submission == null) return NotFound();
            return Ok(submission);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubmission([FromBody] SubmissionCreateDTO dto)
        {
            var submission = await _submissionService.CreateSubmissionAsync(dto);
            return CreatedAtAction(nameof(CreateSubmission), submission);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubmission(Guid id, [FromBody] SubmissionUpdateDTO dto)
        {
            var submission = await _submissionService.UpdateSubmissionAsync(id, dto);
            if(submission == false) return NotFound();
            return Ok(submission);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubmission(Guid id)
        {
            var submission = await _submissionService.DeleteSubmissionAsync(id);
            if (submission == false) return NotFound();
            return NoContent();
        }
    }
}
