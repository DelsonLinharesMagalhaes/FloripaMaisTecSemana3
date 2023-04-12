using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoPareAqui
{
    public class Ticket
    {
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public bool Ativo { get; set; }

        public Ticket(){
            Entrada = DateTime.Now;
            Ativo = true;
        }

       public Ticket(DateTime entrada, DateTime saida, bool ativo){
            Entrada = entrada;
            Saida = saida;
            Ativo = ativo;
        }

        private double CalcularTempo(){
            var tempo = Saida - Entrada;
            return tempo.TotalMinutes;
        }

        public double CalcularValor(){
            double valor = CalcularTempo()*0.09;
            return valor;
        }

        public void FecharTicket()
        {
            Saida = DateTime.Now;
            Ativo = false;
            Console.WriteLine($"o veiculo ficou {CalcularTempo()} Minutos e O valor cobrado será de R$ {CalcularValor()}");
        }


    }


}