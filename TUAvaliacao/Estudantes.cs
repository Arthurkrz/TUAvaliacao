using System;
using System.Collections.Generic;
using System.Text;
using TUAvaliacao.Entities;
using System.Linq;
using TUAvaliacao.Contracts;

namespace TUAvaliacao
{
    public class Estudantes : IEstudantes
    {
        public List<string> ClassificarEstudantes(List<Estudante> estudantes)
        {
            List<string> nomes = new List<string>();
            bool equal = false;

            if (ListaVazia(estudantes))
            {
                List<string> listaVazia = new List<string>();
                return listaVazia;
            }

            for (int i = 1; i < estudantes.Count; i++)
            {
                if (estudantes[i].Nota < 0 || estudantes[i].Nota > 10)
                {
                    throw new ArgumentException
                              ("Um ou mais estudantes apresentam notas negativas ou acima de 10.");
                }
                else if (estudantes[i].Nota != estudantes[i - 1].Nota)
                {
                    equal = false;
                }
                else
                {
                    equal = true;
                }
            }

            if (equal == true)
            {
                estudantes.Sort((a, b) => b.Nome.CompareTo(a.Nome));
                foreach (var estudante in estudantes)
                {
                    nomes.Add(estudante.Nome);
                }
            }
            else
            {
                estudantes.Sort((a, b) => b.Nota.CompareTo(a.Nota));
                foreach (var estudante in estudantes)
                {
                    nomes.Add(estudante.Nome);
                }
            }

            return nomes;
        }

        public bool ListaVazia(List<Estudante> estudantes)
        {
            for (int i = 0; i < estudantes.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(estudantes[i].Nome))
                {
                    return false;
                }

            }

            return true;
        }
    }
}