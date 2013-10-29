using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Practice.Models
{
    public class Guild
    {
        [Key]
        public string Name { get; set; }
        public int MemberCount { get; set; }
        public string Team { get; set; }

    }

    public class GuildDBContext : DbContext
    {
        public DbSet<Guild> Guilds { get; set; }
    }
}