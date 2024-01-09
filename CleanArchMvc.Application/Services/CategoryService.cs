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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository repo,
            IMapper mapper
        )
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryDTO category)
        {
            var entity = _mapper.Map<Category>(category);
            await _repo.CreateAsync(entity);
        }

        public async Task DeleteAsync(long? id)
        {
            var entity = _repo.GetByIdAsync(id).Result;
            await _repo.DeleteAsync(entity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(entities);
        }

        public async Task<CategoryDTO> GetByIdAsync(long? id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(entity);
        }

        public async Task UpdateAsync(CategoryDTO category)
        {
            var entity = _mapper.Map<Category>(category);
            await _repo.UpdateAsync(entity);
        }
    }
}
