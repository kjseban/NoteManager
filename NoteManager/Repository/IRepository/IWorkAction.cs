namespace NoteManager.Repository.IRepository
{
    public interface IWorkAction
    {
        INoteRepository Note { get; }
        IAddEditDeleteLogRepository AddEditDeleteLog { get; }

        void Save();

    }
}
