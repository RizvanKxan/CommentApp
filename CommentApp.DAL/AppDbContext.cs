using Microsoft.EntityFrameworkCore;
using CommentApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommentApp.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Recall> Recalls { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }


    }
}
