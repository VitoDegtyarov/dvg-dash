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

        public async Task<List<Designer>> GetAllDesignerAsync()
        {
            return await _context.Designers.ToListAsync();
        }

        public override Task<Designer> InsertAsync(Designer entity)
        {
            return base.InsertAsync(entity);
        }
    }
}
