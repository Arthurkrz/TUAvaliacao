using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TUAvaliacao
{
    public class Numeros
    {
        public string VerificarSequencia(List<int> numeros)
        {
            if (numeros == null)
            {
                return "Lista Vazia ou Nula.";
            }
            
            if (numeros.Count == 1)
            {
                return "Lista contém apenas 1 número.";
            }

            bool crescente = true;
            bool decrescente = true;

            for (int i = 1; i < numeros.Count; i++)
            {
                if (numeros[i] > numeros[i - 1])
                {
                    decrescente = false;
                }
                else if (numeros[i] < numeros[i - 1])
                {
                    crescente = false;
                }
                else
                {
                    crescente = false;
                    decrescente = false;
                }
            }

            if (crescente)
            {
                return "Crescente.";
            }
            else if (decrescente)
            {
                return "Decrescente.";
            }
            else
            {
                return "Nenhum.";
            }
        }
    }
}
