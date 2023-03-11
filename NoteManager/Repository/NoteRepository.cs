using NoteManager.Data;
using NoteManager.Models;
using NoteManager.Repository.IRepository;

namespace NoteManager.Repository
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        private ApplicationDbContext _db;

        public NoteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Note obj)
        {
            _db.Notes.Update(obj);
        }
    }
}
