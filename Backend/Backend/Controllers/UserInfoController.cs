using Microsoft.AspNetCore.Mvc;
using SWA.Database.Repositories.UserInfoRepository;
using DatabasesSWA.ModelsDto.Dto;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInfoController : Controller
    {
        private readonly IUserInfoRepository _userInfoRepository;
        public UserInfoController(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        [HttpGet("{UserInfoId}")]
        public async Task<IActionResult> GetUserInfo(int UserInfoId)
        {
            IActionResult response;
            try
            {
                var userInfoDto = await _userInfoRepository.GetUserInfoAsync(UserInfoId);
                response = Ok(userInfoDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserInfo([FromBody] UserInfoDto user)
        {
            IActionResult response;

            try
            {
                await _userInfoRepository.CreateUserInfoAsync(user);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPut("{UserInfoId}")]
        public async Task<IActionResult> UpdateUserInfo(int UserInfoId, [FromBody] UserInfoDto user)
        {
            IActionResult response;

            try
            {
                await _userInfoRepository.UpdateUserInfoAsync(UserInfoId, user);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpDelete("{UserInfoId}")]
        public async Task<IActionResult> DeleteUserInfo(int UserInfoId)
        {
            IActionResult response;

            try
            {
                await _userInfoRepository.DeleteUserInfoAsync(UserInfoId);
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
