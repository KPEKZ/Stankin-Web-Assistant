using SWA.Database.Dto;
using SWA.Database.Models;

namespace SWA.Database.Repositories.ProblemRepository
{
    public interface IReferenceRepository
    {
        Task<Reference> GetReferenceAsync(int Id);
        Task<int> CreateReferenceAsync(ReferenceDto Reference);
        Task UpdateReferenceAsync(int ReferenceId, ReferenceDto Reference);
        Task DeleteReferenceAsync(int ReferenceId);
    }
}
