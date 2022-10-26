using Book_Show_Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Book_Show_DAL
{
    public class Book_show_db:DbContext 
    {
        public Book_show_db(DbContextOptions<Book_show_db> options) : base(options)
        {
        }
        public DbSet<Movie> movies { get; set; }
        public DbSet<ShowTiming> showTiming { get; set; }
        public DbSet<Theater> theater { get; set; }
        public DbSet<Location> location { get; set; }
        public DbSet<UserDetails> userDetails { get; set; }
        public DbSet<BookShow> bookShow { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2156;Initial Catalog=Book_show_Movie_18; Integrated Security=true;");
        }
    }
}
