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
        public int AddClaim(Claim claim)
        {
            return 1;
        }
        public List<Claim> GetAllClaims() 
        {
            return DataSource();
        }
        public Claim GetClaimById(int id) 
        {
            return DataSource().Where(x => x.ID == id).FirstOrDefault();
        }
        public List<Claim> FilterClaim(string client, string title) 
        {
            return DataSource().Where(x => x.Title.Contains(title)).ToList();
        }

        //////////////
        private List<Claim> DataSource()
        {
            return new List<Claim>()
            { 
                new Claim() {ID = 1, ClientID = 1, Title = "Cylinders of tailgate are leaking", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2019-10-15") },
                new Claim() {ID = 2, ClientID = 2, Title = "Trailer cover is torn", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2020-5-5") },
                new Claim() {ID = 3, ClientID = 1, Title = "Frame get rusted", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2019-01-30") },
                new Claim() {ID = 4, ClientID = 4, Title = "We're not getting board extensions", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2020-05-23") },
                new Claim() {ID = 5, ClientID = 3, Title = "Brakes not working as expected", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2020-06-06") },
                new Claim() {ID = 6, ClientID = 1, Title = "Mudguards not fits 710/50 R26.5\" tires", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2020-3-2") },
                new Claim() {ID = 7, ClientID = 6, Title = "Loose paint on trailer", Description = "Place a full description of a particular claim here to show the text within different types of containers", DateStart = DateTime.Parse("2020-4-16") }
            };
        }
    }
}
