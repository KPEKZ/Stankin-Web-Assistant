using Backend.Models;
using DatabasesSWA.ModelsDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWA.Database.Repositories.UserAuthDataRepository
{
    public interface IUserAuthDataRepository
    {
        Task<UserAuthData> GetUserAuthDataAsync(int UserAuthDataId);
        Task<int> CreateUserAuthDataAsync(UserAuthDataDto UserAuthData, int UserInfoId);
        Task UpdateUserAuthDataAsync(int UserAuthDataId, UserAuthDataDto UserAuthData);
        Task DeleteUserAuthDataAsync(int UserAuthDataId);
    }
}
