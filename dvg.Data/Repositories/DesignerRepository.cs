using dvg.Data.Entities;
using dvg.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace dvg.Data.Repositories
{
    public class DesignerRepository : RepositoryBase<Designer>, IDesignerRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger _logger;

        public DesignerRepository(ApplicationContext context, ILogger logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
