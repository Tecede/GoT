using Got.App.Data.Skill;
using Got.App.Domain.Npc;
using Microsoft.EntityFrameworkCore;

namespace Got.App.Data.Npc
{
    public class NameDbContext : DbContext
    {
        public DbSet<Name> Names { get; set; }

        public NameDbContext(DbContextOptions<NameDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}