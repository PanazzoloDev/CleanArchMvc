using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Criar produto com parametros válidos")]
        public void CreateProduct_WithValidParametes_ObjectValidState()
        {
            Action action = () => new Product(
                id: 1,
                name: "Produto A",
                description: "Descrição do produto",
                price: 10.99,
                stock: 10,
                image: ""
            );

            action
                .Should()
                .NotThrow<Validations.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Criar produto sem id")]
        public void CreateProduct_WithoutId_ObjectValidState()
        {
            Action action = () => new Product(
                name: "Produto A",
                description: "Descrição do produto",
                price: 10.99,
                stock: 10,
                image: ""
            );

            action
                .Should()
                .NotThrow<Validations.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Criar produto com id igual á 0")]
        public void CreateProduct_WithId0_DomainException()
        {
            Action action = () => new Product(
                id: 0,
                name: "Produto A",
                description: "Descrição do produto",
                price: 10.99,
                stock: 10,
                image: ""
            );

            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo Id inválido, menor ou igual á 0 não permitido");
        }


        [Fact(DisplayName = "Criar produto com id negativo")]
        public void CreateProduct_WithNegativeId_DomainException()
        {
            Action action = () => new Product(
                id: -1,
                name: "Produto A",
                description: "Descrição do produto",
                price: 10.99,
                stock: 10,
                image: ""
            );

            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo Id inválido, menor ou igual á 0 não permitido");
        }


        [Fact(DisplayName = "Criar produto com nome curto")]
        public void CreateProduct_WithShortName_DomainException()
        {
            Action action = () => new Product(
                name: "oi",
                description: "Descrição do produto",
                price: 10.99,
                stock: 10,
                image: ""
            );

            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo nome inválido, mínimo 3 carácteres");
        }


        [Fact(DisplayName = "Criar produto com nome longo")]
        public void CreateProduct_WithLongName_DomainException()
        {
            Action action = () => new Product(
                name: "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee",
                description: "Descrição do produto",
                price: 10.99,
                stock: 10,
                image: ""
            );

            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo nome inválido, máximo 50 carácteres");
        }

        [Fact(DisplayName = "Criar produto com descrição curta")]
        public void CreateProduct_WithShortDescription_DomainException()
        {
            Action action = () => new Product(
                name: "Produto A",
                description: "Desc",
                price: 10.99,
                stock: 10,
                image: ""
            );

            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo descrição inválido, mínimo 5 carácteres");
        }


        [Fact(DisplayName = "Criar produto com descrição longa")]
        public void CreateProduct_WithLongDescription_DomainException()
        {
            Action action = () => new Product(
                name: "Produto A",
                description: new string(
                    Enumerable
                        .Range(1, 251)
                        .Select(_ => (char)new Random()
                            .Next(0, 9))
                            .ToArray()),
                price: 10.99,
                stock: 10,
                image: ""
            );

            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo descrição inválido, máximo 250 carácteres");
        }

        [Fact(DisplayName = "Criar produto com image null")]
        public void CreateProduct_WithNullImage_NullReferenceException()
        {
            Action action = () => new Product(
                name: "Produto A",
                description: "Descrição do produto",
                price: 10.99,
                stock: 10,
                image: null
            );

            action
                .Should()
                .NotThrow<NullReferenceException>();
        }


        [Fact(DisplayName = "Criar produto com url da imagem longa")]
        public void CreateProduct_WithLongImage_DomainException()
        {
            Action action = () => new Product(
                name: "Produto A",
                description: "Descrição do produto",
                price: 10.99,
                stock: 10,
                image: new string(
                    Enumerable
                        .Range(1, 251)
                        .Select(_ => (char)new Random()
                            .Next(0, 9))
                            .ToArray())
            );

            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo image inválido, máximo 250 carácteres");
        }


        [Fact(DisplayName = "Criar produto com preço negativo")]
        public void CreateProduct_WithNegativePrice_DomainException()
        {
            Action action = () => new Product(
                name: "Produto A",
                description: "Descrição do produto",
                price: -10.99,
                stock: 10,
                image: ""
            );

            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo preço inválido, menor que 0 não permitido");
        }


        [Fact(DisplayName = "Criar produto com estoque negativo")]
        public void CreateProduct_WithNegativeStock_DomainException()
        {
            Action action = () => new Product(
                name: "Produto A",
                description: "Descrição do produto",
                price: 10.99,
                stock: -2,
                image: ""
            );

            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo estoque inválido, menor que 0 não permitido");
        }
    }
}