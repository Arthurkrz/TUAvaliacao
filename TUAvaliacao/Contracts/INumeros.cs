using System;
using System.Collections.Generic;
using System.Text;

namespace TUAvaliacao.Contracts
{
    public interface INumeros
    {
        public string VerificarSequencia(List<int> numeros);
        public bool ListaVazia(List<int> numeros);
    }
}
