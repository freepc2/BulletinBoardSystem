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
        private readonly IConfiguration _configuration;
        public BbsDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_configuration.GetConnectionString("LocalDb"));

        public DbSet<Note> Notes { get; set; }

        

    }
}
