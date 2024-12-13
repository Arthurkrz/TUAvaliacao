using System;

namespace TUAvaliacao
{
    public class Fatoriais
    {
        public int CalcularFatorial(int numero)
        {
            int resultado = 1;
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
                for (int i = 1; i <= numero; i++)
                {
                    resultado *= i;
                }
            }

            return resultado;
        }
    }
}