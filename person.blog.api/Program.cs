using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using blog.entity;
using Microsoft.EntityFrameworkCore;
using personal.blog.api.autofac;
using personal.blog.api.mapperProfile;
using Serilog;

//serilog 配置
Log.Logger = new LoggerConfiguration()
       //配置日志最小输出的级别为：debug
       .MinimumLevel.Warning()
       //如果是Microsoft的日志，最小记录等级为info
       //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
       .Enrich.FromLogContext()
       //输出到控制台
       .WriteTo.Console()
       //将日志保存到文件中（两个参数分别是日志的路径和生成日志文件的频次，当前是一天一个文件）
       .WriteTo.File(Path.Combine("logs", @"log.txt"), rollingInterval: RollingInterval.Day)
       .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

//配置跨域请求允许
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllinPolicy",
        builder1 =>
        {
            builder1.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddDbContextPool<WebDbContext>(options =>
{
    //b=>b.UseRowNumberForPaging() 在查询中使用 ROW_NUMBER（）而不是 OFFSET/FETCH,不加的话 2008和之前的数据库会有问题
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB_BLOG"));//, b => b.UseRowNumberForPaging()
}, poolSize: 80);

#region 配置AutoMapper

//注入AutoMapper需要用到的服务，其中包括AutoMapper的配置类 Profile（MappingProfile）
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

// Use Autofac & serilog 这两个东西是 IHostBuilder 的拓展方法  所以就放在一起了
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(AutofacContainerBuilderConfiguration)).UseSerilog();


var app = builder.Build();

app.UseCors("AnotherPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


/// <summary>
/// 3.0以后autofac 最新的使用方法，另外在program中还需对IHostBuilder使用.UseServiceProviderFactory(new AutofacServiceProviderFactory())
/// </summary>
/// <param name="builder"></param>
void AutofacContainerBuilderConfiguration(ContainerBuilder builder)
{
    //根据程序集批量注册
    builder.RegisterModule<CustomAutofacModule>();
}
