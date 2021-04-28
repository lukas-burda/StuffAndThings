using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StuffAndThings.Data;
using StuffAndThings.Data.Mapper;
using StuffAndThings.Models;

namespace StuffAndThings.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Carregar()
        {
            DBContext _context = new DBContext();

            UserModel dep1 = new UserModel();
            dep1.Id = Guid.NewGuid();
            dep1.FullName = "Dep. Curitiba";
            dep1.CNPJ = "72.147.938/0001-40";

            UserModel dep2 = new UserModel();
            dep2.Id = Guid.NewGuid();
            dep2.FullName = "Dep. Bahia";
            dep2.CNPJ = "10.843.242/0001-09";

            ProductModel prod1 = new ProductModel();
            prod1.Id = Guid.NewGuid();
            prod1.Name = "Coca-Cola";
            prod1.Description = "Coca-cola é o melhor refrigerante do Brasil";
            prod1.Code = "C0001";
            prod1.ImageUrl = "https://static.distribuidoracaue.com.br/media/catalog/product/cache/1/thumbnail/600x800/9df78eab33525d08d6e5fb8d27136e95/r/e/refrigerante-coca-cola-2-litros.jpg";

            SkuModel sku1 = new SkuModel();
            sku1.Id = Guid.NewGuid();
            sku1.Name = "350 ml";
            sku1.Color = "#ff0000";
            sku1.Barcode = "978020137962";
            sku1.Price = 4.50;

            prod1.Skus.Add(sku1);

            SkuStocksModel ss1 = new SkuStocksModel();
            ss1.Id = Guid.NewGuid();
            ss1.AvailableQuantity = 21;
            ss1.Sku = sku1;
            ss1.Seller = dep1;

            SkuStocksModel ss2 = new SkuStocksModel();
            ss2.Id = Guid.NewGuid();
            ss2.AvailableQuantity = 57;
            ss2.Sku = sku1;
            ss2.Seller = dep2;

            _context.Users.Add(UserMapper.Mapper(dep1));
            _context.SaveChanges();
            _context.Users.Add(UserMapper.Mapper(dep2));
            _context.SaveChanges();
            _context.Products.Add(ProductMapper.Mapper(prod1));
            _context.SaveChanges();
            _context.Stocks.Add(StockMapper.Mapper(ss1));
            _context.SaveChanges();
            _context.Stocks.Add(StockMapper.Mapper(ss2));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
