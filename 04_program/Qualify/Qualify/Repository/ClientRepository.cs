using Microsoft.AspNetCore.Routing;
using Qualify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Repository
{
    public class ClientRepository
    {
        public List<Client> GetClients() 
        {
            return DataSource();
        }
        public Client GetClientById(int id) 
        { 
            return DataSource().Where(x => x.ID == id).FirstOrDefault();
        }
        public List<Client> FilterClients(string country, string name)
        {
            return DataSource().Where(x => x.Country.Contains(country) || x.Name.Contains(name)).ToList();
        }

        ////////////
        private List<Client> DataSource()
        {
            return new List<Client>()
            {
                new Client() {ID = 1, Name = "MiTip", Country = "Denmark", Email = "info@mi.dk"},
                new Client() {ID = 2, Name = "Konekesko", Country = "Lithuania", Email = "info@konekesko.lt"},
                new Client() {ID = 3, Name = "Roltex", Country = "Poland", Email = "wszystko@roltexagro.pl"},
                new Client() {ID = 4, Name = "Agricasa", Country = "Hungary", Email = "info@agricasa.hg"},
                new Client() {ID = 5, Name = "Almex, D.o.o.", Country = "Serbia", Email = "info@almex.rs"},
                new Client() {ID = 6, Name = "Agrimasz", Country = "Poland", Email = "info@agrimasz.pl"},
                new Client() {ID = 7, Name = "OOO Umega", Country = "Russia", Email = "info@umegaagro.ru"}
            };
        }
    }
}
