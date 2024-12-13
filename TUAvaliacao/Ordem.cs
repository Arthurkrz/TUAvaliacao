using System;
using System.Collections.Generic;
using System.Linq;

namespace TUAvaliacao
{
    public class Ordem
    {
        public List<string> OrdenarStrings(List<string> palavras = null)
        {
            if (palavras == null)
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
    }
}
