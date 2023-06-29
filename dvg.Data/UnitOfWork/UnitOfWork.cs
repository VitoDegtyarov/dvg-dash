using dvg.Data.Repositories.Interfaces;

namespace dvg.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        
        private readonly Lazy<IDesignerRepository> _designerRepository;

        public UnitOfWork(
            ApplicationContext context, 
            Lazy<IDesignerRepository> designerRepository
            )
        {
            _context = context;
            _designerRepository = designerRepository;
        }

        public IDesignerRepository DesignerRepository => _designerRepository.Value;
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
