using Microsoft.AspNetCore.Mvc;
using StuffAndThings.Data;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StuffAndThings.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            DBContext _context = new DBContext();
            List <UserModel> users = _context.Users.ToList();
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }

        public IActionResult Edit(Guid Id)
        {
            DBContext _context = new DBContext();
            UserModel User = _context.Users.Where(x => x.Id == Id).FirstOrDefault();
            return View(User);
        }

        public IActionResult Upsert()
        {
            
            return View();
        }

        public IActionResult Delete(Guid Id)
        {
            DBContext _context = new DBContext();
            UserModel User = _context.Users.Where(x => x.Id == Id).FirstOrDefault();
            _context.Users.Remove(User);
            _context.SaveChanges();
            return View();
        }

    }
}
