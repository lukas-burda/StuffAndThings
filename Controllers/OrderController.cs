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
            List<OrderEntity> ordersBase = _context.Orders.ToList();
            List<OrderModel> orders = new List<OrderModel>();

            foreach (var order in ordersBase)
            {
                orders.Add(OrderMapper.Mapper(order));
            }

            return View(orders);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        public IActionResult Details(Guid Id)
        {
            DBContext _context = new DBContext();
            OrderEntity orderBase = _context.Orders.SingleOrDefault();
            OrderModel order = OrderMapper.Mapper(orderBase);

            return View(order);
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

                LogController log = new LogController();

                log.MovimentationRegister(orderModel, "Created New", orderModel.Type);
            }
            else
            {
                orderModel.LastUpdate = DateTime.Today;
                _context.Orders.Update(OrderMapper.Mapper(orderModel));

                LogController log = new LogController();
                log.MovimentationRegister(orderModel, "Update Existent", orderModel.Type);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private static Random FriendlyCode = new Random();
        public static string OrderFriendlyCodeGenerator(int lenght)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, lenght).Select(s => s[FriendlyCode.Next(s.Length)]).ToArray());
        }

    }
}
