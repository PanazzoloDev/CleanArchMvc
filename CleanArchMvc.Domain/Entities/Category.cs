using CleanArchMvc.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Domain.Entities
{
    [Table("categories")]
    public sealed class Category : EntityBase
    {
        [Column("name"), MaxLength(40), MinLength(3), Required]
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public Category(int id, string name)
        {
            ValidateDomain(name, id);
        }
        public Category(string name)
        {
            ValidateDomain(name);
        }
        public void UpdateName(string name)
        {
            ValidateDomain(name);
        }
        private void ValidateDomain(string name, long? id = null)
        {
            if (id.HasValue)
            {
                DomainExceptionValidation.When(id <= 0,
                    "Campo Id inválido, menor ou igual á 0 não permitido");
                Id = id.Value;
            }

            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Campo nome inválido, obrigatório");

            DomainExceptionValidation.When(name.Length < 3,
                "Campo nome inválido, mínimo 3 carácteres");

            DomainExceptionValidation.When(name.Length > 40,
                "Campo nome inválido, máximo 40 carácteres");

            Name = name;
        }
    }
}