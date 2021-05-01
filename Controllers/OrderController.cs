using Microsoft.AspNetCore.Mvc;
using StuffAndThings.Data;
using StuffAndThings.Data.Entities;
using StuffAndThings.Data.Mapper;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StuffAndThings.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            DBContext _context = new DBContext();
            List<OrderEntity> orderBase = _context.Orders.ToList();
            List<OrderModel> order = new List<OrderModel>();
            foreach (var item in orderBase) order.Add(OrderMapper.Mapper(item));
            return View(order);
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
        public IActionResult Upsert(OrderModel orderModel)
        {
            DBContext _context = new DBContext();
            if (orderModel.Id == new Guid())
            {
                orderModel.Id = Guid.NewGuid();
                orderModel.FriendlyCode = "S&T-" + OrderFriendlyCodeGenerator(4);
                orderModel.Status = Enums.OrderStatus.Created;
                orderModel.CreateDate = DateTime.UtcNow;
                orderModel.LastUpdate = DateTime.UtcNow;
                orderModel.SubTotal = orderModel.Total - orderModel.Discount;
                _context.Orders.Add(OrderMapper.Mapper(orderModel));
            }
            else
            {
                orderModel.LastUpdate = DateTime.Today;
                _context.Orders.Update(OrderMapper.Mapper(orderModel));
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
