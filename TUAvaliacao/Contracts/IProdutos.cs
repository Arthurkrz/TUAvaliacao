using System;
using System.Collections.Generic;
using System.Text;
using TUAvaliacao.Entities;

namespace TUAvaliacao.Contracts
{
    public interface IProdutos
    {
        public Dictionary<string, List<Produto>> AgruparPorCategoria(List<Produto> produtos);
        public bool ListaVazia(List<Produto> produtos);
    }
}
