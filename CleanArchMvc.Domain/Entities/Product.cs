using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validations;

namespace CleanArchMvc.Domain.Entities
{
    [Table("products")]
    public sealed class Product : EntityBase
    {
        [Column("name"), MaxLength(50), MinLength(3), Required]
        public string Name { get; private set; }

        [Column("description"), MaxLength(250), MinLength(5), Required]
        public string Description { get; private set; }

        [Column("price"), Required]
        public double Price { get; private set; }

        [Column("stock"), Required]
        public int Stock { get; private set; }

        [Column("image_url")]
        public string Image { get; private set; }

        [Column("category_id"), Required]
        public long CategoryId { get; private set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public Product(long id, string name, string description, double price, int stock, string image)
        {
            ValidateDomain(
                id: id,
                name: name,
                description: description,
                price: price,
                stock: stock,
                image: image
            );
        }

        public Product(string name, string description, double price, int stock, string image)
        {
            ValidateDomain(
                id: null,
                name: name,
                description: description,
                price: price,
                stock: stock,
                image: image
            );
        }

        public void Update(string name, string description, double price, int stock, string image, long categoryId)
        {
            ValidateDomain(
                id: null,
                name: name,
                description: description,
                price: price,
                stock: stock,
                image: image
            );
            CategoryId = categoryId;
        }
        private void ValidateDomain(long? id, string name, string description, double price, int stock, string image)
        {
            if (id.HasValue)
            {
                DomainExceptionValidation.When(id <= 0,
                    "Campo Id inválido, menor ou igual á 0 não permitido");
                Id = id.Value;
            }

            DomainExceptionValidation.When(name.Length < 3,
                "Campo nome inválido, mínimo 3 carácteres");

            DomainExceptionValidation.When(name?.Length > 50,
                "Campo nome inválido, máximo 50 carácteres");

            DomainExceptionValidation.When(description.Length < 5,
                "Campo descrição inválido, mínimo 5 carácteres");

            DomainExceptionValidation.When(description.Length > 250,
                "Campo descrição inválido, máximo 250 carácteres");

            DomainExceptionValidation.When(price < 0,
                "Campo preço inválido, menor que 0 não permitido");

            DomainExceptionValidation.When(stock < 0,
                "Campo estoque inválido, menor que 0 não permitido");

            DomainExceptionValidation.When(image?.Length > 250,
                "Campo image inválido, máximo 250 carácteres");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}