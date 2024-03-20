using Azure;
using blog.dtos;
using blog.dtos.Query;
using blog.entity;
using blog.service.interfaces;
using maaici.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace blog.service
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PageResponse> GetListAsync(PageRequest request)
        {
            var query = _unitOfWork.Repository<Article>().GetAll( x => x.State == 1);
            PageResponse response = new PageResponse();
            response.Count = await query.CountAsync();
            response.RetData = await query.OrderByDescending( x => x.Id )
                .Skip((request.Limit * (request.Page -1))).Take(request.Limit).ToListAsync();
            return response;
        }
    }
}
