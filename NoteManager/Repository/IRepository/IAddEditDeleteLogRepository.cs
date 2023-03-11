using NoteManager.Models;

namespace NoteManager.Repository.IRepository
{
    public interface IAddEditDeleteLogRepository : IRepository<AddEditDeleteLog>
    {
        void Update(AddEditDeleteLog obj);
    }
    
}
