using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using TUAvaliacao.Entities;

namespace TUAvaliacao.Tests.Builders
{
    internal class TransacaoBuilder
    {
        private readonly Transacao _transacao;
        private readonly Faker _faker;

        public TransacaoBuilder()
        {
            _transacao = new Transacao();
            _faker = new Faker();
        }

        public Transacao Build() => _transacao;

        public TransacaoBuilder NomeValido(string nome = null)
        {
            if (nome == null)
                nome = _faker.Name.FirstName();

            _transacao.Cliente = nome;
            return this;
        }

        public TransacaoBuilder ValorValido(decimal valor = 0)
        {
            if (valor == 0)
                valor = _faker.Random.Decimal(0, 10000000);

            _transacao.Valor = valor;
            return this;
        }
    }
}
