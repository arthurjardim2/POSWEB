using System;
using System.Collections.Generic;
using System.Text;

namespace POSWEB.Builders
{
    public class CartaoBuilder
    {
        private string _track1 = "4523490000002634^JOSE C RIBEIRO^2012357164245";
        private string _track2 = "4123490000002634=2012357164245";

        public static CartaoBuilder Novo()
        {
            return new CartaoBuilder();
        }

        public Cartao Build()
        {
            return new Cartao(_track1, _track2);
        }

        public CartaoBuilder ComTrack1(string track1)
        {
            _track1 = track1;
            return this;
        }

        public CartaoBuilder ComTrack2(string track2)
        {
            _track2 = track2;
            return this;
        }
    }
}
