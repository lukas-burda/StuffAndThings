using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StuffAndThings.Data;
using StuffAndThings.Models;

namespace StuffAndThings.Controllers
{
    public class MaterialManagementController : Controller
    {
        public IActionResult Index()
        {
            DBContext _context = new DBContext();
            List<SkuStocksModel> stocks = _context.Stocks.ToList();
            return View(stocks);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(Guid Id)
        {
            DBContext _context = new DBContext();
            SkuStocksModel stock = _context.Stocks.Where(x => x.Id == Id).FirstOrDefault();
            return View(stock);
        }

        public IActionResult Upsert(SkuStocksModel stock)
        {
            DBContext _context = new DBContext();
            if (stock.Id == new Guid())
            {
                stock.Id = Guid.NewGuid();
                _context.Stocks.Add(stock);
            }
            else
            {
                _context.Stocks.Update(stock);
            }

            return RedirectToAction("Index");
        }
    }
}
