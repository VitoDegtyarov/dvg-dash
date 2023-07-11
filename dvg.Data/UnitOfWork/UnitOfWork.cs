using dvg.Data.Repositories.Interfaces;

namespace dvg.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly Lazy<IDesignerRepository> _designerRepository;
        private readonly Lazy<IClientRepository> _clientRepository;

        public UnitOfWork(
            ApplicationContext context, 
            Lazy<IDesignerRepository> designerRepository,
            Lazy<IClientRepository> clientRepository)
        {
            _context = context;
            _designerRepository = designerRepository;
            _clientRepository = clientRepository;
        }

        public IDesignerRepository DesignerRepository => _designerRepository.Value;
        public IClientRepository ClientRepository => _clientRepository.Value;

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
