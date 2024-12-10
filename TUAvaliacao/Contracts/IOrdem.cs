using System;
using System.Collections.Generic;
using System.Text;

namespace TUAvaliacao.Contracts
{
    public interface IOrdem
    {
        public List<string> OrdenarStrings(List<string> palavras = null);
        public bool ListaVazia(List<string> palavras);
    }
}
