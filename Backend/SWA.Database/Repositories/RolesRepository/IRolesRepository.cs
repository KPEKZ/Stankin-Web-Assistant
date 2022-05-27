using Backend.Models;
using DatabasesSWA.ModelsDto.Dto;

namespace SWA.Database.Repositories.RolesRepository
{
    public interface IRolesRepository
    {
        Task<Roles> GetRoleAsync(int RoleId);
        Task<int> CreateRoleAsync(RolesDto Role, int UserInfoId);
        Task UpdateRoleAsync(int RoleId, RolesDto Role);
        Task DeleteRoleAsync(int RoleId);
    }
}
