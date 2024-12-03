using DatabaseManager.Data.Entities;
using DatabaseManager.Variables;
using Microsoft.EntityFrameworkCore;

namespace DatabaseManager.Data;

public class AppDbContext : DbContext
{
    
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<BorrowEntity> Borrows { get; set; }
    public DbSet<ClientEntity> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Globals.ConnectionString);
    }
    
}