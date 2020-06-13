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
        public List<ClientModel> GetClients() 
        {
            return DataSource();
        }
        public ClientModel GetClientById(int id) 
        { 
            return DataSource().Where(x => x.ID == id).FirstOrDefault();
        }
        public List<ClientModel> FilterClients(string country, string name)
        {
            return DataSource().Where(x => x.Country.Contains(country) || x.Name.Contains(name)).ToList();
        }

        ////////////
        private List<ClientModel> DataSource()
        {
            return new List<ClientModel>()
            {
                new ClientModel() {ID = 1, Name = "MiTip", Country = "Denmark", Email = "info@mi.dk"},
                new ClientModel() {ID = 2, Name = "Konekesko", Country = "Lithuania", Email = "info@konekesko.lt"},
                new ClientModel() {ID = 3, Name = "Roltex", Country = "Poland", Email = "wszystko@roltexagro.pl"},
                new ClientModel() {ID = 4, Name = "Agricasa", Country = "Hungary", Email = "info@agricasa.hg"},
                new ClientModel() {ID = 5, Name = "Almex, D.o.o.", Country = "Serbia", Email = "info@almex.rs"},
                new ClientModel() {ID = 6, Name = "Agrimasz", Country = "Poland", Email = "info@agrimasz.pl"},
                new ClientModel() {ID = 7, Name = "OOO Umega", Country = "Russia", Email = "info@umegaagro.ru"}
            };
        }
    }
}
