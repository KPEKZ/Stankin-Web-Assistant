using SWA.Database.Dto;
using SWA.Database.Models;

namespace SWA.Database.Repositories.NewsRepository
{
	public interface INewsRepository
	{
		Task<News> GetNewAsync(int Id);
		Task<List<News>> GetNewsAsync();
		Task<int> CreateNewsAsync(NewsDto News);
		Task UpdateNewsAsync(int NewsId, NewsDto News);
		Task DeleteNewsAsync(int NewsId);
	}
}
