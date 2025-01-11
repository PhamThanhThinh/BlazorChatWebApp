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
    }
  }
}