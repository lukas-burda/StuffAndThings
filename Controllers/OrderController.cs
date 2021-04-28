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
            List <OrderModel> users = _context.Orders.ToList();
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

        public IActionResult Upsert(OrderModel order)
        {
            DBContext _context = new DBContext();
            if (order.Id == new Guid())
            {
                order.Id = Guid.NewGuid();
                order.FriendlyCode = "S&T-" + OrderFriendlyCodeGenerator(4);
                order.Status = Enums.OrderStatus.Created;
                order.CreateDate = DateTime.UtcNow;
                order.LastUpdate = DateTime.UtcNow;
                order.SubTotal = order.Total - order.Discount;
                _context.Orders.Add(order);
            }
            else
            {
                order.LastUpdate = DateTime.Today;
                _context.Orders.Update(order);
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
            return View();
        }

        private static Random FriendlyCode = new Random();
        public static string OrderFriendlyCodeGenerator(int lenght)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, lenght).Select(s => s[FriendlyCode.Next(s.Length)]).ToArray());
        }

    }
}
