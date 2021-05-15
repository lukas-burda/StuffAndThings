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
        public IActionResult SellerIndex()
        {
            DBContext _context = new DBContext();
            List<UserEntity> usersBase = _context.Users.ToList();
            List<UserModel> users = new List<UserModel>();
            foreach (var user in usersBase)
            {
                if (user.Discriminator.Equals(Models.Enums.Discriminator.Seller))
                {
                    users.Add(UserMapper.Mapper(user));
                }

            }
            return View("SellerIndex", users);
        }

        [HttpGet]
        public IActionResult BuyerIndex()
        {
            DBContext _context = new DBContext();
            List<UserEntity> usersBase = _context.Users.ToList();
            List<UserModel> users = new List<UserModel>();
            foreach (var user in usersBase)
            {
                if (user.Discriminator.Equals(Models.Enums.Discriminator.Buyer))
                {
                    users.Add(UserMapper.Mapper(user));
                }

            }
            return View("BuyerIndex", users);
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

                LogController log = new LogController();
                log.MovimentationRegister(user, "Created New", Models.Enums.LogType.Users);
            }
            else
            {
                _context.Users.Update(UserMapper.Mapper(user));

                LogController log = new LogController();
                log.MovimentationRegister(user, "Update Existent", Models.Enums.LogType.Users);

            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid Id)
        {
            DBContext _context = new DBContext();
            LogController log = new LogController();
            UserEntity User = _context.Users.Where(x => x.Id == Id).FirstOrDefault();

            _context.Users.Remove(User);

            log.MovimentationRegister(User, "Deleted", Models.Enums.LogType.Users);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
