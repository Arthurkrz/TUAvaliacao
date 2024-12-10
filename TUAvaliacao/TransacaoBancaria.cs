using System;
using System.Collections.Generic;
using TUAvaliacao.Contracts;
using TUAvaliacao.Entities;

namespace TUAvaliacao
{
    public class TransacaoBancaria : ITransacao
    {
        public Dictionary<string, decimal> CalcularSaldoPorCliente
                                           (List<Transacao> transacoes)
        {
            if (ListaVazia(transacoes))
            {
                return new Dictionary<string, decimal>();
            }

            var historico = new Dictionary<string, decimal>();

            foreach (var transacao in transacoes)
            {
                if (string.IsNullOrWhiteSpace(transacao.Cliente))
                {
                    throw new ArgumentException
                    ("Uma ou mais transações não apresentam nome do cliente");
                }

                if (!historico.ContainsKey(transacao.Cliente))
                {
                    historico[transacao.Cliente] = 0;
                }

                historico[transacao.Cliente] += transacao.Valor;
            }

            return historico;
        }

        public bool ListaVazia(List<Transacao> transacoes)
        {
            if (transacoes.Count == 0)
            {
                return true;
            }
            else
            {
                foreach (var transacao in transacoes)
                {
                    if (transacao.Valor != 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
