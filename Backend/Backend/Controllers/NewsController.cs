using Microsoft.AspNetCore.Mvc;
using SWA.Database.Dto;
using SWA.Database.Repositories.NewsRepository;

namespace Backend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class NewsController : Controller
	{
		private readonly INewsRepository _newsRepository;
		public NewsController(INewsRepository newsRepository)
		{
			_newsRepository = newsRepository;
		}

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetNew(int Id)
        {
            IActionResult response;
            try
            {
                var reference = await _newsRepository.GetNewAsync(Id);
                response = Ok(reference);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpGet]
        public async Task<IActionResult> GetNews()
        {
            IActionResult response;
            try
            {
                var reference = await _newsRepository.GetNewsAsync();
                response = Ok(reference);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromBody] NewsDto news)
        {
            IActionResult response;

            try
            {
                await _newsRepository.CreateNewsAsync(news);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateNews(int Id, [FromBody] NewsDto news)
        {
            IActionResult response;

            try
            {
                await _newsRepository.UpdateNewsAsync(Id, news);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteNews(int Id)
        {
            IActionResult response;

            try
            {
                await _newsRepository.DeleteNewsAsync(Id);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }
    }
}
