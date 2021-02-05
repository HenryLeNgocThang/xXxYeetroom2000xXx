using Microsoft.EntityFrameworkCore;
using xXxYeetroom2000xXx.Models;

namespace xXxYeetroom2000xXx.Data
{
    public class YeetroomContext : DbContext
    {
        public YeetroomContext(DbContextOptions<YeetroomContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Post { get; set; }
        public DbSet<Kommentar> Kommentar { get; set; }
    }
}