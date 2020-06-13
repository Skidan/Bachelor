using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.FileProviders.Physical;
using Qualify.Repository;

namespace Qualify.Controllers
{
    public class ClaimController : Controller
    {
        private readonly ClaimRepository _claimRepository = null;
        public ClaimController()
        {
            _claimRepository = new ClaimRepository();
        }
        public IActionResult Index()
        {
            var data = _claimRepository.GetAllClaims();

            return View(data);
        }
        public IActionResult ViewClaim(int id) 
        {
            return View();
        }
        public IActionResult AddClaim()
        {
            return View();
        }
    }
}
