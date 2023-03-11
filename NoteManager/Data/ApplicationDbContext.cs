using Microsoft.EntityFrameworkCore;
using NoteManager.Models;

namespace NoteManager.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
           
        }
        public DbSet<Note> Notes { get; set; }

    }
}
