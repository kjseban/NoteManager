namespace NoteManager.Repository.IRepository
{
    public interface IWorkAction
    {
        INoteRepository Note { get; }

        void Save();

    }
}
