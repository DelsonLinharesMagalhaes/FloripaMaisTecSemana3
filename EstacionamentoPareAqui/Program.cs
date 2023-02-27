using EstacionamentoPareAqui;

List<Carro> carros = new List<Carro>(); 
string opcao;
            
do
{
    Console.WriteLine("Bem Vindo ao Estacionamento Pare Aqui!");
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
        Carro novoCarro = CadastrarVeiculo();
        carros.Add(novoCarro);

    }else if (opcao == "2"){
        Console.WriteLine("Entrada  do veículo");
        Console.Read();
        break;
        // EntradaDoVeiculo();
    }else if (opcao == "3"){
        Console.WriteLine("Saída do veículo");
        Console.Read();
        break;
        // SaidaDoVeiculo();
    }else if (opcao == "4"){
        Console.WriteLine("Historico");
        Console.Read();
        break;
        //  Historico();
    }else if (opcao == "5"){
        Console.WriteLine("Exibir carros");
        for (int i = 0; i < carros.Count; i++ ){
            Console.WriteLine($"{carros[i].Placa}, {carros[i].Modelo}, {carros[i].Marca}, {carros[i].Cor}");
        }
             Console.Read();
    }else if (opcao == "6"){ break; 
    }else {Console.WriteLine("Opção Invalida!");
            Console.Read();
            break;}

}while (opcao != "6");


Carro CadastrarVeiculo(){
    Carro carro = new Carro();
    Console.WriteLine("Digite a placa: ");
    carro.Placa = Console.ReadLine();
    Console.WriteLine("Digite o modelo: ");
    carro.Modelo = Console.ReadLine();
    Console.WriteLine("Digite a cor: ");
    carro.Cor = Console.ReadLine();
    Console.WriteLine("Digite a Marca: ");
    carro.Marca = Console.ReadLine();
    return carro;
}