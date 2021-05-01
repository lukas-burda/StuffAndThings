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
    public class MaterialManagementController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            DBContext _context = new DBContext();
            List<SkuStocksEntity> stocksBase = _context.Stocks.Include(x => x.Sku).Include(x => x.Seller).ToList();
            List<ProductEntity> products = _context.Products.Include(x => x.Skus).ToList();

            foreach (var p in products)
            {
                foreach (var s in p.Skus) s.Name = p.Name + " " + s.Name;
            }

            List<SkuStocksModel> stocks = new List<SkuStocksModel>();
            foreach (var item in stocksBase) stocks.Add(StockMapper.Mapper(item));
            return View(stocks);
        }

        [HttpGet]
        public IActionResult Create()
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
            List<UserEntity> users = _context.Users.ToList();
            foreach (var item in skus) stocks.Skus.Add(SkuMapper.Mapper(item));
            foreach (var item in users) stocks.Sellers.Add(UserMapper.Mapper(item));

            return View(stocks);
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            DBContext _context = new DBContext();
            SkuStocksEntity stocksBase = _context.Stocks.Include(x => x.Sku).Include(x => x.Seller).Where(x => x.Id == Id).SingleOrDefault();
            SkuStocksModel stock = StockMapper.Mapper(stocksBase);

                
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
                    log.MovimentationRegister(stock, "AddNewError", Models.Enums.LogType.Stocks);
                    return RedirectToAction("Index");
                }
                stock.Id = Guid.NewGuid();
                stock.LastUpdate = DateTime.Now;
                log.MovimentationRegister(stock, "AddNew", Models.Enums.LogType.Stocks);
                _context.Stocks.Add(StockMapper.Mapper(stock));
                
            }
            else
            {
                stock.LastUpdate = DateTime.Now;
                _context.Stocks.Update(StockMapper.Mapper(stock));

                log.MovimentationRegister(stock, "UpdateExistent", Models.Enums.LogType.Stocks);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid Id)
        {
            DBContext _context = new DBContext();
            SkuStocksEntity stock = _context.Stocks.Where(x => x.Id == Id).FirstOrDefault();
            _context.Stocks.Remove(stock);

            LogController log = new LogController();
            log.MovimentationRegister(stock, "Delete", Models.Enums.LogType.Stocks);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
