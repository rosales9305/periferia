using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Test.Model.Context;
using Test.Model.Entities;
using Test.Persistance.Repository;

namespace Test.Persistance.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Product> ProductRepository { get; private set; }
        
        private readonly TestContext _context;

        public UnitOfWork(TestContext context)
        {
            _context = context;
            ProductRepository = new Repository<Product>(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
