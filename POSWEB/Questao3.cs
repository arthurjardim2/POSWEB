using System;
using System.Collections.Generic;
using System.Text;

namespace POSWEB
{
    public class Questao3
    {
        private readonly string _nomeDb = "TEST_DB";
        private readonly string _separador = ";";
        private readonly string _ip = "200.255.243.123";
        private readonly int _porta = 8080;

        private Repositorio _repositorio;
        private readonly ITransact _transact;

        public Questao3(ITransact transact)
        {
            InicializarRepositorio();
            this._transact = transact;
        }

        private void InicializarRepositorio()
        {
            _repositorio = new Repositorio();
            _repositorio.CreateDb(_nomeDb);

            for (int i = 0; i < 25; i++)
            {
                _repositorio.AddRecord(_nomeDb, "REGISTRO PADRAO");
            }                        
        }

        private string GerarPacote(List<string> registros)
        {
            string pacote = string.Empty;
            foreach (var item in registros)
            {
                if (pacote == string.Empty)
                {
                    pacote = item;
                }
                else
                {
                    pacote = pacote + _separador + item;
                }                
            }            

            return pacote;
        }

        private List<string> BuscarRegistros()
        {
            var registros = new List<string>();
            var qtd = _repositorio.CountRecord(_nomeDb);
            if (qtd > 10)
            {
                qtd = 10;
            }
            for (int i = 0; i < qtd; i++)
            {
                registros.Add(_repositorio.GetRecord(_nomeDb, i));
            }
            return registros;
        }

        private void ApagarRegistros(List<string> registros)
        {
            foreach (var item in registros)
            {
                _repositorio.RemoveFirstRecord(_nomeDb);
            }
        }

        public void Fechamento()
        {
            var totalEnviado = 0;
            Console.WriteLine("Iniciando fechamento.");
            Console.WriteLine($"Total de registros: {_repositorio.CountRecord(_nomeDb)}");

            var registros = BuscarRegistros();
            while (registros.Count != 0)
            {                
                var pacote = GerarPacote(registros);

                Console.WriteLine($"Enviando pacote com {registros.Count} registros.");
                var resposta = _transact.Execute(_ip, _porta, pacote);
                if (resposta.Equals("OK"))
                {
                    ApagarRegistros(registros);
                    totalEnviado += registros.Count;
                    registros = BuscarRegistros();
                }
                else
                {
                    Console.WriteLine("Erro ao enviar registros: " + resposta);
                    return;
                }
            }                        
        }        
    }
}
