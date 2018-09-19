using POSWEB;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace POSWEBTest
{
    public class Questao1Test
    {
        private Questao1 _questao1;

        public Questao1Test()
        {
            _questao1 = new Questao1();
        }

        #region PedirPin

        [Fact]
        public void DiscretionaryDeveConter6Digitos()
        {
            var discretionaryDataMaior = "1234567";
            var discretionaryDataMenor = "12345";

            Assert.Throws<ArgumentException>(() => _questao1.DevePedirPin(discretionaryDataMaior));
            Assert.Throws<ArgumentException>(() => _questao1.DevePedirPin(discretionaryDataMenor));            
        }

        [Fact]
        public void DevePedirCodigoPinCasoPrimeiroDigitoDoDiscretionaryDataSeja1()
        {
            var discretionaryIniciandoCom1 = "123456";
            var retorno = _questao1.DevePedirPin(discretionaryIniciandoCom1);
            Assert.True(retorno);
        }

        #endregion

    }
}
