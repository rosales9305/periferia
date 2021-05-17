using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Model.Entities;
using Test.Persistance.UnitsOfWork;
using Test.Shared.DTO;
using Test.Shared.Utils.Exceptions;

namespace Test.Persistance.Services
{

    /// <summary>
    /// Synchronous Service to handle all Products Persistance actions
    /// </summary>
    public class ProductSevice : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductSevice(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            try
            {
                var products = _unitOfWork.ProductRepository.Get();
                return _mapper.Map<IEnumerable<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductDTO GetById(int id)
        {
            try
            {
                return _mapper.Map<ProductDTO>(_unitOfWork.ProductRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductDTO Create(ProductDTO dto)
        {
            try
            {
                dto.Id = 0;
                var product = _mapper.Map<Product>(dto);
                var result = _unitOfWork.ProductRepository.Insert(product);

                _unitOfWork.Save();
                return _mapper.Map<ProductDTO>(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(int id, ProductDTO dto)
        {
            try
            {
                var product = _unitOfWork.ProductRepository.GetById(id);
                if (product is null) throw new EntityNotFoundException();

                product.Name = dto.Name;
                product.Price = dto.Price;
                product.Stock = dto.Stock;
                product.Color = dto.Color;

                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var product = _unitOfWork.ProductRepository.GetById(id);
                if (product is null) throw new EntityNotFoundException();

                _unitOfWork.ProductRepository.Delete(product);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
