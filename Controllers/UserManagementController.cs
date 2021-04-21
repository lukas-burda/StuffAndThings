using Microsoft.AspNetCore.Mvc;
using StuffAndThings.Data;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Controllers
{
    public class UserManagementController : Controller
    {
        public IActionResult Index()
        {
            DBContext _context = new DBContext();
            List <UserModel> users = _context.Users.ToList();
            return View(users);
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

        public IActionResult Upsert(UserModel user)
        {
            DBContext _context = new DBContext();
            if (user.Id == new Guid())
            {
                user.Id = Guid.NewGuid();
                _context.Users.Add(user);
            }
            else
            {
                _context.Users.Update(user);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid Id)
        {
            DBContext _context = new DBContext();
            UserModel User = _context.Users.Where(x => x.Id == Id).FirstOrDefault();
            _context.Users.Remove(User);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}
