using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReverseProxy
{
    public class HrspiReverseProxy
    {
        static HttpClient _http = new HttpClient();
        private readonly RequestDelegate _next;

        public HrspiReverseProxy(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var url = context.Request.Path.ToUriComponent();
            if (url.ToLower().StartsWith("/hrapis/"))
            {
                var uri = new Uri("https://www.csrc91.net/" + url.Replace("/hrapis/","") + context.Request.QueryString);
                var request = CopyRequest(context, uri);
                var remoteRsp = await _http.SendAsync(request);
                //var rsp = context.Response;
                foreach (var header in remoteRsp.Headers)
                {
                    context.Response.Headers.Add(header.Key, header.Value.ToArray());
                }
                context.Response.ContentType = remoteRsp.Content.Headers.ContentType?.ToString();
                context.Response.ContentLength = remoteRsp.Content.Headers.ContentLength;
                context.Response.StatusCode =(int) remoteRsp.StatusCode;
                //context.Response.Body = await remoteRsp.Content.ReadAsStreamAsync();
                await remoteRsp.Content.CopyToAsync(context.Response.Body);
            }
            else {
                await _next.Invoke(context);
            }
        }
        static HttpRequestMessage CopyRequest(HttpContext context, Uri targetUri)
        {
            var req = context.Request;
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod(req.Method),
                Content = new StreamContent(req.Body),
                RequestUri = targetUri,
            };
            foreach (var header in req.Headers)
            {
                requestMessage.Content?.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
            }
            requestMessage.Headers.Host = targetUri.Host;
            return requestMessage;
        }
    }
}
