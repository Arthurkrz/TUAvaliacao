using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Bogus;
using TUAvaliacao.Entities;
using TUAvaliacao.Contracts;
using TUAvaliacao.Tests.Builders;
using Xunit;

namespace TUAvaliacao.Tests
{
    public class TransacaoBancariaTest
    {
        private readonly Faker _faker;
        private readonly Mock<ITransacao> _mockRepository;
        private readonly TransacaoBancaria _sut;

        public TransacaoBancariaTest()
        {
            _faker = new Faker();
            _mockRepository = new Mock<ITransacao>();
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

            _mockRepository.Setup(x => x.ListaVazia(listaMultipla)).Returns(false);

            // Act & Assert
            _sut.CalcularSaldoPorCliente(listaMultipla);
        }

        [Fact]
        public void CalcularSaldoPorCliente_DeveRetornarHistoricoVazio_QuandoListaNulaOuVazia()
        {
            // Arrange
            List<Transacao> listaNula = new List<Transacao>();
            List<Transacao> listaVazia = new List<Transacao>();
            listaVazia.Add(new TransacaoBuilder().Build());

            _mockRepository.Setup(x => x.ListaVazia(listaNula)).Returns(true);
            _mockRepository.Setup(x => x.ListaVazia(listaVazia)).Returns(true);

            // Act & Assert
            _sut.CalcularSaldoPorCliente(listaNula);
            _sut.CalcularSaldoPorCliente(listaVazia);
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

            _mockRepository.Setup(x => x.ListaVazia(listaUnica)).Returns(false);

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
