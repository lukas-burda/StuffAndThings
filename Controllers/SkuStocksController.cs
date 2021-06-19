using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffAndThings.Data;
using StuffAndThings.Data.Entities;
using StuffAndThings.Data.Mapper;
using StuffAndThings.Models;

namespace StuffAndThings.Controllers
{
    public class SkuStocksController : Controller
    {
        #region GET
        [HttpGet]
        public IActionResult Index(Guid Id)
        {
            List<SkuStocksModel> stocks = GetAllStocksBySeller(Id);
            List<ProductModel> products = ProductController.GetAllProducts();

            if (stocks.Count <= 0)
            {
                return RedirectToAction("ErrorMessage", "Home", new { message = "This seller haven't any products.|SellerIndex" });
            }
            else
            {
                foreach (var p in products)
                {
                    foreach (var s in p.Skus)
                    {
                        s.Name = p.Name + " " + s.Name;
                    }
                }
            }

            return View(stocks);
        }


        [HttpGet]
        public IActionResult Create(Guid Id)
        {
            SkuStocksModel stocks = new SkuStocksModel();
            List<ProductModel> products = ProductController.GetAllProducts();
            List<SkuModel> skus = new List<SkuModel>();
            foreach (var p in products)
            {
                foreach (var s in p.Skus)
                {
                    s.Name = p.Name + " " + s.Name;
                    skus.Add(s);
                }
            }
            stocks.Sellers = UserManagementController.GetAllSellers();
            stocks.Skus = skus;

            return View(stocks);
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            SkuStocksModel stock = GetStockById(Id);
            return View(stock);
        }

        [HttpGet]
        public static SkuStocksModel GetStockById(Guid Id)
        {
            DBContext _context = new DBContext();
            SkuStocksModel stock = StockMapper.Mapper(_context.Stocks.Include(x => x.Sku).Include(x => x.Seller).Where(x => x.Id == Id).SingleOrDefault());
            return stock;
        }

        [HttpGet]
        public static List<SkuStocksModel> GetAllStocks()
        {
            DBContext _context = new DBContext();
            List<SkuStocksModel> stocks = StockMapper.Mapper(_context.Stocks.Include(x => x.Sku).Include(x => x.Seller).ToList());
            return stocks;
        }

        [HttpGet]
        public static List<SkuStocksModel> GetAllStocksBySeller(Guid SellerId)
        {
            DBContext _context = new DBContext();
            List<SkuStocksModel> stocks = StockMapper.Mapper(_context.Stocks.Include(x => x.Sku).Include(x => x.Seller).Where(x => x.SellerId == SellerId).ToList());
            return stocks;
        }
        #endregion

        #region POST
        [HttpPost]
        public IActionResult Upsert(SkuStocksModel stock)
        {
            DBContext _context = new DBContext();
            LogController log = new LogController();

            if (stock.Id == new Guid())
            {
                List<SkuStocksModel> stocks = GetAllStocks();
                SkuStocksModel existe = stocks.Where(x => x.Seller.Id == stock.Seller.Id && x.Sku.Id == stock.Sku.Id).FirstOrDefault();
                if (existe != null)
                {
                    log.LogRegister(stock, "CreatedError", Models.Enums.LogTypeEnum.Stocks);
                    return RedirectToAction("Index", stock.Seller.Id);
                }
                stock.Id = Guid.NewGuid();
                stock.LastUpdate = DateTime.Now;
                log.LogRegister(stock, "Created", Models.Enums.LogTypeEnum.Stocks);
                _context.Stocks.Add(StockMapper.Mapper(stock));

            }
            else
            {
                stock.LastUpdate = DateTime.Now;
                _context.Stocks.Update(StockMapper.Mapper(stock));

                log.LogRegister(stock, "Updated", Models.Enums.LogTypeEnum.Stocks);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = stock.Seller.Id });
        }

        public IActionResult Delete(Guid Id)
        {
            DBContext _context = new DBContext();
            SkuStocksModel stock = GetStockById(Id);
            _context.Stocks.Remove(StockMapper.Mapper(stock));

            LogController log = new LogController();
            log.LogRegister(stock, "Deleted", Models.Enums.LogTypeEnum.Stocks);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion
    }
}
