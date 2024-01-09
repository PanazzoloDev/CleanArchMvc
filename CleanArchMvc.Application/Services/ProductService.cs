using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository repo,
            IMapper mapper
        )
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            await _repo.CreateAsync(entity);
        }

        public async Task DeleteAsync(long? id)
        {
            var entity = _repo.GetByIdAsync(id).Result;
            await _repo.DeleteAsync(entity);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(entities);
        }

        public async Task<ProductDTO> GetByIdAsync(long? id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task UpdateAsync(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            await _repo.UpdateAsync(entity);
        }
    }
}
