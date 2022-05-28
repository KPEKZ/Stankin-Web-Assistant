using SWA.Database.Dto;
using SWA.Database.Models;

namespace SWA.Database.Repositories.ProblemRepository
{
    public interface IProblemRepository
    {
        Task<Problem> GetProblemAsync(int Id);
        Task<int> CreateProblemAsync(ProblemDto Problem);
        Task UpdateProblemAsync(int ProblemId, ProblemDto Problem);
        Task DeleteProblemAsync(int ProblemId);
    }
}
