﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("HeadMen/{GroupName}/{Id}")]
        public async Task<IActionResult> GetHeadMen(string GroupName, int Id)
        {
            IActionResult response;
            try
            {
                var userInfoDto = await _excelRepository.GetHeadMenAsync(GroupName,Id);
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
    }
}
