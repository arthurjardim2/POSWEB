using System;
using System.Collections.Generic;
using System.Text;

namespace POSWEB
{
    public class Transact : ITransact
    {
        public string Execute(string psIp, int psPort, string psMessage)
        {
            return "OK";
        }
    }
}
