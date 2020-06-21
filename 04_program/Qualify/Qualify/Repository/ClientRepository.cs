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

    }
}
