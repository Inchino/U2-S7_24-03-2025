using System;
using Microsoft.EntityFrameworkCore;
using U2_S7_Lezioni.Models;

namespace U2_S7_Lezioni.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }

    }
}
