using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        
        Task<CategoryDTO> GetByIdAsync(long? id);
        
        Task CreateAsync(CategoryDTO category);
        
        Task UpdateAsync(CategoryDTO category);
        
        Task DeleteAsync(long? id);
    }
}
