using System.Configuration;
using Internship_7_Library.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Library.Data.Entities
{
    public class Context : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<TypeBook> TypeBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rent>()
                .HasOne(rnt => rnt.Book)
                .WithMany(rnt => rnt.Rents)
                .HasForeignKey(rnt => rnt.BookId);
            modelBuilder.Entity<Rent>()
                .HasOne(rnt => rnt.Person)
                .WithMany(rnt => rnt.Rents)
                .HasForeignKey(rnt => rnt.PersonId);
        }
    }
}
