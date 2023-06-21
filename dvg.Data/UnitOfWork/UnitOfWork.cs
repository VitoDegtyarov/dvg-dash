using dvg.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IDesignerRepository Designer => _designerRepository.Value;
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
