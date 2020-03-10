using System;
using System.Collections.Generic;
using System.Text;
using Asp2020Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asp2020Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<SiteUser> SiteUsers { get; set; }
    }
}
