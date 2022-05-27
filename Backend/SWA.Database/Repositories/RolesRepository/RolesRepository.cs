using Backend.Models;
using DatabasesSWA.ModelsDto.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWA.Database.Repositories.RolesRepository
{
    public class RolesRepository : BaseRepository, IRolesRepository
    {
        public RolesRepository(SWADbContext context) : base(context) { }

		public async Task<int> CreateRoleAsync(RolesDto Role, int UserInfoId)
        {
			var userInfoID = await _context.UserInfo
				.FirstOrDefaultAsync(c => c.UserID == UserInfoId);

			try
			{
				var role = new Roles()
				{
					RoleName = Role.RoleName,
					Permission = Role.Permission,
					UserInfoID = userInfoID
				};

				await _context.Roles.AddAsync(role);
				await _context.SaveChangesAsync();

				return role.Id;
			}

			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task UpdateRoleAsync(int RoleId, RolesDto Role)
        {
			try
			{
				var role = await _context.Roles.FirstOrDefaultAsync(c => c.Id == RoleId);

				if (role == null)
					throw new Exception($"No role with such id = {RoleId}.");

				if (role.RoleName != Role.RoleName)
					role.RoleName = Role.RoleName;

				if (role.Permission != Role.Permission)
					role.Permission = Role.Permission;

				_context.Roles.Update(role);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteRoleAsync(int RoleId)
        {
			try
			{
				var role = await _context.Roles.FirstOrDefaultAsync(c => c.Id == RoleId);

				if (role == null)
					throw new Exception($"No role with such id = {RoleId}.");

				_context.Roles.Remove(role);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}
		}
		public async Task<Roles> GetRoleAsync(int RoleId)
        {
			try
			{
				var role = await _context.Roles
				.FirstOrDefaultAsync(c => c.Id == RoleId);

				if (role == null)
					throw new Exception($"No role with such id: {RoleId}");

				return role;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}
    }
}
