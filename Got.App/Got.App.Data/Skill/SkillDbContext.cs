using Microsoft.EntityFrameworkCore;

namespace Got.App.Data.Skill
{
    public class SkillDbContext : DbContext
    {
        public DbSet<Domain.Skill.Skill> Skills { get; set; }

        public SkillDbContext(DbContextOptions<SkillDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}