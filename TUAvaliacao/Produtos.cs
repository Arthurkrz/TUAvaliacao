using System;
using System.Collections.Generic;
using TUAvaliacao.Entities;

namespace TUAvaliacao
{
    public class Produtos
    {
        public Dictionary<string, List<Produto>> AgruparPorCategoria
                                                 (List<Produto> produtos)
        {
            if (produtos == null)
            {
                return new Dictionary<string, List<Produto>>();
            }

            var relatorio = new Dictionary<string, List<Produto>>();

            foreach (var produto in produtos)
            {
                if (string.IsNullOrWhiteSpace(produto.Categoria) ||
                    string.IsNullOrWhiteSpace(produto.Nome))
                {
                    throw new ArgumentException
                              ("Um ou mais produtos não apresentam nome ou categoria.");
                }

                if (!relatorio.ContainsKey(produto.Categoria))
                {
                    relatorio[produto.Categoria] = new List<Produto>();
                }

                relatorio[produto.Categoria].Add(produto);
            }

            return relatorio;
        }
    }
}
