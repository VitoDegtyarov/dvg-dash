using dvg.Data.Entities;
using dvg.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dvg.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        private readonly ApplicationContext _context;
        public ClientRepository(ApplicationContext context)  : base(context) 
        {
            _context = context;
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
