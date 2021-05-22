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

        [HttpGet]
        public IActionResult Index(Guid Id)
        {
            DBContext _context = new DBContext();
            List<SkuStocksModel> stocks = StockMapper.Mapper(_context.Stocks.Include(x => x.Sku).Include(x => x.Seller).Where(x => x.SellerId == Id).ToList());
            List<ProductEntity> products = _context.Products.Include(x => x.Skus).ToList();

            foreach (var p in products)
            {                
                foreach (var s in p.Skus)
                {
                    s.Name = p.Name + " " + s.Name;
                }
            }

            return View(stocks);
        }

        [HttpGet]
        public IActionResult Create(Guid Id)
        {
            DBContext _context = new DBContext();
            SkuStocksModel stocks = new SkuStocksModel();
            List<ProductEntity> products = _context.Products.Include(x => x.Skus).ToList();
            List<SkuEntity> skus = new List<SkuEntity>();
            foreach (var p in products)
            {
                foreach (var s in p.Skus)
                {
                    s.Name = p.Name + " " + s.Name;
                    skus.Add(s);
                }
            }
            stocks.Sellers = UserMapper.Mapper(_context.Users.Where(x => x.Id == Id).ToList());
            stocks.Skus = SkuMapper.Mapper(skus);

            return View(stocks);
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            DBContext _context = new DBContext();
            SkuStocksModel stock = StockMapper.Mapper(_context.Stocks.Include(x => x.Sku).Include(x => x.Seller).Where(x => x.Id == Id).SingleOrDefault());


            return View(stock);
        }

        [HttpPost]
        public IActionResult Upsert(SkuStocksModel stock)
        {
            DBContext _context = new DBContext();
            LogController log = new LogController();

            if (stock.Id == new Guid())
            {
                List<SkuStocksEntity> stocks = _context.Stocks.Include(x => x.Sku).Include(x => x.Seller).ToList();
                SkuStocksEntity existe = stocks.Where(x => x.SellerId == stock.Seller.Id && x.SkuId == stock.Sku.Id).FirstOrDefault();
                if (existe != null)
                {
                    log.LogRegister(stock, "CreatedError", Models.Enums.LogType.Stocks);
                    return RedirectToAction("Index", stock.Seller.Id);
                }
                stock.Id = Guid.NewGuid();
                stock.LastUpdate = DateTime.Now;
                log.LogRegister(stock, "Created", Models.Enums.LogType.Stocks);
                _context.Stocks.Add(StockMapper.Mapper(stock));

            }
            else
            {
                stock.LastUpdate = DateTime.Now;
                _context.Stocks.Update(StockMapper.Mapper(stock));

                log.LogRegister(stock, "Updated", Models.Enums.LogType.Stocks);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = stock.Seller.Id });
        }

        public IActionResult Delete(Guid Id)
        {
            DBContext _context = new DBContext();
            SkuStocksEntity stock = _context.Stocks.Where(x => x.Id == Id).FirstOrDefault();
            _context.Stocks.Remove(stock);

            LogController log = new LogController();
            log.LogRegister(stock, "Deleted", Models.Enums.LogType.Stocks);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
