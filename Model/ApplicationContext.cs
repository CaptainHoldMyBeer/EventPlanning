﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Model
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        //public DbSet<User> Users { get; set; } = null!;
        //public DbSet<Event> Events { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
