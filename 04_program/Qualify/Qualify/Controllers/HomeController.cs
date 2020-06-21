using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qualify.Models;
using Qualify.Repository;

namespace Qualify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClaimRepository _claimRepository = null;
        private readonly ClientRepository _clientRepository = null;
        private readonly ClaimHistoryRepository _historytRepository = null;
        private readonly EmployeeRepository _employeeRepository = null;

        public HomeController(ClaimRepository claimRepository, ClientRepository clientRepository, ClaimHistoryRepository claimHistoryRepository, EmployeeRepository employeeRepository)
        {
            _claimRepository = claimRepository;
            _clientRepository = clientRepository;
            _historytRepository = claimHistoryRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.ClientsList = await _clientRepository.GetClients();
            var data = await _claimRepository.GetAllClaims();
            var openClaims = new List<Claim>();
            foreach(var claim in data)
            {
                if (claim.DateEnd == null)
                {
                    openClaims.Add(new Claim() 
                    { 
                        ID = claim.ID,
                        ClientID = claim.ClientID,
                        Title = claim.Title,
                        Description = claim.Description,
                        Dirpath = claim.Dirpath,
                        DateStart = claim.DateStart
                    });
                }
            }
            return View(openClaims); 
        }
    }
}
