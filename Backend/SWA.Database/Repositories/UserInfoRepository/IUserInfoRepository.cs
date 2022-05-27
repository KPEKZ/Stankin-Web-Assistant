using Backend.Models;
using DatabasesSWA.ModelsDto.Dto;

namespace SWA.Database.Repositories.UserInfoRepository
{
    public interface IUserInfoRepository
    {
        Task<UserInfo> GetUserInfoAsync(int UserInfoId);
        Task<int> CreateUserInfoAsync(UserInfoDto UserInfo);
        Task UpdateUserInfoAsync(int UserInfoId, UserInfoDto UserInfo);
        Task DeleteUserInfoAsync(int UserInfoId);
    }
}
