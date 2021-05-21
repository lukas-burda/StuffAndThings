using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StuffAndThings.Data;
using StuffAndThings.Models;

namespace StuffAndThings.Controllers
{
    public class ShowcaseController : Controller
    {
        
        
        public IActionResult Index()
        {
            DBContext _context = new DBContext();
            //ShowcaseModel sc = _context
            return View();
        }


    }
}
