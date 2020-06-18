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
                Dirpath = claim.ID.ToString()
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

        //public List<Claim> FilterClaim(string title) 
        //{
        //    return DataSource().Where(x => x.Title.Contains(title)).ToList();
        //}

        ////////////////
        //public List<Claim> DataSource()
        //{
        //    return new List<Claim>()
        //    { 
        //        new Claim() {ID = 1, ClientID = 1, Title = "Cylinders of tailgate are leaking", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2019-10-15"), DateEnd = DateTime.Parse("2019-10-24") },
        //        new Claim() {ID = 2, ClientID = 2, Title = "Trailer cover is torn", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2020-5-5") },
        //        new Claim() {ID = 3, ClientID = 1, Title = "Frame get rusted", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2019-01-30") },
        //        new Claim() {ID = 4, ClientID = 4, Title = "We're not getting board extensions", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2020-05-23") },
        //        new Claim() {ID = 5, ClientID = 3, Title = "Brakes not working as expected", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2020-06-06") },
        //        new Claim() {ID = 6, ClientID = 1, Title = "Mudguards not fits 710/50 R26.5\" tires", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2020-3-2") },
        //        new Claim() {ID = 7, ClientID = 6, Title = "Loose paint on trailer", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2020-4-16") }
        //    };
        //}
    }
}
