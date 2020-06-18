using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Qualify.Models;
using Qualify.Service;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualify.Repository
{
    public class ClientRepository
    {
        private readonly QualifyContext _context = null;
        public ClientRepository(QualifyContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetClients() 
        {
            var clients = new List<Client>();
            var allClients = await _context.Clients.ToListAsync();
            if (allClients?.Any() == true)
            {
                foreach (var client in allClients)
                {
                    clients.Add(new Client()
                    {
                        ID = client.ID,
                        Name = client.Name,
                        Country = client.Country,
                        Address = client.Address,
                        Email = client.Email,
                        Phone = client.Phone
                    });
                }
                
            }
            return clients;
        }

        public async Task<Client> GetClientNameByClaimId(int id) 
        { 
            var claim = await _context.Claims.Where(x => x.ID == id).FirstOrDefaultAsync();
            int currentClientId = claim.ClientID;
            return await _context.Clients.Where(x => x.ID == currentClientId).FirstOrDefaultAsync();
        }

        //public List<Client> FilterClients(string country, string name)
        //{
        //    return DataSource().Where(x => x.Country.Contains(country) || x.Name.Contains(name)).ToList();
        //}

        //////////////
        //private List<Client> DataSource()
        //{
        //    return new List<Client>()
        //    {
        //        new Client() {ID = 1, Name = "MiTip", Country = "Denmark", Email = "info@mi.dk"},
        //        new Client() {ID = 2, Name = "Konekesko", Country = "Lithuania", Email = "info@konekesko.lt"},
        //        new Client() {ID = 3, Name = "Roltex", Country = "Poland", Email = "wszystko@roltexagro.pl"},
        //        new Client() {ID = 4, Name = "Agricasa", Country = "Hungary", Email = "info@agricasa.hg"},
        //        new Client() {ID = 5, Name = "Almex, D.o.o.", Country = "Serbia", Email = "info@almex.rs"},
        //        new Client() {ID = 6, Name = "Agrimasz", Country = "Poland", Email = "info@agrimasz.pl"},
        //        new Client() {ID = 7, Name = "OOO Umega", Country = "Russia", Email = "info@umegaagro.ru"}
        //    };
        //}
    }
}
