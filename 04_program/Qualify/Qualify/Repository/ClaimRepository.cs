using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Qualify.Models;
using Qualify.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Qualify.Repository
{
    public class ClaimRepository
    {
        private readonly QualifyContext _context = null;
        public ClaimRepository(QualifyContext context)
        {
            _context = context;
        }

        public async Task<int> AddClaim(Claim claim)
        {
            var newClaim = new Claim()
            {
                ClientID = claim.ClientID,
                Title = claim.Title,
                Description = claim.Description,
                DateStart = claim.DateStart,
                Dirpath = "/claims/" + claim.ID.ToString()
            };
            await _context.Claims.AddAsync(newClaim);
            await _context.SaveChangesAsync();
            return newClaim.ID;
        }

        public async Task<List<Claim>> GetAllClaims() 
        {
            var claims = new List<Claim>();
            var allClaims = await _context.Claims.ToListAsync();
            if (allClaims?.Any() == true)
            {
                foreach (var claim in allClaims) 
                {
                    claims.Add(new Claim()
                    {
                        ID = claim.ID,
                        ClientID = claim.ClientID,
                        Title = claim.Title,
                        Description = claim.Description,
                        Dirpath = claim.Dirpath,
                        DateStart = claim.DateStart,
                        DateEnd = claim.DateEnd
                    });
                }
            }
            return claims;
        }

        public async Task<Claim> GetClaimById(int id) 
        {
            var currentClaim = await _context.Claims.FindAsync(id);
            if (currentClaim != null)
            {
                var claimDetails = new Claim()
                {
                    ID = currentClaim.ID,
                    ClientID = currentClaim.ClientID,
                    Title = currentClaim.Title,
                    Description = currentClaim.Description,
                    Dirpath = currentClaim.Dirpath,
                    DateStart = currentClaim.DateStart,
                    DateEnd = currentClaim.DateEnd
                };
                return claimDetails;
            }
            return null;
            //_context.Claims.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

    }
}
