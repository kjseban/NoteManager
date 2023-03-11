using NoteManager.Data;
using NoteManager.Models;
using NoteManager.Repository.IRepository;

namespace NoteManager.Repository
{
    public class AddEditDeleteLogRepository : Repository<AddEditDeleteLog>, IAddEditDeleteLogRepository
    {
        private ApplicationDbContext _db;

        public AddEditDeleteLogRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AddEditDeleteLog obj)
        {
            _db.AddEditDeleteLogs.Update(obj);
        }
    }
}
