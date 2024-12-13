using System;
using Xunit;

namespace TUAvaliacao.Tests
{
    public class CalculoFatoriaisTest
    {
        private readonly Fatoriais _sut;

        public CalculoFatoriaisTest()
        {
            _sut = new Fatoriais();
        }

        [Theory]
        [InlineData(5, 120)]
        [InlineData(3, 6)]
        [InlineData(1, 1)]
        public void CalcularFatorial_DeveRetornarResultado_QuandoNumeroValido(int numero,
                                                                              int expectedResult)
        {
            // Act
            int result = _sut.CalcularFatorial(numero);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalcularFatorial_DeveRetornarUm_QuandoNumeroEhZero()
        {
            // Act
            int result = _sut.CalcularFatorial(0);
            int expectedResult = 1;

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalcularFatorial_DeveEmitirException_QuandoNumeroNegativo()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => 
                         _sut.CalcularFatorial(-1));
        }
    }
}