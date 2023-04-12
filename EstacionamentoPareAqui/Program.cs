using EstacionamentoPareAqui;

List<Carro> carros = new List<Carro>();

carros.Add(new Carro("XYZ1111", "Fusca","Azul", "Volkswagem"));
carros.Add(new Carro("XYZ2222", "Kombi", "Branca", "Volkswagem"));
carros.Add(new Carro("XYZ3333", "Passat", "Vermelho", "Volkswagem"));
carros.Add(new Carro("XYZ4444", "Gol", "Verde", "Volkswagem"));

string opcao;
string novaPlaca;
            
do
{
    Console.WriteLine("Bem Vindo ao Estacionamento Pare jÁ!");
    Console.WriteLine("**************************************");
    Console.WriteLine("Escolha uma opção");
    Console.WriteLine("-----------------");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Entrada do veículo");                
    Console.WriteLine("3 - Saída do veículo");
    Console.WriteLine("4 - Consultar histórico");
    Console.WriteLine("5 - Exibir carros");
    Console.WriteLine("6 - Sair"); 

              
    opcao = Console.ReadLine();

    if (opcao == "1"){
        Console.WriteLine("Cadastrar veículo");
        CadastrarVeiculo();


    }else if (opcao == "2"){
        Console.WriteLine("Entrada  do veículo");
        GerarTicket();

      
    }else if (opcao == "3"){
        Console.WriteLine("Saída do veículo");
        EncerrarTicket();
       
    }else if (opcao == "4"){
        Console.WriteLine("Historico");
        Historico();
    }else if (opcao == "5"){
        Console.WriteLine("Exibir carros");
        for (int i = 0; i < carros.Count; i++ ){
            Console.WriteLine($"{carros[i].Placa}, {carros[i].Modelo}, {carros[i].Marca}, {carros[i].Cor}");
        }
    }
}while (opcao != "6");


void CadastrarVeiculo(){
    Carro carro = new Carro();
    Console.WriteLine("Digite a placa: ");
    carro.Placa = Console.ReadLine();
    Console.WriteLine("Digite o modelo: ");
    carro.Modelo = Console.ReadLine();
    Console.WriteLine("Digite a cor: ");
    carro.Cor = Console.ReadLine();
    Console.WriteLine("Digite a Marca: ");
    carro.Marca = Console.ReadLine();
    carros.Add(carro);
}


Carro ObterCarro(string obterPlaca)
{
    foreach(var carro in carros)
    {
        if (obterPlaca == carro.Placa)
        {
            return carro;
        }
    }
    return null;
}

void GerarTicket()
{
    Console.WriteLine("Digite a placa: ");
    novaPlaca = Console.ReadLine(); 
    
    var carro = ObterCarro(novaPlaca);
    
    if(carro == null)
    {
        Console.WriteLine("Carro não cadastrado"); 
        return;
    } 

    foreach(var ticket in carro.Tickets)
    {
        if(ticket.Ativo == true)
        {
            Console.WriteLine("Veiculo já esta no estacionamento"); 
            return; 
        }
    }
    Ticket ticketNovo = new Ticket();
    carro.Tickets.Add(ticketNovo);
    Console.WriteLine("Ticket Gerado!"); 
}

void EncerrarTicket()
{
    Console.WriteLine("Qual a placa do Veículo");
    string placa = Console.ReadLine();

    var carro = ObterCarro(placa);
    if (carro == null)
    {
        Console.WriteLine("Carro não cadastrado");
        return;
    }

    Ticket ticketAberto = null;
    foreach (var ticket in carro.Tickets)
    {
        if (ticket.Ativo == true)
        {
            ticketAberto = ticket;
        }
    }
    if (ticketAberto == null)
    {
        Console.WriteLine("Não há tickets em aberto para este veiculo");
        return;
    }

    ticketAberto.FecharTicket();
    
}

void Historico()
{
    Console.WriteLine("Qual a placa do Veículo");
    string placa = Console.ReadLine();

    var carro = ObterCarro(placa);
    if (carro == null)
    {
        Console.WriteLine("Carro não cadastrado");
        return;
    }

    foreach (var ticket in carro.Tickets)
    {
        if (ticket.Ativo == true)
        {
            Console.WriteLine($"Entrada: {ticket.Entrada} Veículo esta ativo ");
        }
        else
        {
            Console.WriteLine($"Entrada: {ticket.Entrada} Saída: {ticket.Saida}  Valor R${ticket.CalcularValor()}");
        }
    }
}


