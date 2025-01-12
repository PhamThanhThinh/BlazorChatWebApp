using BlazorChatWebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorChatWebApp.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Message>(e =>
      {
        e.HasOne(x => x.FromUser)
          .WithMany()
         .HasForeignKey(x => x.FromId)
         .OnDelete(DeleteBehavior.NoAction);
        e.HasOne(x => x.ToUser)
          .WithMany()
          .HasForeignKey(x => x.ToId)
          .OnDelete(DeleteBehavior.NoAction);

        //e.HasOne(x => x.ToUser).WithMany().OnDelete(DeleteBehavior.NoAction);
        //e.HasOne(x => x.FromUser).WithMany().OnDelete(DeleteBehavior.NoAction);
      }
      );
    }
  }
}