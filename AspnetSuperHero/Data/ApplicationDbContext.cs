using System;
using System.Collections.Generic;
using System.Text;
using AspnetSuperHero.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspnetSuperHero.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<SuperHero> Heros { get; set; }
        
    }
}
