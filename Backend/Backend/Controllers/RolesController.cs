using DatabasesSWA.ModelsDto.Dto;
using Microsoft.AspNetCore.Mvc;
using SWA.Database.Repositories.RolesRepository;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly IRolesRepository _roleRepository;
        public RolesController(IRolesRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetRoleInfo(int Id)
        {
            IActionResult response;
            try
            {
                var roleDto = await _roleRepository.GetRoleAsync(Id);
                response = Ok(roleDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPost("{UserInfoId}")]
        public async Task<IActionResult> CreateRole([FromBody] RolesDto role, int UserInfoId)
        {
            IActionResult response;

            try
            {
                await _roleRepository.CreateRoleAsync(role, UserInfoId);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateRole(int Id, [FromBody] RolesDto role)
        {
            IActionResult response;

            try
            {
                await _roleRepository.UpdateRoleAsync(Id, role);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteRole(int Id)
        {
            IActionResult response;

            try
            {
                await _roleRepository.DeleteRoleAsync(Id);
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
