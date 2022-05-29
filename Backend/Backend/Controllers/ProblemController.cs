using Microsoft.AspNetCore.Mvc;
using SWA.Database.Dto;
using SWA.Database.Repositories.ProblemRepository;

namespace Backend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProblemController : Controller
	{
        private readonly IProblemRepository _problemRepository;
        public ProblemController(IProblemRepository problemRepository)
        {
            _problemRepository = problemRepository;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProblem(int Id)
        {
            IActionResult response;
            try
            {
                var reference = await _problemRepository.GetProblemAsync(Id);
                response = Ok(reference);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpGet]
        public async Task<IActionResult> GetProblems()
        {
            IActionResult response;
            try
            {
                var reference = await _problemRepository.GetProblemsAsync();
                response = Ok(reference);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProblem([FromBody] ProblemDto problem)
        {
            IActionResult response;

            try
            {
                await _problemRepository.CreateProblemAsync(problem);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProblem(int Id, [FromBody] ProblemDto problem)
        {
            IActionResult response;

            try
            {
                await _problemRepository.UpdateProblemAsync(Id, problem);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProblem(int Id)
        {
            IActionResult response;

            try
            {
                await _problemRepository.DeleteProblemAsync(Id);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }
    }
}
