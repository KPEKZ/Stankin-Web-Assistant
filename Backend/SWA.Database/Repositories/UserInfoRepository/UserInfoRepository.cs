﻿using Backend.Models;
using DatabasesSWA.ModelsDto.Dto;
using Microsoft.EntityFrameworkCore;


namespace SWA.Database.Repositories.UserInfoRepository
{
    public class UserInfoRepository : BaseRepository, IUserInfoRepository
    {
        public UserInfoRepository(SWADbContext context) : base(context) { }
		public async Task UpdateUserInfoAsync(int UserInfoId, UserInfoDto UserInfo)
		{
			try
			{
				var userInfo = await _context.UserInfo.FirstOrDefaultAsync(c => c.UserID == UserInfoId);

				if (userInfo == null)
					throw new Exception($"No user with such id = {UserInfoId}.");

				if (userInfo.E_mail != UserInfo.E_mail)
					userInfo.E_mail = UserInfo.E_mail;

				if (userInfo.FirstName != UserInfo.FirstName)
					userInfo.FirstName = UserInfo.FirstName;

				if (userInfo.SecondName != UserInfo.SecondName)
					userInfo.SecondName = UserInfo.SecondName;

				if (userInfo.Patronymic != UserInfo.Patronymic)
					userInfo.Patronymic = UserInfo.Patronymic;

				if (userInfo.PhoneNumber != UserInfo.PhoneNumber)
					userInfo.PhoneNumber = UserInfo.PhoneNumber;

				_context.UserInfo.Update(userInfo);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}

		}
		public async Task<UserInfo> GetUserInfoAsync(int UserInfoId)
		{
			try
			{
				var userInfoId = await _context.UserInfo
				.FirstOrDefaultAsync(c => c.UserID == UserInfoId);

				if (userInfoId == null)
					throw new Exception($"No user with such id: {UserInfoId}");

				return userInfoId;
			}
			catch
			{
				throw new Exception($"Error");
			}

		}
		public async Task<int> CreateUserInfoAsync(UserInfoDto UserInfo)
        {
			try
			{
				var userInfo = new UserInfo()
				{
					E_mail = UserInfo.E_mail,
					FirstName = UserInfo.FirstName,
					SecondName = UserInfo.SecondName,
					Patronymic = UserInfo.Patronymic,
					PhoneNumber = UserInfo.PhoneNumber
				};

				await _context.UserInfo.AddAsync(userInfo);
				await _context.SaveChangesAsync();

				return userInfo.UserID;
			}

			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteUserInfoAsync(int UserInfoId)
		{
			try
			{
				var userInfo = await _context.UserInfo.FirstOrDefaultAsync(c => c.UserID == UserInfoId);

				if (userInfo == null)
					throw new Exception($"No user with such id = {UserInfoId}.");

				_context.UserInfo.Remove(userInfo);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}
		}
	}
}