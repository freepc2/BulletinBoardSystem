using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bbs.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Bbs.MSSQL.DAL.DataContext
{
    public class BbsDbContext : IdentityDbContext<User, UserRole, int>
    {
        string LocalDb = @"Server=(localdb)\mssqllocaldb;Database=BbsDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            =>options.UseSqlServer(LocalDb);

    }
}
