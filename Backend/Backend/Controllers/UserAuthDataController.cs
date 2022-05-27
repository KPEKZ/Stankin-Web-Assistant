using DatabasesSWA.ModelsDto.Dto;
using Microsoft.AspNetCore.Mvc;
using SWA.Database.Repositories.UserAuthDataRepository;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthDataController : Controller
    {
        private readonly IUserAuthDataRepository _userAuthDataRepository;
        public UserAuthDataController(IUserAuthDataRepository userAuthDataRepository)
        {
            _userAuthDataRepository = userAuthDataRepository;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserAuthData(int Id)
        {
            IActionResult response;
            try
            {
                var userDto = await _userAuthDataRepository.GetUserAuthDataAsync(Id);
                response = Ok(userDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPost("{UserInfoId}")]
        public async Task<IActionResult> CreateUserAuthData([FromBody] UserAuthDataDto user, int UserInfoId)
        {
            IActionResult response;

            try
            {
                await _userAuthDataRepository.CreateUserAuthDataAsync(user, UserInfoId);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateUserAuthData(int Id, [FromBody] UserAuthDataDto user)
        {
            IActionResult response;

            try
            {
                await _userAuthDataRepository.UpdateUserAuthDataAsync(Id, user);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUserAuthData(int Id)
        {
            IActionResult response;

            try
            {
                await _userAuthDataRepository.DeleteUserAuthDataAsync(Id);
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
