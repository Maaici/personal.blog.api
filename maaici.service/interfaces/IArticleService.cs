using blog.dtos;
using blog.dtos.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.service.interfaces
{
    public interface IArticleService
    {
        Task<PageResponse> GetListAsync(PageRequest request);
    }
}
