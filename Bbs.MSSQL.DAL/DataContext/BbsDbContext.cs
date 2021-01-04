using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bbs.Models;
using System.Collections.Generic;

namespace Bbs.MSSQL.DAL.DataContext
{
    public class BbsDbContext : IdentityDbContext<User, UserRole, int>
    {
        public DbSet<Note> Notes { get; set; }
        //public BbsDbContext(DbContextOptions<BbsDbContext> options) 
        //    : base(options) 
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BbsDb;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}
