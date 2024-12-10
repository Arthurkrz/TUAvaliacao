using System;
using Xunit;
using Moq;
using TUAvaliacao.Tests.Builders;
using System.Collections.Generic;
using System.Text;
using Bogus;
using TUAvaliacao.Contracts;
using TUAvaliacao.Entities;

namespace TUAvaliacao.Tests
{
    public class EstudantesTest
    {
        private readonly Mock<IEstudantes> _mockRepository;
        private readonly Estudantes _sut;
        private readonly Faker _faker;

        [Theory]
        [MemberData(nameof(ListGenerator))]
        public void ClassificarEstudantes_DeveClassificarCorretamente
                    (List<Estudante> estudantes)
        {

        }

        [Theory]
        [MemberData(nameof(ListGeneratorNomesIguais))]
        public void ClassificarEstudantes_DeveOrdenarCorretamente_QuandoNomesIguais
                    (List<Estudante> estudante)
        {

        }

        [Fact]
        public void OrdenarStrings_DeveRetornarListaVazia_QuandoInputNuloOuVazio()
        {
            // Arrange
            List<Estudante> listaNula = new List<Estudante>();
            List<Estudante> listaVazia = new List<Estudante>();
            Estudante estudante = new Estudante();
            listaVazia.Add(estudante);

            _mockRepository.Setup(x => x.ListaVazia(listaNula)).Returns(true);
            _mockRepository.Setup(x => x.ListaVazia(listaVazia)).Returns(true);

            // Act & Assert
            _sut.ClassificarEstudantes(listaNula);
            _sut.ClassificarEstudantes(listaVazia);
        }

        [Fact]
        public void ClassificarEstudantes_DeveEmitirException_QuandoNotasNegativasOuExtremas()
        {
            // Arrange
            List<Estudante> listaComNegativo = new List<Estudante>();
            Estudante estudante1 = new EstudanteBuilder().NomeValido().NotaValida().Build();
            Estudante estudanteNegativo = new EstudanteBuilder().NomeValido().NotaNegativa().Build();

            listaComNegativo.Add(estudante1);
            listaComNegativo.Add(estudanteNegativo);

            List<Estudante> listaComExtremo = new List<Estudante>();
            Estudante estudante2 = new EstudanteBuilder().NomeValido().NotaValida().Build();
            Estudante estudanteExtremo = new EstudanteBuilder().NomeValido().NotaExtrema().Build();

            listaComExtremo.Add(estudante2);
            listaComExtremo.Add(estudanteExtremo);

            _mockRepository.Setup(x => x.ListaVazia(listaComNegativo)).Returns(false);
            _mockRepository.Setup(x => x.ListaVazia(listaComExtremo)).Returns(false);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sut.ClassificarEstudantes(listaComNegativo));
            Assert.Throws<ArgumentException>(() => _sut.ClassificarEstudantes(listaComExtremo));
        }

        public static IEnumerable<object[]> ListGenerator()
        {
            yield return new object[]
            {
                new EstudanteBuilder().NomeValido().NotaValida().Build()
            };

            yield return new object[]
            {
                new EstudanteBuilder().NomeValido().NotaValida().Build()
            };

            yield return new object[]
            {
                new EstudanteBuilder().NomeValido().NotaValida().Build()
            };

            yield return new object[]
            {
                new EstudanteBuilder().NomeValido().NotaValida().Build()
            };

            yield return new object[]
            {
                new EstudanteBuilder().NomeValido().NotaValida().Build()
            };
        }

        public static IEnumerable<object[]> ListGeneratorNomesIguais()
        {
            yield return new object[]
            {
                new EstudanteBuilder().NomeValido("Arthur").NotaValida().Build()
            };

            yield return new object[]
            {
                new EstudanteBuilder().NomeValido("Arthur").NotaValida().Build()
            };

            yield return new object[]
            {
                new EstudanteBuilder().NomeValido("Arthur").NotaValida().Build()
            };

            yield return new object[]
            {
                new EstudanteBuilder().NomeValido("Arthur").NotaValida().Build()
            };

            yield return new object[]
            {
                new EstudanteBuilder().NomeValido("Arthur").NotaValida().Build()
            };
        }
    }
}