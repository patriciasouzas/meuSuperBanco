namespace MeuSuperBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            MeuSuperBanco.ContaBanco contaB = new ContaBanco("Sérgio", 1200);
            Console.WriteLine($"A conta {contaB.Numero} de {contaB.DonoConta} foi criada com o saldo de R${contaB.Saldo}.");

            contaB.Depositar(300, DateTime.Now, "Comissão Recebida");
            Console.WriteLine($"A conta {contaB.Numero} de {contaB.DonoConta} está com o saldo de R${contaB.Saldo}.");

            try
            {
                contaB.Sacar(100, DateTime.Now, "Saque Realizado");
                Console.WriteLine($"A conta {contaB.Numero} de {contaB.DonoConta} está com o saldo de R${contaB.Saldo}.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(contaB.PegarMovimentacao());
        }
    }
}