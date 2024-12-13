using System;
using Xunit;
using Moq;
using TUAvaliacao.Tests.Builders;
using System.Collections.Generic;
using System.Text;
using Bogus;
using TUAvaliacao.Entities;

namespace TUAvaliacao.Tests
{
    public class EstudantesTest
    {
        private readonly Estudantes _sut;
        private readonly Faker _faker;

        public EstudantesTest()
        {
            _sut = new Estudantes();
            _faker = new Faker();
        }

        [Theory]
        [MemberData(nameof(ObjectGenerator))]
        public void ClassificarEstudantes_DeveClassificarCorretamente(List<Estudante> estudantes)
        {
            // Act
            _sut.ClassificarEstudantes(estudantes);

            // Assert
            for (int i = 1; i < estudantes.Count; i++)
            {
                Assert.True(String.Compare(estudantes[i].Nome, estudantes[i - 1].Nome) == 1);
            }

        }

        [Fact]
        public void ClassificarEstudantes_DeveOrdenarCorretamente_QuandoNomesIguais()
        {
            // Arrange
            List<Estudante> estudantes = new List<Estudante>();
            for (int i = 0; i < 5; i++)
            {
                estudantes.Add(new EstudanteBuilder()
                                   .NomeValido("Arthur").NotaValida().Build());

            }

            // Act
            _sut.ClassificarEstudantes(estudantes);

            // Assert
            for (int i = 1; i < estudantes.Count; i++)
            {
                Assert.True(estudantes[i].Nota <= estudantes[i - 1].Nota);
            }
            
        }

        [Fact]
        public void OrdenarStrings_DeveRetornarListaVazia_QuandoInputNuloOuVazio()
        {
            // Arrange
            List<Estudante> listaNula = new List<Estudante>();

            // Act & Assert
            _sut.ClassificarEstudantes(listaNula);
        }

        [Fact]
        public void ClassificarEstudantes_DeveEmitirException_QuandoNotasNegativasOuExtremas()
        {
            // Arrange
            List<Estudante> listaComNegativo = new List<Estudante>();
            Estudante estudante1 = new EstudanteBuilder()
                                       .NomeValido().NotaValida().Build();
            Estudante estudanteNegativo = new EstudanteBuilder()
                                              .NomeValido().NotaNegativa().Build();

            listaComNegativo.Add(estudante1);
            listaComNegativo.Add(estudanteNegativo);

            List<Estudante> listaComExtremo = new List<Estudante>();
            Estudante estudante2 = new EstudanteBuilder()
                                       .NomeValido().NotaValida().Build();
            Estudante estudanteExtremo = new EstudanteBuilder()
                                             .NomeValido().NotaExtrema().Build();

            listaComExtremo.Add(estudante2);
            listaComExtremo.Add(estudanteExtremo);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sut.ClassificarEstudantes
                                                        (listaComNegativo));
            Assert.Throws<ArgumentException>(() => _sut.ClassificarEstudantes
                                                        (listaComExtremo));
        }

        public static IEnumerable<object[]> ObjectGenerator()
        {
            yield return new object[]
            {
                new List<Estudante>
                {
                    new EstudanteBuilder()
                        .NomeValido().NotaValida().Build(),
                                            new EstudanteBuilder()
                        .NomeValido().NotaValida().Build(),
                                            new EstudanteBuilder()
                        .NomeValido().NotaValida().Build(),
                                            new EstudanteBuilder()
                        .NomeValido().NotaValida().Build(),
                                            new EstudanteBuilder()
                        .NomeValido().NotaValida().Build()
                }
            }; 
        }
    }
}