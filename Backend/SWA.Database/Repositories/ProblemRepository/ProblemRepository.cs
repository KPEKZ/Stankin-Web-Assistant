using Backend.Models;
using DatabasesSWA.ModelsDto.Dto;
using Microsoft.EntityFrameworkCore;
using SWA.Database.Dto;
using SWA.Database.Models;

namespace SWA.Database.Repositories.ProblemRepository
{
    public class ProblemRepository : BaseRepository, IProblemRepository
	{
        public ProblemRepository(SWADbContext context) : base(context) { }

		public async Task UpdateProblemAsync(int ProblemId, ProblemDto Problem)
		{
			try
			{
				var problem = await _context.Problem.FirstOrDefaultAsync(c => c.Id == ProblemId);

				if (problem == null)
					throw new Exception($"No problem with such id = {ProblemId}.");

				if (problem.Type != Problem.Type)
					problem.Type = Problem.Type;

				if (problem.Audience != Problem.Audience)
					problem.Audience = Problem.Audience;

				if (problem.Department != Problem.Department)
					problem.Department = Problem.Department;

				if (problem.PhoneNumber != Problem.PhoneNumber)
					problem.PhoneNumber = Problem.PhoneNumber;

				_context.Problem.Update(problem);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}

		}
		
		public async Task<Problem> GetProblemAsync(int Id)
		{
			try
			{
				var problem = await _context.Problem
				.FirstOrDefaultAsync(c => c.Id == Id);

				if (problem == null)
					throw new Exception($"No problem with such id");

				return problem;
			}
			catch
			{
				throw new Exception($"Error");
			}

		}

		public async Task<int> CreateProblemAsync(ProblemDto Problem)
        {
			try
			{
				var problem = new Problem()
				{
					Type = Problem.Type,
					Audience = Problem.Audience,
					Department = Problem.Department,
					PhoneNumber = Problem.PhoneNumber
				};

				await _context.Problem.AddAsync(problem);
				await _context.SaveChangesAsync();

				return problem.Id;
			}

			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<Problem>> GetProblemsAsync()
		{
			try
			{
				var problems = await _context.Problem.ToListAsync<Problem>();

				if (problems == null)
					throw new Exception($"No problems.");

				return problems;
			}

			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteProblemAsync(int ProblemId)
		{
			try
			{
				var problem = await _context.Problem.FirstOrDefaultAsync(c => c.Id == ProblemId);

				if (problem == null)
					throw new Exception($"No problem with such id = {ProblemId}.");

				_context.Problem.Remove(problem);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}
		}
	}
}
