using Bogus;
using System.Collections.Generic;
using Xunit;


namespace TUAvaliacao.Tests
{
    public class NumerosTest
    {
        private readonly Numeros _sut;
        private readonly Faker _faker;

        public NumerosTest()
        {
            _sut = new Numeros();
            _faker = new Faker();
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

            // Act & Assert
            _sut.VerificarSequencia(listaNula);
        }

        public static IEnumerable<object[]> ListGenerator()
        {
            yield return new object[] 
            { "Crescente.", new List<int> { 1, 2, 3, 4, 5 } };
            yield return new object[] 
            { "Decrescente.", new List<int> { 5, 4, 3, 2, 1 } };
            yield return new object[] 
            { "Nenhum.", new List<int> { 4, 2, 5, 0, 7 } };
            yield return new object[] 
            { "Nenhum.", new List<int> { 1, 1, 1, 1, 1 } };
            yield return new object[] 
            { "Lista contém apenas 1 número.", new List<int> { 1 }};
        }
    }
}