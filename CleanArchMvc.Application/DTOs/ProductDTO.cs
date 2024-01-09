using CleanArchMvc.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "O campo Id é obrigatório")]
        public long Id { get; set; }

        [MaxLength(50), MinLength(5)]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }

        [MaxLength(250), MinLength(5)]
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo preço é obrigatório")]
        public double Price { get; set; }

        [Required(ErrorMessage = "O campo estoque é obrigatório")]
        [Range(1, 9999, ErrorMessage = "Intervalo de estoque permitido 1 - 9999")]
        public int Stock { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [Required(ErrorMessage = "O campo categoryId é obrigatório")]
        public long CategoryId { get; set; }

        public Category Category { get; set; }
    }
}