using Bogus;
using System.Collections.Generic;
using TUAvaliacao.Entities;
using TUAvaliacao.Tests.Builders;
using Xunit;

namespace TUAvaliacao.Tests
{
    public class TransacaoBancariaTest
    {
        private readonly Faker _faker;
        private readonly TransacaoBancaria _sut;

        public TransacaoBancariaTest()
        {
            _faker = new Faker();
            _sut = new TransacaoBancaria();
        }

        [Fact]
        public void CalcularSaldoPorCliente_DeveCalcularComSucesso_QuandoMultiplosObjetos()
        {
            // Arrange
            List<Transacao> listaMultipla = new List<Transacao>();
            Transacao transacao1 = new TransacaoBuilder().NomeValido()
                                                         .ValorValido()
                                                         .Build();

            Transacao transacao2 = new TransacaoBuilder().NomeValido()
                                                         .ValorValido()
                                                         .Build();
            
            Transacao transacao3 = new TransacaoBuilder().NomeValido()
                                                         .ValorValido()
                                                         .Build();

            listaMultipla.Add(transacao1);
            listaMultipla.Add(transacao2);
            listaMultipla.Add(transacao3);

            // Act & Assert
            _sut.CalcularSaldoPorCliente(listaMultipla);
        }

        [Fact]
        public void CalcularSaldoPorCliente_DeveRetornarHistoricoVazio_QuandoListaNulaOuVazia()
        {
            // Arrange
            List<Transacao> listaNula = new List<Transacao>();

            // Act & Assert
            _sut.CalcularSaldoPorCliente(listaNula);
        }

        [Fact]
        public void CalcularSaldoPorCliente_DeveCalcularComSucesso_QuandoUnicoObjeto()
        {
            // Arrange
            List<Transacao> listaUnica = new List<Transacao>();
            Transacao transacao = new TransacaoBuilder().NomeValido()
                                                         .ValorValido()
                                                         .Build();
            listaUnica.Add(transacao);

            // Act & Assert
            _sut.CalcularSaldoPorCliente(listaUnica);
        }

        [Fact]
        public void CalcularSaldoPorCliente_DeveIgnorarTransacao_QuandoValorNulo()
        {
            // Arrange
            List<Transacao> listaComNull = new List<Transacao>();
            Transacao transacao1 = new Transacao
            {
                Cliente = "Arthur",
                Valor = 100
            };

            Transacao transacao2 = new Transacao
            {
                Cliente = "Arthur",
                Valor = 0
            };

            Transacao transacao3 = new Transacao
            {
                Cliente = "Arthur",
                Valor = 200
            };

            listaComNull.Add(transacao1);
            listaComNull.Add(transacao2);
            listaComNull.Add(transacao3);

            var expectedResult = new Dictionary<string, decimal>
            {
                { "Arthur", 300 }
            };
            var result = _sut.CalcularSaldoPorCliente(listaComNull);

            // Act & Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalcularSaldoPorCliente_DeveCalcularCorretamente_QuandoSaldoNegativo()
        {
            // Arrange
            List<Transacao> listaComNull = new List<Transacao>();
            Transacao transacao1 = new Transacao
            {
                Cliente = "Arthur",
                Valor = -100
            };

            Transacao transacao2 = new Transacao
            {
                Cliente = "Arthur",
                Valor = -10
            };

            Transacao transacao3 = new Transacao
            {
                Cliente = "Arthur",
                Valor = 200
            };

            listaComNull.Add(transacao1);
            listaComNull.Add(transacao2);
            listaComNull.Add(transacao3);

            var expectedResult = new Dictionary<string, decimal>
            {
                { "Arthur", 90 }
            };
            var result = _sut.CalcularSaldoPorCliente(listaComNull);

            // Act & Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
