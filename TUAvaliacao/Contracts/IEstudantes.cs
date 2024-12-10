using System;
using System.Collections.Generic;
using System.Text;
using TUAvaliacao.Entities;

namespace TUAvaliacao.Contracts
{
    public interface IEstudantes
    {
        public List<string> ClassificarEstudantes(List<Estudante> estudantes);
        public bool ListaVazia(List<Estudante> estudantes);
    }
}
