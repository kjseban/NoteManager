using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NoteManager.Models;

namespace NoteManager.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
           
        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<AddEditDeleteLog> AddEditDeleteLogs { get; set; }  

    }
}
