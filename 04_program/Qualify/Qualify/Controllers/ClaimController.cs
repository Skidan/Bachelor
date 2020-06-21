using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.FileProviders.Physical;
using Qualify.Models;
using Qualify.Repository;

namespace Qualify.Controllers
{
    public class ClaimController : Controller
    {
        private readonly ClaimRepository _claimRepository = null;
        private readonly ClientRepository _clientRepository = null;
        private readonly ClaimHistoryRepository _historytRepository = null;
        private readonly EmployeeRepository _employeeRepository = null;

        public ClaimController(ClaimRepository claimRepository, ClientRepository clientRepository, ClaimHistoryRepository claimHistoryRepository, EmployeeRepository employeeRepository)
        {
            _claimRepository = claimRepository;
            _clientRepository = clientRepository;
            _historytRepository = claimHistoryRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<ViewResult> Index()
        {
            ViewBag.ClientsList = await _clientRepository.GetClients();
            var data = await _claimRepository.GetAllClaims();
            return View(data);
        }

        
        public async Task<ViewResult> ViewClaim(int id) 
        {
            var data = await _claimRepository.GetClaimById(id);
            ViewBag.ClaimId = id;
            var currentClient = await _clientRepository.GetClientNameByClaimId(id);
            ViewBag.ClientName = currentClient.Name;
            ViewBag.CurrentHistory = await _historytRepository.GetHistoriesByClaimId(id);
            ViewBag.EmployeeList = await _employeeRepository.GetEmployees();

            return View(data);
        }

        public async Task<ViewResult> AddClaim(bool isSuccess = false, int claimId = 0)
        {
            var model = new Claim() 
            { 

            };

            ViewBag.Clients = new SelectList(await _clientRepository.GetClients(), "ID", "Name");

            ViewBag.Success = isSuccess;
            ViewBag.ClaimId = claimId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClaim(Claim claim)
        {
            int id = await _claimRepository.AddClaim(claim);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddClaim), new {isSuccess = true, claimId = id});
            }

            ViewBag.Clients = new SelectList(await _clientRepository.GetClients(), "ID", "Name");

            return View();
        }
    }
}
