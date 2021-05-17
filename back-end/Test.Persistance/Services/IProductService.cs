using System;
using System.Collections.Generic;
using System.Text;
using Test.Shared.DTO;

namespace Test.Persistance.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAll();
        ProductDTO GetById(int id);
        ProductDTO Create(ProductDTO dto);
        void Update(int id, ProductDTO dto);
        void Delete(int id);

    }
}
