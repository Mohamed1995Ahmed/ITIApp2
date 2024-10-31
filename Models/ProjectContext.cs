using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProjectContext : IdentityDbContext<User>
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {
        }
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer("workstation id=first_d.mssql.somee.com;packet size=4096;user id=mohamd_1_9_ahmed_SQLLogin_1;pwd=MoSo1203;data source=first_d.mssql.somee.com;persist security info=False;initial catalog=first_d;TrustServerCertificate=True").LogTo(Console.WriteLine, LogLevel.Information); 
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BookConfigration());
            modelBuilder.ApplyConfiguration(new PublisherConfigration());
            modelBuilder.ApplyConfiguration(new AuthorConfigration());
            modelBuilder.ApplyConfiguration(new AutherBookConfigration());
            modelBuilder.ApplyConfiguration(new SubjectConfigration());

            base.OnModelCreating(modelBuilder);

        }



        //Tables
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AutherBook> AutherBook { get; set; }
        public DbSet<BookAttachment> bookAttachment { get; set; }
    }
}