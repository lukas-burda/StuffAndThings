using Microsoft.AspNetCore.Mvc;
using StuffAndThings.Data;
using StuffAndThings.Data.Entities;
using StuffAndThings.Data.Mapper;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Controllers
{
    public class UserManagementController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            DBContext _context = new DBContext();
            List<UserEntity> usersBase = _context.Users.ToList();
            List<UserModel> users = new List<UserModel>();
            foreach (var item in usersBase) users.Add(UserMapper.Mapper(item));
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {

            DBContext _context = new DBContext();
            UserEntity userBase = _context.Users.Where(x => x.Id == Id).FirstOrDefault();
            UserModel user = UserMapper.Mapper(userBase);
            return View(user);
        }

        [HttpPost]
        public IActionResult Upsert(UserModel user)
        {
            DBContext _context = new DBContext();
            if (user.Id == new Guid())
            {
                user.Id = Guid.NewGuid();
                _context.Users.Add(UserMapper.Mapper(user));
            }
            else
            {
                _context.Users.Update(UserMapper.Mapper(user));
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            DBContext _context = new DBContext();
            UserEntity User = _context.Users.Where(x => x.Id == Id).FirstOrDefault();
            _context.Users.Remove(User);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}
