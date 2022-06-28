using AnimeCrud.Data.Mappings;
using AnimeCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeCrud.Data;

public class AnimeContext : DbContext
{
    public DbSet<Anime> Animes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("DataSource=app.db;Cache=Shared");

    protected override void OnModelCreating(ModelBuilder builder)
        => builder.ApplyConfiguration(new AnimeMap());
}
