using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using TUAvaliacao.Entities;

namespace TUAvaliacao.Tests.Builders
{
    internal class EstudanteBuilder
    {
        private readonly Estudante _estudante;
        private readonly Faker _faker;

        public EstudanteBuilder()
        {
            _estudante = new Estudante();
            _faker = new Faker();
        }

        public Estudante Build() => _estudante;

        public EstudanteBuilder NomeValido(string nome = null)
        {
            if (nome == null)
                nome = _faker.Name.FirstName();

            _estudante.Nome = nome;
            return this;
        }

        public EstudanteBuilder NotaValida(decimal nota = 0)
        {
            if (nota == 0)
                nota = _faker.Random.Decimal(1, 10);

            _estudante.Nota = nota;
            return this;
        }

        public EstudanteBuilder NotaNegativa(decimal nota = 0)
        {
            if (nota == 0)
                nota = _faker.Random.Decimal(-1, -10);

            _estudante.Nota = nota;
            return this;
        }

        public EstudanteBuilder NotaExtrema(decimal nota = 0)
        {
            if (nota == 0)
                nota = _faker.Random.Decimal(10, 100);

            _estudante.Nota = nota;
            return this;
        }
    }
}
