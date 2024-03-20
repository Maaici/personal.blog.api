using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using blog.entity;
using Microsoft.EntityFrameworkCore;
using personal.blog.api.autofac;
using personal.blog.api.mapperProfile;
using Serilog;

//serilog ����
Log.Logger = new LoggerConfiguration()
       //������־��С����ļ���Ϊ��debug
       .MinimumLevel.Warning()
       //�����Microsoft����־����С��¼�ȼ�Ϊinfo
       //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
       .Enrich.FromLogContext()
       //���������̨
       .WriteTo.Console()
       //����־���浽�ļ��У����������ֱ�����־��·����������־�ļ���Ƶ�Σ���ǰ��һ��һ���ļ���
       .WriteTo.File(Path.Combine("logs", @"log.txt"), rollingInterval: RollingInterval.Day)
       .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

//���ÿ�����������
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
    //b=>b.UseRowNumberForPaging() �ڲ�ѯ��ʹ�� ROW_NUMBER���������� OFFSET/FETCH,���ӵĻ� 2008��֮ǰ�����ݿ��������
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB_BLOG"));//, b => b.UseRowNumberForPaging()
}, poolSize: 80);

#region ����AutoMapper

//ע��AutoMapper��Ҫ�õ��ķ������а���AutoMapper�������� Profile��MappingProfile��
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

// Use Autofac & serilog ������������ IHostBuilder ����չ����  ���Ծͷ���һ����
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
/// 3.0�Ժ�autofac ���µ�ʹ�÷�����������program�л����IHostBuilderʹ��.UseServiceProviderFactory(new AutofacServiceProviderFactory())
/// </summary>
/// <param name="builder"></param>
void AutofacContainerBuilderConfiguration(ContainerBuilder builder)
{
    //���ݳ�������ע��
    builder.RegisterModule<CustomAutofacModule>();
}
