using Backend.Models;
using DatabasesSWA.ModelsDto.Dto;

namespace SWA.Database.Repositories.UserInfoRepository
{
    public interface IUserInfoRepository
    {
        Task<UserInfo> GetUserInfoAsync(string Login, string Password);
        Task<UserInfo> GetUserInfoAsyncById(int Id);
        Task<int> CreateUserInfoAsync(UserInfoDto UserInfo);
        Task UpdateUserInfoAsync(int UserInfoId, UserInfoDto UserInfo);
        Task DeleteUserInfoAsync(int UserInfoId);
    }
}
