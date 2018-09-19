using System;
using System.Collections.Generic;
using System.Text;

namespace POSWEB
{
    public class Track
    {
        public string PAN { get; private set; }

        public string NomePortador { get; private set; }

        public string DataValidade { get; private set; }

        public string ServiceCode { get; private set; }

        public string DiscretionaryData { get; private set; }

        public string Bin { get; private set; }

        public Track(Cartao cartao)
        {
            if (!ImportarTack1(cartao.getVar("track1")))
            {
                if (!ImportarTack2(cartao.getVar("track2")))
                {
                    throw new ArgumentException("Cartão inválido.");                    
                }
            }

            if (!ValidarBin(Bin))
            {
                throw new ArgumentException("Bin inválido.");
            }

            if (!ValidarData(DataValidade))
            {
                throw new ArgumentException("Cartão vencido.");
            }

            if (!ValidarServiceCode(ServiceCode))
            {
                throw new ArgumentException("Service code inválido.");
            }
        }

        private bool ImportarTack1(string track)
        {
            Limpar();
            if (track == string.Empty)
            {
                return false;
            }

            var partes = track.Split('^');
            PAN = partes[0];
            NomePortador = partes[1];

            DesmontaCodigos(partes[2]);

            return true;
        }

        private bool ImportarTack2(string track)
        {
            Limpar();
            if (track == string.Empty)
            {
                return false;
            }

            var partes = track.Split('=');
            PAN = partes[0];

            DesmontaCodigos(partes[1]);


            return true;
        }

        private void Limpar()
        {
            PAN = string.Empty;
            NomePortador = string.Empty;
            DataValidade = string.Empty;
            ServiceCode = string.Empty;
            DiscretionaryData = string.Empty;
            Bin = string.Empty;
        }

        private void DesmontaCodigos(string codigos)
        {
            DataValidade = codigos.Substring(0, 4);
            ServiceCode = codigos.Substring(4, 3);
            DiscretionaryData = codigos.Substring(7, 6);
            Bin = PAN.Substring(0, 6);
        }
        
        public bool ValidarBin(string bin)
        {
            return ValidarBin(Convert.ToInt32(bin));
        }

        public bool ValidarBin(int bin)
        {
            if (bin < 400000 || bin > 459999)
            {
                return false;
            }
            return true;
        }

        public bool ValidarServiceCode(string serviceCode)
        {
            if (serviceCode.Length != 3)
            {
                //throw new ArgumentException("Service code com mais de 3 dígitos");
                return false;
            }

            var digito = serviceCode[2];
            if (digito % 2 == 0)
            {
                return false;
            }

            return true;
        }

        public bool ValidarData(string dataValidade)
        {
            var dataAtual = DateTime.Now;
            var anoMesAtual = dataAtual.ToString("yyMM");

            var validade = Convert.ToInt32(dataValidade);
            var atual = Convert.ToInt32(anoMesAtual);
            if (validade < atual)
            {
                return false;
            }
            return true;

            //var primeiroDiaMesAtual = new DateTime(dataAtual.Year, dataAtual.Month, 1);

            //var anoValidade = (DataValidade.Substring(0, 2);
            //var mesValidade = DataValidade.Substring(2, 2);

            //var primeiroDiaMesValidade = new DateTime(dataAtual.Year, dataAtual.Month, 1);
        }
    }

}
