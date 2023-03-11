using NoteManager.Models;

namespace NoteManager.Repository.IRepository
{
    public interface INoteRepository :IRepository<Note>
    {
        void Update(Note obj);
    }
}
