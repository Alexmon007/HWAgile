using AgileHW.DataAccess.Context;
using AgileHW.DataAccess.DBModels;
using AgileHW.DataAccess.Repositories;
using AutoMapper;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileHW.Business.Managers
{
    public class ProductManager
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductManager(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
            this._mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<List<ProductDTO>, List<Product>>();
            }).CreateMapper();

        }
        public ICollection<ProductDTO> getAll()
        {
            return _mapper.Map<List<Product>, List<ProductDTO>>(_productRepository.getAll().ToList()); ;
        }
        public void Add(ProductDTO product)
        {
            this._productRepository.Add(_mapper.Map<ProductDTO,Product>(product));
        }
    }
}
