using System;

namespace TUAvaliacao
{
    public class Fatoriais
    {
        public int CalcularFatorial(int numero)
        {
            if (numero < 0)
            {
                throw new ArgumentException("O número fatorial não pode ser negativo.");
            }
            else if (numero == 0)
            {
                return 1;
            }
            else
            {
                return numero *= CalcularFatorial(numero - 1);
            }
        }
    }
}