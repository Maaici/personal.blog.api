using Autofac;
using blog.service;
using maaici.Repository;

namespace personal.blog.api.autofac
{
    public class CustomAutofacModule : Module
    {
        /// <summary>
        /// AutoFac注册类
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //根据程序集批量注册

            builder.RegisterAssemblyTypes(typeof(UnitOfWork).Assembly)
                .Where(t => t.Name.EndsWith("Repository") || t.Name == "UnitOfWork")
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ArticleService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
