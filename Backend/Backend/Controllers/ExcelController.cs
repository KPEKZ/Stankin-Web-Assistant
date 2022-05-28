using Microsoft.AspNetCore.Mvc;
using SWA.Database.Repositories.ExcelRepository;

namespace Backend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ExcelController : Controller
	{
        private readonly IExcelRepository _excelRepository;
        public ExcelController(IExcelRepository excelRepository)
        {
            _excelRepository = excelRepository;
        }

        [HttpGet("HeadMen/{Id}/{Year}")]
        public async Task<IActionResult> GetHeadMen(int Id, int Year)
        {
            IActionResult response;
            try
            {
                var userInfoDto = await _excelRepository.GetHeadMenAsync(Id, Year);
                response = Ok(userInfoDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpGet("ListGroup/{GroupName}/{Id}")]
        public async Task<IActionResult> GetListGroup(string GroupName, int Id)
        {
            IActionResult response;
            try
            {
                var userInfoDto = await _excelRepository.GetListGroupAsync(GroupName, Id);
                response = Ok(userInfoDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpGet("Progress/{Id}")]
        public async Task<IActionResult> GetProgressUser(int Id)
        {
            IActionResult response;
            try
            {
                var userInfoDto = await _excelRepository.GetProgressAsync(Id);
                response = Ok(userInfoDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpGet("Curator/{Id}")]
        public async Task<IActionResult> GetCurator(int Id)
        {
            IActionResult response;
            try
            {
                var userInfoDto = await _excelRepository.GetCuratorsAsync(Id);
                response = Ok(userInfoDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }
    }
}
