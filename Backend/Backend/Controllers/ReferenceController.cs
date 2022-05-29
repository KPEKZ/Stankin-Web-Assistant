using Microsoft.AspNetCore.Mvc;
using SWA.Database.Dto;
using SWA.Database.Repositories.ProblemRepository;

namespace Backend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ReferenceController : Controller
	{
		private readonly IReferenceRepository _referenceRepository;
		public ReferenceController(IReferenceRepository referenceRepository)
		{
			_referenceRepository = referenceRepository;
		}

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetReference(int Id)
        {
            IActionResult response;
            try
            {
                var reference = await _referenceRepository.GetReferenceAsync(Id);
                response = Ok(reference);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReference([FromBody] ReferenceDto reference)
        {
            IActionResult response;

            try
            {
                await _referenceRepository.CreateReferenceAsync(reference);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpGet]
        public async Task<IActionResult> GetReferences()
        {
            IActionResult response;
            try
            {
                var reference = await _referenceRepository.GetReferencesAsync();
                response = Ok(reference);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateReference(int Id, [FromBody] ReferenceDto reference)
        {
            IActionResult response;

            try
            {
                await _referenceRepository.UpdateReferenceAsync(Id, reference);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteReference(int Id)
        {
            IActionResult response;

            try
            {
                await _referenceRepository.DeleteReferenceAsync(Id);
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
