using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffAndThings.Data;
using StuffAndThings.Data.Mapper;
using StuffAndThings.Models;

namespace StuffAndThings.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> AddItemToCart(string skuId)
        {
            DBContext _context = new DBContext();

            var buyer = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (buyer != null)
            {
                OrderModel order = OrderMapper.Mapper(_context.Order.Include(x => x.Buyer).Include(x => x.Seller).Where(x => x.BuyerId == Guid.Parse(buyer)).FirstOrDefault());
                OrderItemsModel item = new OrderItemsModel();
                item.Id = Guid.NewGuid();
                item.Seller = order.Seller;
                item.Sku = SkuMapper.Mapper(_context.Skus.Where(x => x.Id == Guid.Parse(skuId)).FirstOrDefault());
                item.Order = order;

                _context.OrderItems.Add(OrderItemsMapper.Mapper(item));
                _context.SaveChanges();
                return "OK";
                //return RedirectToAction("Finalize", "Order");
            }
            else
                return "FAIL";
        }
    }
}
