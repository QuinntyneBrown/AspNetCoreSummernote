using AspNetCoreSummernote.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSummernote.Api.Data
{
    public interface IAspNetCoreSummernoteDbContext
    {
        DbSet<Note> Notes { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
