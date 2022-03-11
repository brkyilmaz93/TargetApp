using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using TargetApp.Entities.Concreate;

namespace TargetApp.API.Data
{
    public class TargetAppContext : DbContext
    {
        public TargetAppContext()
        {

        }

        public TargetAppContext(DbContextOptions<TargetAppContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<MyAppInfo> MyAppInfos { get; set; }
        public virtual DbSet<MyAppHealth> MyAppHealths { get; set; }
        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            //optionsBuilder.UseSqlServer(config.GetConnectionString("defDatabase"));

            //PostgreSql Bağlantı konfigürasyonu..
            optionsBuilder.UseSqlServer(config.GetConnectionString("MyHealthApp"));
        }

    }


    public static class ContextExtensions
    {
        public static string GetTableName<T>(this DbContext context) where T : class
        {
            string snc = "";

            var models = context.Model;
            var entityTypes = models.GetEntityTypes();

            var tip = entityTypes.First(x => x.ClrType == typeof(T));

            snc = tip.GetTableName();

            return snc;
        }
    } 
}
