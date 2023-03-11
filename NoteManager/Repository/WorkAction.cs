using NoteManager.Data;
using NoteManager.Models;
using NoteManager.Repository.IRepository;

namespace NoteManager.Repository
{
    public class WorkAction: IWorkAction
    {
        private ApplicationDbContext _db;

            public WorkAction(ApplicationDbContext db) 
        {
            _db = db;
            Note = new NoteRepository(_db);
        }
        public INoteRepository Note { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
