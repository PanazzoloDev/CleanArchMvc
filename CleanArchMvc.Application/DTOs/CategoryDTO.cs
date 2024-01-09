using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = "O campo Id é obrigatório")]
        public long Id { get; set; }

        [MaxLength(40), MinLength(3)]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
    }
}
