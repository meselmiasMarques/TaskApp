using Microsoft.EntityFrameworkCore;
using Tarefas.Core.Models.Categories;
using Tarefas.Core.Models.Todos;

namespace Tarefas.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Todo> Todos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("tbl_Category");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                .IsRequired(true)
                .HasMaxLength(80)
                .HasColumnType("VARCHAR");
        });
        
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.ToTable("tbl_Todos");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                .IsRequired(true)
                .HasMaxLength(80)
                .HasColumnType("VARCHAR");
            
            entity.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(100)
                .HasColumnType("VARCHAR");
            
            entity.Property(x => x.Status)
                .IsRequired(true)
                .HasColumnType("SMALLINT");
            
            entity.Property(x => x.CreatedAt)
                .IsRequired(true);
            
        });
    }
}