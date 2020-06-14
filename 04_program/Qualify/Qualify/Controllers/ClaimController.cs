using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.FileProviders.Physical;
using Qualify.Models;
using Qualify.Repository;

namespace Qualify.Controllers
{
    public class ClaimController : Controller
    {
        private readonly ClaimRepository _claimRepository = null;
        public ClaimController(ClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }
        public async Task<ViewResult> Index()
        {
            var data = await _claimRepository.GetAllClaims();
            return View(data);
        }

        
        public async Task<ViewResult> ViewClaim(int id) 
        {
            var data = await _claimRepository.GetClaimById(id);
            ViewBag.ClaimId = id;
            return View(data);
        }

        public ViewResult AddClaim(bool isSuccess = false, int claimId = 0)
        {
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
                return RedirectToAction(nameof(AddClaim), new {isSuccess = true, bookId = id});
            }
            return View();
        }
    }
}
