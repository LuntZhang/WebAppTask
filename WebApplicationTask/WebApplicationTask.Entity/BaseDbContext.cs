using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationTask.Entity.Models;

namespace WebApplicationTask.Entity
{
    public class BaseDbContext : DbContext
    {
        public DbSet<Base_User> Base_User { get; set; }

        public BaseDbContext([NotNull] DbContextOptions options)
            : base(options)
        {
        
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //注入Sql链接字符串
        //    //上下文重写此方法，以配置要使用的数据库。对上下文的每个实例调用此方法创建
        //    IConfiguration congifuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        //    string connectionString = congifuration["ConnectionSetting:connectionString"];
        //    optionsBuilder.UseSqlServer(connectionString);
        //    base.OnConfiguring(optionsBuilder);
        //}

        public void Detach()
        {
            ChangeTracker.Entries().ToList().ForEach(aEntry =>
            {
                if (aEntry.State != EntityState.Detached)
                    aEntry.State = EntityState.Detached;
            });
        }

        public override int SaveChanges()
        {
            int count = base.SaveChanges();
            Detach();

            return count;
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int count = await base.SaveChangesAsync(cancellationToken);
            Detach();

            return count;
        }
    }
}
