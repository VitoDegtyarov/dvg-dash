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
            LogInformation($"Get user with id: {id}");
            try
            {
                return await _context.Designers.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                LogError($"Error getting user witd ID: {id}", ex);
                throw;
            }
        }

        public override Task InsertAsync(Designer entity)
        {
            LogInformation($"Creating new designer: {entity.FirstName} {entity.LastName}");
            try
            {
                return base.InsertAsync(entity);
            }
            catch (Exception ex)
            {
                LogError($"Error creating designer: {entity.FirstName} {entity.LastName}", ex);
                throw;
            }
        }
    }
}
