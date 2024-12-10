using System;
using System.Collections.Generic;
using System.Text;
using TUAvaliacao.Entities;

namespace TUAvaliacao.Contracts
{
    public interface ITransacao
    {
        public Dictionary<string, decimal> CalcularSaldoPorCliente
                                           (List<Transacao> transacoes);
        public bool ListaVazia(List<Transacao> transacoes);
    }
}
