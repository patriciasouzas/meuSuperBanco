namespace MeuSuperBanco
{
    class Transacao
    {
        public DateTime Data { get; }
        public string Obs { get; set; }
        public decimal Valor { get; set; }

        public Transacao(decimal valor, DateTime data, string obs)
        {
            this.Valor = valor;
            this.Data = data;
            this.Obs = obs;
        }
    }
}