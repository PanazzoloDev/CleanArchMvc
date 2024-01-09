using CleanArchMvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();

        Task<ProductDTO> GetByIdAsync(long? id);

        Task CreateAsync(ProductDTO product);

        Task UpdateAsync(ProductDTO product);

        Task DeleteAsync(long? id); 
    }
}
