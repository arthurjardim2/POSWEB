using System;
using System.Collections.Generic;
using System.Text;

namespace POSWEB
{
    public class Cartao
    {
        private string _track1;

        private string _track2;

        public Cartao(string track1, string track2)
        {
            _track1 = track1;
            _track2 = track2;
        }

        public string getVar(string track)
        {
            if (track == "track1")
            {
                return _track1;
            }
            else if (track == "track2")
            {
                return _track2;
            }
            else
            {
                throw new ArgumentException();
            }
        }

    }
}
