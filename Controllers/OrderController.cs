using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffAndThings.Data;
using StuffAndThings.Data.Entities;
using StuffAndThings.Data.Mapper;
using StuffAndThings.Models;

namespace StuffAndThings.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            OrderModel order = new OrderModel();
            return View("Finalize2", order);
        }

        public IActionResult Finalize()
        {
            var buyer = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (buyer != null)
            {
                DBContext _context = new DBContext();
                OrderModel order = OrderMapper.Mapper(_context.Order.Include(x => x.Buyer).Include(x => x.Seller).Include(x => x.Address).Where(x => x.BuyerId == Guid.Parse(buyer)).FirstOrDefault());

                if (order != null)
                {
                    order.OrderItems = OrderItemsMapper.Mapper(_context.OrderItems.Include(x => x.Seller).Include(x => x.Sku).Include(x => x.Order).Where(x => x.OrderId == order.Id).ToList());
                    foreach (var item in order.OrderItems)
                    {
                        item.Sku.Product = ProductController.GetProductById(item.Sku.ProductId);
                    }
                    return View(order);
                }
            }
            return View();
        }

        public async Task<int> CountItems()
        {
            var buyer = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (buyer != null)
            {
                DBContext _context = new DBContext();

                Guid orderId = _context.Order.Include(x => x.Buyer).Include(x => x.Seller).Include(x => x.Address).Where(x => x.BuyerId == Guid.Parse(buyer)).Select(x => x.Id).FirstOrDefault();

                List<int> orderItemsCount = _context.OrderItems.Where(x => x.OrderId == orderId).Select(x => x.Quantity).ToList();

                int count = 0;

                foreach (var item in orderItemsCount)
                {
                    count += item;
                }

                return count;
            }
            return 0;
        }

        public async Task<string> AddItemToCart(string skuId)
        {
            var buyer = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (buyer != null)
            {
                DBContext _context = new DBContext();

                OrderModel order = OrderMapper.Mapper(_context.Order.Include(x => x.Buyer).Include(x => x.Seller).Include(x => x.Address).Where(x => x.BuyerId == Guid.Parse(buyer)).FirstOrDefault());

                SkuStocksModel stock = StockMapper.Mapper(_context.Stocks.Include(x => x.Seller).Include(x => x.Sku).Where(x => x.SellerId == order.Seller.Id && x.Sku.Id == Guid.Parse(skuId)).FirstOrDefault());

                if (stock != null)
                {
                    OrderItemsModel item = OrderItemsMapper.Mapper(_context.OrderItems.Include(x => x.Sku).Include(x => x.Seller).Include(x => x.Order).Where(x => x.SkuId == Guid.Parse(skuId) && x.OrderId == order.Id).FirstOrDefault());

                    if (item == null)
                    {
                        item = new OrderItemsModel();
                        item.Id = Guid.NewGuid();
                        item.Seller = order.Seller;
                        item.Sku = stock.Sku;
                        item.Order = order;
                        item.Quantity = 1;
                        _context.Add(OrderItemsMapper.Mapper(item));

                        var currentOrder = _context.Order.Find(order.Id);
                        currentOrder.SubTotal += item.Sku.Price;
                        currentOrder.Total += item.Sku.Price;

                        _context.Update(currentOrder);
                    }
                    else
                    {
                        var currentItem = _context.OrderItems.Find(item.Id);
                        currentItem.Id = item.Id;
                        currentItem.OrderId = order.Id;
                        currentItem.Quantity += 1;
                        currentItem.SellerId = order.Seller.Id;
                        currentItem.SkuId = stock.Sku.Id;

                        _context.Update(currentItem);

                        var currentOrder = _context.Order.Find(order.Id);
                        currentOrder.SubTotal += item.Sku.Price;
                        currentOrder.Total += item.Sku.Price;

                        _context.Update(currentOrder);
                    }

                    var newstock = _context.Stocks.Find(stock.Id);
                    newstock.Id = stock.Id;
                    newstock.SellerId = order.Seller.Id;
                    newstock.SkuId = stock.Sku.Id;
                    newstock.AvailableQuantity -= 1;
                    newstock.LastUpdate = DateTime.Now;

                    _context.Update(newstock);
                    _context.SaveChanges();
                    return "OK";
                }
                return "ESSE PRODUTO NÃO TEM ESTOQUE PARA O LOJISTA SELECIONADO";
            }
            else
                return "FAIL";
        }

        public async Task<string> RemoveItemFromCart(string skuId)
        {
            var buyer = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (buyer != null)
            {
                DBContext _context = new DBContext();

                OrderModel order = OrderMapper.Mapper(_context.Order.Include(x => x.Buyer).Include(x => x.Seller).Include(x => x.Address).Where(x => x.BuyerId == Guid.Parse(buyer)).FirstOrDefault());

                OrderItemsModel orderItem = OrderItemsMapper.Mapper(_context.OrderItems.Include(x => x.Order).Include(x => x.Seller).Include(x => x.Sku).Where(x => x.OrderId == order.Id && x.SkuId == Guid.Parse(skuId)).FirstOrDefault());

                var currentItem = _context.OrderItems.Find(orderItem.Id);
                currentItem.Quantity -= 1;

                _context.Update(currentItem); 

                var currentOrder = _context.Order.Find(order.Id);
                currentOrder.SubTotal -= orderItem.Sku.Price;
                currentOrder.Total -= orderItem.Sku.Price;

                _context.Update(currentOrder);
                _context.SaveChanges();
                return "OK";
            }
            return "FAIL";
        }
    }
}
