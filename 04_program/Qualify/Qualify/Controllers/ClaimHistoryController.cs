using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Qualify.Models;
using Qualify.Repository;

namespace Qualify.Controllers
{
    public class ClaimHistoryController : Controller
    {
        
        private readonly EmployeeRepository _employeeRepository = null;
        private readonly ClaimHistoryRepository _historyRepository = null;
        public ClaimHistoryController(ClaimHistoryRepository claimHistoryRepository, EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _historyRepository = claimHistoryRepository;
        }

        public async Task<ViewResult> AddHistory(bool isSuccess = false, int claimId = 0)
        {
            var model = new ClaimHistory()
            {

            };
            ViewBag.Employees = new SelectList(await _employeeRepository.GetEmployees(), "ID", "Name");
            ViewBag.Success = isSuccess;
            ViewBag.ClaimId = claimId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHistory(ClaimHistory claimHistory, int claimId)
        {
            
            int id = await _historyRepository.AddHistory(claimHistory, claimId);
            if (id > 0)
            {
                return RedirectToAction("ViewClaim", "Claim", new { id = claimId});
            }

            ViewBag.Employees = new SelectList(await _employeeRepository.GetEmployees(), "ID", "Name");

            return View();
        }
    }
}
