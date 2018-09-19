using POSWEB.Builders;
using System;

namespace POSWEB
{
    class Program
    {        
        static void Main(string[] args)
        {
            var cartao = CartaoBuilder.Novo().Build();

            //var cartao = CartaoBuilder.Novo()
            //    .ComTrack1("")
            //    .Build();

            //var cartao = CartaoBuilder.Novo()
            //    .ComTrack1("")
            //    .ComTrack2("450000002323456=20123412456321")
            //    .Build();

            Console.WriteLine("Iniciando questão 1");
            var questao1 = new Questao1();
            questao1.Iniciar(cartao);

            Console.WriteLine("");
            Console.WriteLine("Iniciando questão 3");
            var questao3 = new Questao3(new Transact());
            questao3.Fechamento();
            
            Console.ReadKey();
        }
    }
}
