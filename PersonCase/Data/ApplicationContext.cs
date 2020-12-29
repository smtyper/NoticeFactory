using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonCase.Models;

namespace PersonCase.Data
{
    public class ApplicationContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Note> Notes { get; protected set; }

        public DbSet<NoteAddition> NoteAdditions { get; protected set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
