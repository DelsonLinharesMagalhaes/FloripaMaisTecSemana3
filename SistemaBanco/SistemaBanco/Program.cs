using SistemaBanco;


List<Cliente> clientes = new List<Cliente>();

clientes.Add(new Cliente("Delson", "61613487649", "dl_magalhaes@hotmail.com",
                        "48998042989", "Rua das Gaivotas, 44", new DateTime(1968 - 07 - 02), 1));
clientes.Add(new Cliente("Andrea", "61613487649", "andrea@hotmail.com",
                        "48998042989", "Rua das Gaivotas, 44", new DateTime(2008 - 07 - 02), 2));
clientes.Add(new Cliente("Spark", "61613487649", "spark@hotmail.com",
                        "48998042989", "Rua das Gaivotas, 44", new DateTime(1978 - 07 - 02), 3));
clientes.Add(new Cliente("Jonathan", "61613487649", "Jonathan@hotmail.com",
                        "48998042989", "Rua das Gaivotas, 44", new DateTime(1988 - 07 - 02), 3));

string opcao = "0";

do
{
    Console.WriteLine("Ben vindo ao Banco do Delson");
    Console.WriteLine("1 - Criar Conta");
    Console.WriteLine("2 - Adicionar Transação"); 
    Console.WriteLine("3 - Consultar Extrato");
    Console.WriteLine("4 - Exibir Clientes");
    Console.WriteLine("5 - Sair");
    opcao = Console.ReadLine();

    if (opcao == "1")
    {
        CriarConta();
        
    }
    if (opcao == "2")
    {
        AdicionarTransacao();

    }
    if (opcao == "4")
    {
        ExibirClientes();
    }



} while (opcao != "5");


// ___________________________________________________________________________
void CriarConta()
{
    Cliente cliente = new Cliente();

    Console.WriteLine("Nome do Cliente:");
    cliente.Nome = Console.ReadLine();
    Console.WriteLine("CPF:");
    cliente.CPF = Console.ReadLine();
    Console.WriteLine("E-mail:");
    cliente.Email = Console.ReadLine();
    Console.WriteLine("Telefone:");
    cliente.Telefone = Console.ReadLine();
    Console.WriteLine("Endereco:");
    cliente.Endereco = Console.ReadLine();
    Console.WriteLine("Data de Nascimento:");
    cliente.DataNascimento = DateTime.Parse(Console.ReadLine());

    var idade = (DateTime.Now - cliente.DataNascimento).TotalDays / 365.25;
    if (idade < 18)
    {
        Console.WriteLine("Cliente menor de idade, não é possível abrir a conta!");
        return;
    }

    Console.WriteLine("Numero da Conta:");
    cliente.NumeroConta = int.Parse(Console.ReadLine());
    Console.WriteLine("Saldo:");
    cliente.Saldo = double.Parse(Console.ReadLine());

    clientes.Add(cliente);
}

// ____________________________________________________________________________

void AdicionarTransacao()
{
    Console.WriteLine("Qual o número da conta?");
    int numeroConta = int.Parse(Console.ReadLine());

    Cliente contaCliente = null;
    foreach(var cliente in clientes)
    {
        if(cliente.NumeroConta == numeroConta) 
        {
            contaCliente= cliente;
            break;
        }
    }
    if (contaCliente == null)
    {
        Console.WriteLine("Conta não cadastrada!");
        return;
    }

    Console.WriteLine("Qual é o valor da transsação?");
    double valor = double.Parse(Console.ReadLine());
    Transacao transacao = new Transacao();
    transacao.Data = DateTime.Now;
    transacao.Valor = valor;
    contaCliente.Extrato.Add(transacao);

}

// ____________________________________________________________________________
void ExibirClientes() 
{ 
    for(int i = 0; i < clientes.Count; i++)
    {
        Console.WriteLine($"Nome do cliente: {clientes[i].Nome}");
        Console.WriteLine($"CPF: {clientes[i].CPF}");
        Console.WriteLine($"E-mail: {clientes[i].Email}");
        Console.WriteLine($"Telefone: {clientes[i].Telefone}");
        Console.WriteLine($"Endereço: {clientes[i].Endereco}");
        Console.WriteLine($"Data de Nascimento: {clientes[i].DataNascimento}");
        Console.WriteLine($"Numero da Conta: {clientes[i].NumeroConta}");
        Console.WriteLine($"Saldo: {clientes[i].Saldo}");
        Console.WriteLine();
    }
}
