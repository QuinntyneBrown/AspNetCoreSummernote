using AspNetCoreSummernote.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AspNetCoreSummernote.Api.Data
{
    public class AspNetCoreSummernoteDbContext: DbContext, IAspNetCoreSummernoteDbContext
    {
        public AspNetCoreSummernoteDbContext(DbContextOptions options)
            :base(options) { }

        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<Note> Notes { get; private set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
