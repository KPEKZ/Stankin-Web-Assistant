using Backend.Models;
using DatabasesSWA.ModelsDto.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWA.Database.Repositories.UserAuthDataRepository
{
    public class UserAuthDataRepository: BaseRepository, IUserAuthDataRepository
    {
        public UserAuthDataRepository(SWADbContext context) : base(context) { }

        public async Task<UserAuthData> GetUserAuthDataAsync(int UserAuthDataId)
        {
            try
            {
                var user = await _context.UserAuthData
                .FirstOrDefaultAsync(c => c.Id == UserAuthDataId);

                if (user == null)
                    throw new Exception($"No user with such id: {UserAuthDataId}");

                return user;
            }
            catch
            {
                throw new Exception($"Error");
            }
        }

        public async Task<int> CreateUserAuthDataAsync(UserAuthDataDto UserAuthData, int UserInfoId)
        {
            var userInfoID = await _context.UserInfo
                .FirstOrDefaultAsync(c => c.UserID == UserInfoId);

            try
            {
                var user = new UserAuthData()
                {
                    Login = UserAuthData.Login,
                    Password = UserAuthData.Password,
                    UserInfoID = userInfoID
                };

                await _context.UserAuthData.AddAsync(user);
                await _context.SaveChangesAsync();

                return user.Id;
            }

            catch
            {
                throw new Exception($"Error");
            }
        }

        public async Task UpdateUserAuthDataAsync(int UserAuthDataId, UserAuthDataDto UserAuthData)
        {
            try
            {
                var user = await _context.UserAuthData.FirstOrDefaultAsync(c => c.Id == UserAuthDataId);

                if (user == null)
                    throw new Exception($"No user with such id = {UserAuthDataId}.");

                if (user.Login != UserAuthData.Login)
                    user.Login = UserAuthData.Login;

                if (user.Password != UserAuthData.Password)
                    user.Password = UserAuthData.Password;

                _context.UserAuthData.Update(user);
                await _context.SaveChangesAsync();
            }

            catch
            {
                throw new Exception($"Error");
            }
        }

        public async Task DeleteUserAuthDataAsync(int UserAuthDataId)
        {
            try
            {
                var user = await _context.UserAuthData.FirstOrDefaultAsync(c => c.Id == UserAuthDataId);

                if (user == null)
                    throw new Exception($"No user with such id = {UserAuthDataId}.");

                _context.UserAuthData.Remove(user);
                await _context.SaveChangesAsync();
            }

            catch
            {
                throw new Exception($"Error");
            }
        }
    }
}
