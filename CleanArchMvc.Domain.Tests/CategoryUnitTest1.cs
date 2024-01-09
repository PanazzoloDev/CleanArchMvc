using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Criar Categoria com parametros válidos")]
        public void CreateCategory_WithValidParametes_ObjectValidState()
        {
            Action action = () => new Category(1, "Categoria teste");
            action
                .Should()
                .NotThrow<Validations.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Criar Categoria com id negativo")]
        public void CreateCategory_WithNegativeId_DomainException()
        {
            Action action = () => new Category(-1, "Categoria teste");
            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo Id inválido, menor ou igual á 0 não permitido");
        }


        [Fact(DisplayName = "Criar Categoria com id igual á 0")]
        public void CreateCategory_WithId0_DomainException()
        {
            Action action = () => new Category(0, "Categoria teste");
            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo Id inválido, menor ou igual á 0 não permitido");
        }


        [Fact(DisplayName = "Criar Categoria com nome null")]
        public void CreateCategory_WithNullName_DomainException()
        {
            Action action = () => new Category(1, null);
            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo nome inválido, obrigatório");
        }


        [Fact(DisplayName = "Criar Categoria com nome vazio")]
        public void CreateCategory_WithEmptyName_DomainException()
        {
            Action action = () => new Category(1, "");
            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo nome inválido, obrigatório");
        }


        [Fact(DisplayName = "Criar Categoria com nome curto")]
        public void CreateCategory_WithShortName_DomainException()
        {
            Action action = () => new Category(1, "oi");
            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo nome inválido, mínimo 3 carácteres");
        }


        [Fact(DisplayName = "Criar Categoria com nome longo")]
        public void CreateCategory_WithLongName_DomainException()
        {
            Action action = () => new Category(1, "testestestestestestestestestestestesteste");
            action
                .Should()
                .Throw<Validations.DomainExceptionValidation>()
                .WithMessage("Campo nome inválido, máximo 40 carácteres");
        }
    }
}