using AnimeCrud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeCrud.Data.Mappings;
public class AnimeMap : IEntityTypeConfiguration<Anime>
{
    public void Configure(EntityTypeBuilder<Anime> builder)
    {
        builder.ToTable("Animes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnName("title")
            .HasColumnType("NVARCHAR");

       builder.Property(x => x.Year)
            .IsRequired()
            .HasColumnName("year")
            .HasColumnType("int");

    }
}
