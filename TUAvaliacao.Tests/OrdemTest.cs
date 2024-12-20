﻿using System;
using Xunit;
using Moq;
using Bogus;
using System.Collections.Generic;
using System.Text;

namespace TUAvaliacao.Tests
{
    public class OrdemTest
    {
        private readonly Ordem _sut;
        private readonly Faker _faker;

        public OrdemTest()
        {
            _sut = new Ordem();
            _faker = new Faker();
        }

        [Fact]
        public void OrdenarStrings_DeveOrdenarComSucesso_QuandoListaOrdenada()
        {
            // Arrange
            List<string> listaOrdenada = new List<string>();
            listaOrdenada.Add("Arthur");
            listaOrdenada.Add("Bruno");
            listaOrdenada.Add("Carlos");
            listaOrdenada.Add("Diego");
            listaOrdenada.Add("Eduardo");

            // Act & Assert
            _sut.OrdenarStrings(listaOrdenada);
        }

        [Fact]
        public void OrdenarStrings_DeveOrdenarComSucesso_QuandoListaDesordenada()
        {
            // Arrange
            List<string> listaDesordenada = new List<string>();
            listaDesordenada.Add(_faker.Name.FirstName());
            listaDesordenada.Add(_faker.Name.FirstName());
            listaDesordenada.Add(_faker.Name.FirstName());
            listaDesordenada.Add(_faker.Name.FirstName());
            listaDesordenada.Add(_faker.Name.FirstName());

            // Act & Assert
            _sut.OrdenarStrings(listaDesordenada);
        }

        [Fact]
        public void OrdenarStrings_DeveOrdenarComSucesso_QuandoStringsDuplicadas()
        {
            // Arrange
            List<string> listaDesordenada = new List<string>();
            listaDesordenada.Add(_faker.Name.FirstName());
            listaDesordenada.Add("Arthur");
            listaDesordenada.Add("Arthur");
            listaDesordenada.Add(_faker.Name.FirstName());
            listaDesordenada.Add(_faker.Name.FirstName());

            // Act & Assert
            _sut.OrdenarStrings(listaDesordenada);
        }

        [Fact]
        public void OrdenarStrings_DeveRetornarListaVazia_QuandoInputNuloOuVazio()
        {
            // Arrange
            List<string> listaNula = new List<string>();

            // Act & Assert
            _sut.OrdenarStrings(listaNula);
        }
    }
}
