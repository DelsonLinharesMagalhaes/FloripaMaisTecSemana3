

namespace SistemaBanco
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public int NumeroConta { get; set;}
        public double Saldo { get { return GetSaldo(); } private set { } }

        public List<Transacao> Extrato { get; set; }

        public Cliente()
        {
            Extrato = new List<Transacao>();
        }

        public Cliente(string nome, string cPF, string email, string telefone, string endereco, DateTime dataNascimento, int numeroConta) :this()
        {
            Nome = nome;
            CPF = cPF;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            NumeroConta = numeroConta;
        }

        private double GetSaldo() 
        {
            double saldo = 0;
            foreach (Transacao transacao in Extrato)
            {
                saldo += transacao.Valor;
            }
            return saldo;
        }

    }
}
