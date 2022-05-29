using Backend.Models;
using DatabasesSWA.ModelsDto.Dto;
using Microsoft.EntityFrameworkCore;
using SWA.Database.Dto;
using SWA.Database.Models;

namespace SWA.Database.Repositories.ProblemRepository
{
    public class ReferenceRepository : BaseRepository, IReferenceRepository
    {
        public ReferenceRepository(SWADbContext context) : base(context) { }

		public async Task UpdateReferenceAsync(int ReferenceId, ReferenceDto Reference)
		{
			try
			{
				var reference = await _context.Reference.FirstOrDefaultAsync(c => c.Id == ReferenceId);

				if (reference == null)
					throw new Exception($"No reference with such id = {ReferenceId}.");

				if (reference.Type != Reference.Type)
					reference.Type = Reference.Type;

				if (reference.Audience != Reference.Audience)
					reference.Audience = Reference.Audience;

				if (reference.Department != Reference.Department)
					reference.Department = Reference.Department;

				if (reference.PhoneNumber != Reference.PhoneNumber)
					reference.PhoneNumber = Reference.PhoneNumber;

				_context.Reference.Update(reference);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}

		}
		
		public async Task<Reference> GetReferenceAsync(int Id)
		{
			try
			{
				var reference = await _context.Reference
				.FirstOrDefaultAsync(c => c.Id == Id);

				if (reference == null)
					throw new Exception($"No reference with such id");

				return reference;
			}
			catch
			{
				throw new Exception($"Error");
			}

		}

		public async Task<int> CreateReferenceAsync(ReferenceDto Reference)
        {
			try
			{
				var reference = new Reference()
				{
					Type = Reference.Type,
					Audience = Reference.Audience,
					Department = Reference.Department,
					PhoneNumber = Reference.PhoneNumber
				};

				await _context.Reference.AddAsync(reference);
				await _context.SaveChangesAsync();

				return reference.Id;
			}

			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<Reference>> GetReferencesAsync()
		{
			try
			{
				var references = await _context.Reference.ToListAsync();

				if (references == null)
					throw new Exception($"No references.");

				return references;
			}

			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteReferenceAsync(int ReferenceId)
		{
			try
			{
				var reference = await _context.Reference.FirstOrDefaultAsync(c => c.Id == ReferenceId);

				if (reference == null)
					throw new Exception($"No reference with such id = {ReferenceId}.");

				_context.Reference.Remove(reference);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}
		}
	}
}
