using blog.dtos;
using blog.dtos.Query;
using blog.service.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace personal.blog.api.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly IArticleService _articleService;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(IArticleService articleService, ILogger<ArticleController> logger)
        {
            _articleService = articleService;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest request)
        {
            try
            {
                var artlcles = await _articleService.GetListAsync(request);
                return Ok(artlcles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"加载文章列表报错:{ex.Message} \n\t {ex.StackTrace}");
                return BadRequest(new PageResponse { Code = 500, RetMsg = $"加载文章列表报错:{ex.Message}" });
            }
        }
    }
}
