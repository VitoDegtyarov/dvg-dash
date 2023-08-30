using dvg.Data.Entities;
using dvg.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace dvg.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger _logger;
        public ClientRepository(ApplicationContext context, ILogger logger)  : base(context, logger) 
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
