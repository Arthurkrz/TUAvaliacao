using System;
using System.Collections.Generic;
using System.Text;
using TUAvaliacao.Entities;
using System.Linq;

namespace TUAvaliacao
{
    public class Estudantes
    {
        public List<string> ClassificarEstudantes(List<Estudante> estudantes)
        {
            List<string> nomes = new List<string>();

            if (estudantes == null)
            {
                return new List<string>();
            }
            foreach (var estudante in estudantes)
            {
                if (estudante.Nota < 0 || estudante.Nota > 10)
                {
                    throw new ArgumentException
                              ("Um ou mais estudantes apresentam notas " +
                               "negativas ou acima de 10.");
                }
            }

            for (int i = 1; i <= estudantes.Count; i++)
            {
                if (String.Compare(estudantes[i].Nome, estudantes[i - 1].Nome) == 0)
                {
                    estudantes.Sort((a, b) => b.Nota.CompareTo(a.Nota));
                }
                else
                {
                    estudantes.Sort((a, b) => b.Nome.CompareTo(a.Nome));
                }
            }

            foreach (var estudante in estudantes)
            {
                nomes.Add(estudante.Nome);
            }

            return nomes;
        }
    }
}