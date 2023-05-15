using System.Text;

namespace MeuSuperBanco
{
    class ContaBanco
    {
        public string? Numero { get; }
        public string DonoConta { get; set; }
        public decimal Saldo
        {
            get
            {
                decimal saldo = 0;
                foreach (var item in todasTransacoes)
                {
                    saldo += item.Valor;
                }
                return saldo;
            }
        }
        public static int numeroConta = 1234567890;
        private List<Transacao> todasTransacoes = new List<Transacao>();
        public ContaBanco(string nome, decimal valor)
        {
            this.DonoConta = nome;
            numeroConta++;

            this.Numero = numeroConta.ToString();
            Depositar(valor, DateTime.Now, "Saldo Inicial");
        }

        public void Depositar(decimal valor, DateTime data, string obs)
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "Não é possível realizar depósito de valor zero ou negativo.");
            }
            Transacao transacao = new Transacao(valor, data, obs);
            todasTransacoes.Add(transacao);
        }

        public void Sacar(decimal valor, DateTime data, string obs)
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "Não é possível realizar saque de valor zero ou negativo.");
            }
            if (Saldo - valor < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Saldo), "Não é possível realizar esta operação.");
            }
            Transacao transacao = new Transacao(-valor, data, obs);
            todasTransacoes.Add(transacao);
        }

        public string PegarMovimentacao()
        {
            var movimentacoes = new StringBuilder();
            Console.WriteLine();
            movimentacoes.AppendLine("Data\t\tValor\tObservação");

            foreach (var item in todasTransacoes)
            {
                movimentacoes.AppendLine($"{item.Data.ToShortDateString()}\tR${item.Valor}\t{item.Obs}");
            }

            return movimentacoes.ToString();
        }
    }
}