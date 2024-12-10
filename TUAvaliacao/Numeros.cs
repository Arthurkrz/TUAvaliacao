using System;
using System.Collections.Generic;
using System.Text;
using TUAvaliacao.Contracts;

namespace TUAvaliacao
{
    public class Numeros : INumeros
    {
        public string VerificarSequencia(List<int> numeros)
        {
            if (ListaVazia(numeros))
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
        public bool ListaVazia(List<int> numeros)
        {
            if (numeros.Count == 0)
            {   
                return true;
            }
            else
            {
                foreach (var numero in numeros)
                {
                    if (numero != 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
