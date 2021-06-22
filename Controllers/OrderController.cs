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
            var buyer = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (buyer != null)
            {
                DBContext _context = new DBContext();

                OrderModel order = OrderMapper.Mapper(_context.Order.Include(x => x.Buyer).Include(x => x.Seller).Where(x => x.BuyerId == Guid.Parse(buyer)).FirstOrDefault());

                SkuStocksModel stock = StockMapper.Mapper(_context.Stocks.Where(x => x.SellerId == order.Seller.Id && x.Sku.Id == Guid.Parse(skuId)).FirstOrDefault());

                if (stock != null)
                {
                    OrderItemsModel item = new OrderItemsModel();
                    item.Id = Guid.NewGuid();
                    item.Seller = order.Seller;
                    item.Sku = SkuMapper.Mapper(_context.Skus.Where(x => x.Id == Guid.Parse(skuId)).FirstOrDefault());
                    item.Order = order;

                    stock.AvailableQuantity -= 1;

                    _context.OrderItems.Add(OrderItemsMapper.Mapper(item));
                    _context.Stocks.Update(StockMapper.Mapper(stock));
                    _context.SaveChanges();
                    return "OK";
                }
                return "ESSE PRODUTO NÃO TEM ESTOQUE PARA O LOJISTA SELECIONADO";
            }
            else
                return "FAIL";
        }

        public async Task<string> RemoveItemToCart(string skuId)
        {
            var buyer = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (buyer != null)
            {
                DBContext _context = new DBContext();

                OrderModel order = OrderMapper.Mapper(_context.Order.Include(x => x.Buyer).Include(x => x.Seller).Where(x => x.BuyerId == Guid.Parse(buyer)).FirstOrDefault());

                OrderItemsModel orderItems = OrderItemsMapper.Mapper(_context.OrderItems.Where(x => x.OrderId == order.Id && x.SkuId == Guid.Parse(skuId)).FirstOrDefault());

                _context.OrderItems.Remove(OrderItemsMapper.Mapper(orderItems));
                _context.SaveChanges();
                return "OK";
            }
            return "FAIL";
        }
    }
}
