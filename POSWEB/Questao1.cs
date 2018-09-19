using System;
using System.Collections.Generic;
using System.Text;

namespace POSWEB
{    
    public class Questao1
    {
        private bool _pinCapturado = false;

        public bool DevePedirPin(string discretionaryData)
        {
            if (discretionaryData.Length != 6)
            {
                throw new ArgumentException("Discretionary data deve conter 6 digitos.");
            }

            var digito = discretionaryData[0];
            if (digito == '1')
            {
                return true;
            }
            return false;
        }

        public string CapturarPin()
        {
            var pin = string.Empty;
            while (pin == string.Empty)
            {
                Console.Write("Informe o PIN: ");
                pin = Console.ReadLine();
                if (pin.Length != 4)
                {
                    pin = string.Empty;
                    Console.WriteLine("PIN inválido.");
                }
            }

            _pinCapturado = true;
            return pin;
            
        }        

        public void ExibirTrack(Track track)
        {
            Console.Write("PAN: ");
            Console.WriteLine(track.PAN);

            Console.Write("Nome do portador: ");
            Console.WriteLine(track.NomePortador);

            Console.Write("Data de validade: ");
            Console.WriteLine(track.DataValidade);

            Console.Write("Service code: ");
            Console.WriteLine(track.ServiceCode);

            Console.Write("Discretionary data: ");
            Console.WriteLine(track.DiscretionaryData);
        }

        public void Iniciar(Cartao cartao)
        {
            _pinCapturado = false;
            Track track;

            try
            {
                track = new Track(cartao);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }            
            
            if (DevePedirPin(track.DiscretionaryData))
            {
                CapturarPin();
            }
            
            if (track.NomePortador != string.Empty)
            {
                Console.WriteLine(track.NomePortador);
            }

            if (_pinCapturado)
            {
                Console.WriteLine("Pin foi capturado.");
            }

            Console.WriteLine();
            Console.WriteLine("Track lida: ");
            ExibirTrack(track);
        }
        
    }
}
