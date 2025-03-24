using System;
using Microsoft.EntityFrameworkCore;

namespace U2_S7_Lezioni.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
            options) : base(options) { }

    }
}
