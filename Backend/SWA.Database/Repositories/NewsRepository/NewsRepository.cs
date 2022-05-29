using Microsoft.EntityFrameworkCore;
using SWA.Database.Dto;
using SWA.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWA.Database.Repositories.NewsRepository
{
	public class NewsRepository : BaseRepository, INewsRepository
	{
		public NewsRepository(SWADbContext context) : base(context) { }

		public async Task UpdateNewsAsync(int NewsId, NewsDto News)
		{
			try
			{
				var news = await _context.News.FirstOrDefaultAsync(c => c.Id == NewsId);

				if (news == null)
					throw new Exception($"No news with such id = {NewsId}.");

				if (news.Name != News.Name)
					news.Name = News.Name;

				if (news.Discription != News.Discription)
					news.Discription = News.Discription;

				_context.News.Update(news);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}

		}

		public async Task<News> GetNewAsync(int Id)
		{
			try
			{
				var news = await _context.News
				.FirstOrDefaultAsync(c => c.Id == Id);

				if (news == null)
					throw new Exception($"No news with such id");

				return news;
			}
			catch
			{
				throw new Exception($"Error");
			}

		}

		public async Task<int> CreateNewsAsync(NewsDto News)
		{
			try
			{
				var news = new News()
				{
					Name = News.Name,
					Discription = News.Discription
				};

				await _context.News.AddAsync(news);
				await _context.SaveChangesAsync();

				return news.Id;
			}

			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<News>> GetNewsAsync()
		{
			try
			{
				var news = await _context.News.ToListAsync();

				if (news == null)
					throw new Exception($"No news.");

				return news;
			}

			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteNewsAsync(int NewsId)
		{
			try
			{
				var news = await _context.News.FirstOrDefaultAsync(c => c.Id == NewsId);

				if (news == null)
					throw new Exception($"No news with such id = {NewsId}.");

				_context.News.Remove(news);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}
		}
	}
}
