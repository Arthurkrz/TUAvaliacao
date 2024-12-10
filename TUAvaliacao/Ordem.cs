using System;
using System.Collections.Generic;
using System.Text;
using TUAvaliacao.Contracts;

namespace TUAvaliacao
{
    public class Ordem : IOrdem
    {
        public List<string> OrdenarStrings(List<string> palavras = null)
        {
            if (ListaVazia(palavras))
            {
                List<string> listaVazia = new List<string>();
                return listaVazia;
            }
            else
            {
                palavras.Sort(StringComparer.OrdinalIgnoreCase);
                return palavras;
            }
        }
        public bool ListaVazia(List<string> palavras)
        {
            for (int i = 0; i < palavras.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(palavras[i]))
                {
                    return false;
                }

            }

            return true;
        }
    }
}
