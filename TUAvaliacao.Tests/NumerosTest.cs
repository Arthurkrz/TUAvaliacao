using System;
using System.Collections.Generic;
using Moq;
using Bogus;
using System.Text;
using TUAvaliacao.Contracts;
using Xunit;


namespace TUAvaliacao.Tests
{
    public class NumerosTest
    {
        private readonly Numeros _sut;
        private readonly Faker _faker;
        private readonly Mock<INumeros> _mockRepository;

        public NumerosTest()
        {
            _sut = new Numeros();
            _faker = new Faker();
            _mockRepository = new Mock<INumeros>();
        }

        [Theory]
        [MemberData(nameof(ListGenerator))]
        public void VerificarSequencia_DeveRetornarMensagemCorreta_Em4ListasPossiveis
                    (string expectedResult, List<int> numeros)
        {
            // Act
            string result = _sut.VerificarSequencia(numeros);
            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public void VerificarSequencia_DeveRetornarErro_QuandoNenhumNumero()
        {
            // Arrange
            List<int> listaNula = new List<int>();
            List<int> listaVazia = new List<int>();
            listaVazia.Add(0);

            _mockRepository.Setup(x => x.ListaVazia(listaNula)).Returns(true);
            _mockRepository.Setup(x => x.ListaVazia(listaVazia)).Returns(true);

            // Act & Assert
            _sut.VerificarSequencia(listaNula);
            _sut.VerificarSequencia(listaVazia);
        }

        public static IEnumerable<object[]> ListGenerator()
        {
            yield return new object[] { "Crescente.", new List<int> { 1, 2, 3, 4, 5 } };
            yield return new object[] { "Decrescente.", new List<int> { 5, 4, 3, 2, 1 } };
            yield return new object[] { "Nenhum.", new List<int> { 4, 2, 5, 0, 7 } };
            yield return new object[] { "Nenhum.", new List<int> { 1, 1, 1, 1, 1 } };
            yield return new object[] { "Lista contém apenas 1 número.", new List<int> { 1 }};
        }
    }
}