using dvg.Data.Repositories.Interfaces;

namespace dvg.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDesignerRepository Designer { get; }

        public void SaveChanges();
    }
}
