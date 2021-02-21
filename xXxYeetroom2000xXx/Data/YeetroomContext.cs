using Microsoft.EntityFrameworkCore;
using xXxYeetroom2000xXx.Models;

namespace xXxYeetroom2000xXx.Data
{
    /// <summary>
    /// Combination of transaction and repository patterns. Can be used to query from a database and group together changes that will then be written to the database as a unit.
    /// </summary>
    public class YeetroomContext : DbContext
    {
        public YeetroomContext(DbContextOptions<YeetroomContext> options)
            : base(options)
        {
        }

        // A DbSet represents the collection of all entities in the context, or that can be queried from the database, of a given type.
        
        /// <summary>
        /// Representation of "Post" as entity in DbContext.
        /// </summary>
        public DbSet<Post> Post { get; set; }
        /// <summary>
        /// Representation of "Kommentar" as entity in DbContext.
        /// </summary>
        public DbSet<Kommentar> Kommentar { get; set; }
    }
}