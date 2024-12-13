using Bogus;
using System;
using System.Collections.Generic;
using TUAvaliacao.Entities;
using Xunit;

namespace TUAvaliacao.Tests
{
    public class ProdutosTest
    {
        private readonly Produtos _sut;
        private readonly Faker _faker;

        public ProdutosTest()
        {
            _sut = new Produtos();
            _faker = new Faker();
        }

        [Theory]
        [MemberData(nameof(ObjectGeneratorMultiplasCategorias))]
        public void AgruparPorCategoria_DeveAgruparCorretamente_QuandoMultiplosObjetos
                    (Produto produto)
        {
            // Arrange
            List<Produto> listaMultipla = new List<Produto>();
            listaMultipla.Add(produto);

            // Act & Assert
            _sut.AgruparPorCategoria(listaMultipla);
        }

        [Theory]
        [MemberData(nameof(ObjectGeneratorUnicaCategorias))]
        public void AgruparPorCategoria_DeveAgruparCorretamente_QuandoUnicoObjeto
                    (Produto produto)
        {
            // Arrange
            List<Produto> listaUnica = new List<Produto>();
            listaUnica.Add(produto);

            // Act & Assert
            _sut.AgruparPorCategoria(listaUnica);
        }

        [Fact]
        public void AgruparPorCategoria_DeveRetornarListaVazia_QuandoInputVazioOuNulo()
        {
            // Arrange
            List<Produto> listaNula = new List<Produto>();

            // Act & Assert
            _sut.AgruparPorCategoria(listaNula);
        }

        [Fact]
        public void AgruparPorCategoria_DeveEmitirException_QuandoObjetoSemCategoria()
        {
            // Arrange
            List<Produto> listaSemCategoria = new List<Produto>();
            Produto produto = new Produto
            {
                Nome = "a",
                Preco = 10
            };
            listaSemCategoria.Add(produto);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sut.AgruparPorCategoria
                                                        (listaSemCategoria));
        }

        public static IEnumerable<object[]> ObjectGeneratorMultiplasCategorias()
        {
            yield return new object[]
            {
                new Produto
                {
                    Categoria = "Banheiro",
                    Nome = "Chuveiro",
                    Preco = 30
                }
            };

            yield return new object[]
            {
                new Produto
                {
                    Categoria = "Eletrodomestico",
                    Nome = "Geladeira",
                    Preco = 1000
                }
            };

            yield return new object[]
            {
                new Produto
                {
                    Categoria = "Eletrodomestico",
                    Nome = "Fogao",
                    Preco = 500
                }
            };

            yield return new object[]
            {
                new Produto
                {
                    Categoria = "Eletronico",
                    Nome = "Celular",
                    Preco = 100
                }
            };

            yield return new object[]
            {
                new Produto
                {
                    Categoria = "Banheiro",
                    Nome = "Vaso Sanitário",
                    Preco = 20
                }
            };
        }

        public static IEnumerable<object[]> ObjectGeneratorUnicaCategorias()
        {
            yield return new object[]
            {
                new Produto
                {
                    Categoria = "Eletrodomestico",
                    Nome = "Geladeira",
                    Preco = 1000
                }
            };

            yield return new object[]
            {
                new Produto
                {
                    Categoria = "Eletrodomestico",
                    Nome = "Fogao",
                    Preco = 500
                }
            };

            yield return new object[]
            {
                new Produto
                {
                    Categoria = "Eletrodomestico",
                    Nome = "Microondas",
                    Preco = 100
                }
            };
        }
    }
}
