﻿using Microsoft.EntityFrameworkCore;

namespace ReactApplicationusingASPMVC5.Server.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
    }
}
