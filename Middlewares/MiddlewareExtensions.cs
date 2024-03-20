using Microsoft.AspNetCore.Builder;

namespace ReverseProxy
{
    //将封装的中间件委托到一个类中，通过IApplicationBuilder拓展方法暴露
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseHrspiReverseProxy(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HrspiReverseProxy>();
        }
    }
}
