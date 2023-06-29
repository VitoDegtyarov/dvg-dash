using dvg.Data.Entities;
using dvg.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dvg.Data.Repositories
{
    public class DesignerRepository : RepositoryBase<Designer>, IDesignerRepository
    {
        private readonly ApplicationContext _context;
        public DesignerRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Designer> GetByIdAsync(Guid id)
        {
            return await _context.Designers.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
