using dvg.Data.Repositories.Interfaces;

namespace dvg.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDesignerRepository DesignerRepository { get; }
        IClientRepository ClientRepository { get; }

        Task SaveChanges();
    }
}
