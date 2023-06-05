using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimplifyLink.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyLink.Domain.Repositories
{
    public class MyDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<LinkModel> LinkEntity { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
