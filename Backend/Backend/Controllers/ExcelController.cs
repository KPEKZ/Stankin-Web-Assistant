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

        [HttpGet("Progress/{GroupName}/{SecondName}/{Id}")]
        public async Task<IActionResult> GetProgressUser(string GroupName, string SecondName, int Id)
        {
            IActionResult response;
            try
            {
                var userInfoDto = await _excelRepository.GetProgressAsync(GroupName,SecondName, Id);
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
