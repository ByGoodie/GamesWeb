using GamesWeb.Models.DbModel;
using Microsoft.EntityFrameworkCore;

namespace GamesWeb.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<MembershipModel> Memberships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("User");
            modelBuilder.Entity<GameModel>().ToTable("Game");
            modelBuilder.Entity<AuthorModel>().ToTable("Author");
            modelBuilder.Entity<MembershipModel>().ToTable("Membership");
        }
    }
}
