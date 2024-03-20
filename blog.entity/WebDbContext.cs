using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.entity
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options)
             : base(options)
        {
        }
        public DbSet<Article> articles { get; set; }
        public DbSet<WebsiteInfo>  websiteInfos { get; set; }
        public DbSet<UsersLink> usersLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }

    }
}
