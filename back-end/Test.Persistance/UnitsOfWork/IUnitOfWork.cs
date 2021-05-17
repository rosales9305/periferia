using System.Threading.Tasks;
using Test.Model.Entities;
using Test.Persistance.Repository;

namespace Test.Persistance.UnitsOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Product> ProductRepository { get; }

        void Save();

        Task<int> SaveAsync();
    }
}