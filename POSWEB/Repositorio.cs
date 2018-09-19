using System;
using System.Collections.Generic;
using System.Text;

namespace POSWEB
{
    public class Repositorio
    {
        private Dictionary<string, List<string>> _database;

        public Repositorio()
        {
            _database = new Dictionary<string, List<string>>();
        }

        private List<string> GetRegistros(string nomeDb)
        {
            return _database.GetValueOrDefault(nomeDb);
        }

        public void CreateDb(string nomeDb)
        {            
            _database.Add(nomeDb, new List<string>());
        }

        public void AddRecord(string nomeDb, string registro)
        {
            var registros = GetRegistros(nomeDb);            
            registros.Add(registro);
        }

        public void RemoveFirstRecord(string nomeDb) 
        {
            var registros = GetRegistros(nomeDb);            
            registros.RemoveAt(0);
        }

        public string GetRecord(string nomeDb, int ind)
        {            
            var registros = GetRegistros(nomeDb);                        
            return registros[ind];
        }        

        public int CountRecord(string nomeDb)
        {
            var registros = GetRegistros(nomeDb);
            return registros.Count;
        }
    }

}
