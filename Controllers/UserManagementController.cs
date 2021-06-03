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
        #region GET
        [HttpGet]
        public IActionResult SellerIndex()
        {
            List<UserModel> users = GetAllSellers();
            return View("SellerIndex", users);
        }

        [HttpGet]
        public IActionResult BuyerIndex()
        {
            List<UserModel> users = GetAllBuyers();
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
            UserModel user = GetSellerById(Id);
            return View(user);
        }

        public static List<UserModel> GetAllSellers()
        {
            DBContext _context = new DBContext();
            List<UserModel> users = UserMapper.Mapper(_context.Users.Where(x => x.Discriminator == Models.Enums.Discriminator.Seller).ToList());
            return users;
        }

        public static UserModel GetSellerById(Guid Id)
        {
            DBContext _context = new DBContext();
            UserModel user = UserMapper.Mapper(_context.Users.Where(x => x.Id == Id).FirstOrDefault());
            return user;
        }

        public static List<UserModel> GetAllBuyers()
        {
            DBContext _context = new DBContext();
            List<UserModel> users = UserMapper.Mapper(_context.Users.Where(x => x.Discriminator == Models.Enums.Discriminator.Buyer).ToList());
            return users;
        }
        #endregion

        #region POST
        [HttpPost]
        public IActionResult Upsert(UserModel user)
        {
            DBContext _context = new DBContext();
            if (user.Id == new Guid())
            {
                user.Id = Guid.NewGuid();
                _context.Users.Add(UserMapper.Mapper(user));

                LogController logger = new LogController();
                logger.LogRegister(user, "Created", Models.Enums.LogType.Users);
            }
            else
            {
                _context.Users.Update(UserMapper.Mapper(user));

                LogController logger = new LogController();
                logger.LogRegister(user, "Updated", Models.Enums.LogType.Users);

            }
            _context.SaveChanges();

            string returnselector = "";

            if (user.Discriminator.Equals(Models.Enums.Discriminator.Buyer))
            {
                returnselector = "BuyerIndex";
            }
            else if (user.Discriminator.Equals(Models.Enums.Discriminator.Seller))
            {
                returnselector = "SellerIndex";
            };

            return RedirectToAction(returnselector);
        }
        public IActionResult Delete(Guid Id)
        {
            DBContext _context = new DBContext();
            LogController logger = new LogController();
            UserEntity user = _context.Users.Where(x => x.Id == Id).FirstOrDefault();

            _context.Users.Remove(user);

            logger.LogRegister(user, "Deleted", Models.Enums.LogType.Users);

            _context.SaveChanges();

            string returnselector = "";

            if (user.Discriminator.Equals(Models.Enums.Discriminator.Buyer))
            {
                returnselector = "BuyerIndex";
            }
            else if (user.Discriminator.Equals(Models.Enums.Discriminator.Seller))
            {
                returnselector = "SellerIndex";
            };

            return RedirectToAction(returnselector);
        }
        #endregion
    }
}
