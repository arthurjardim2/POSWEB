using POSWEB;
using POSWEB.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace POSWEBTest
{
    public class TrackTest
    {        
        private Track _track;
        private Cartao _cartao;
        private Cartao _cartaoSemTrack1;

        public TrackTest()
        {
            _cartao = CartaoBuilder.Novo().Build();
            _cartaoSemTrack1 = CartaoBuilder
                .Novo()
                .ComTrack1("")
                .Build();

            _track = new Track(_cartao);
        }

        #region ValidarBin

        [Theory]
        [InlineData(0)]
        [InlineData(-40000)]
        [InlineData(399999)]
        public void NaoDeveValidarBinAbaixoDe400000(int bin)
        {
            var resultado = _track.ValidarBin(bin);
            Assert.False(resultado);
        }

        [Theory]
        [InlineData(460000)]
        [InlineData(int.MaxValue)]
        public void NaoDeveValidarBinAcimaDe459999(int bin)
        {
            var resultado = _track.ValidarBin(bin);
            Assert.False(resultado);
        }

        [Theory]
        [InlineData(459999)]
        [InlineData(400000)]
        [InlineData(422200)]
        public void DeveValidarBinEntre400000_E_459999(int bin)
        {
            var resultado = _track.ValidarBin(bin);
            Assert.True(resultado);
        }

        #endregion

        #region ValidarServiceCode

        [Fact]
        public void ServiceCodeDeveConter3Digitos()
        {
            var serviceCodeMaior = "3215";
            var serviceCodeMenor = "31";

            var retorno = _track.ValidarServiceCode(serviceCodeMaior);
            Assert.False(retorno);

            retorno = _track.ValidarServiceCode(serviceCodeMenor);
            Assert.False(retorno);

        }

        [Fact]
        public void TerceiroDigitoDoServiceCodeDeveSerImpar()
        {
            var serviceCodeValido = "321";
            var serviceCodeInvalido = "312";

            var retorno = _track.ValidarServiceCode(serviceCodeValido);
            Assert.True(retorno);

            retorno = _track.ValidarServiceCode(serviceCodeInvalido);
            Assert.False(retorno);
        }

        #endregion

        #region ValidarData

        [Fact]
        public void ValidarData()
        {
            var dataVencida = "1505";
            var dataValida = "2205";

            var retorno = _track.ValidarData(dataVencida);
            Assert.False(retorno);

            retorno = _track.ValidarData(dataValida);
            Assert.True(retorno);
        }

        #endregion

        #region LeituraDoCartao

        [Fact]
        public void DeveLerCartaoSemTrack1()
        {
            var track = new Track(_cartaoSemTrack1);
            var track2Lida = track.PAN + "=" + track.DataValidade + track.ServiceCode + track.DiscretionaryData;
            Assert.Equal(_cartaoSemTrack1.getVar("track2"), track2Lida);
        }

        #endregion

    }
}
