using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            DBContext _context = new DBContext();
            List<UserEntity> usersBase = _context.Users.ToList();
            List<ProductEntity> productsBase = _context.Products.Include(x => x.Skus).ToList();
            OrderModel order = new OrderModel();
            foreach (var item in usersBase)
            {
                if (item.Discriminator.Equals(Models.Enums.Discriminator.Seller))
                {
                    order.Sellers.Add(UserMapper.Mapper(item));
                }
                else if (item.Discriminator.Equals(Models.Enums.Discriminator.Buyer))
                {
                    order.Buyers.Add(UserMapper.Mapper(item));
                }
            }
            foreach (var prod in productsBase)
            {
                foreach (var s in prod.Skus)
                {
                    s.Name = prod.Name + " " + s.Name;
                    order.Skus.Add(SkuMapper.Mapper(s));
                }
            }

            return View(order);
        }

        public IActionResult Details(Guid Id)
        {
            DBContext _context = new DBContext();
            OrderEntity orderBase = _context.Orders.SingleOrDefault();
            OrderModel order = OrderMapper.Mapper(orderBase);

            return View(order);
        }

        [HttpPost]
        public IActionResult Upsert(OrderModel order)
        {
            DBContext _context = new DBContext();
            if (order.Id == new Guid())
            {
                order.Id = Guid.NewGuid();
                order.FriendlyCode = "S&T-" + OrderFriendlyCodeGenerator(4);
                order.Status = Enums.OrderStatus.Created;
                order.CreateDate = DateTime.UtcNow;
                order.Total = order.SubTotal - order.Discount;

                _context.Orders.Add(OrderMapper.Mapper(order));

                LogController log = new LogController();

                log.MovimentationRegister(order, "Created New", order.Type);
            }
            else
            {
                _context.Orders.Update(OrderMapper.Mapper(order));

                LogController log = new LogController();
                log.MovimentationRegister(order, "Update Existent", order.Type);
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
