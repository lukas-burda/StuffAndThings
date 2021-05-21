using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StuffAndThings.Data;
using StuffAndThings.Data.Entities;
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Carregar()
        {
            DBContext _context = new DBContext();
            ProductModel p1 = new ProductModel
            {
                Id = Guid.NewGuid(),
                Code = "0001",
                Name = "Coca-Cola",
                Description = "Refrigerante",
                Skus = new List<SkuModel>()
            };

            SkuModel s1 = new SkuModel
            {
                Id = Guid.NewGuid(),
                Barcode = "793001215",
                Name = "350 ml",
                Color = "#ff0000",
                Price = 4.50
            };

            SkuModel s2 = new SkuModel
            {
                Id = Guid.NewGuid(),
                Barcode = "793001216",
                Name = "2 L",
                Color = "#ff0000",
                Price = 7.00
            };

            p1.Skus.Add(s1);
            p1.Skus.Add(s2);

            _context.Products.Add(ProductMapper.Mapper(p1));

            UserModel u = new UserModel
            {
                Id = Guid.NewGuid(),
                FullName = "Shopping Palladium",
                CNPJ = "08355847000109",
                Discriminator = Models.Enums.Discriminator.Seller
            };

            _context.Users.Add(UserMapper.Mapper(u));

            SkuStocksModel ss = new SkuStocksModel
            {
                Id = Guid.NewGuid(),
                AvailableQuantity = 52,
                LastUpdate = DateTime.Now,
                Sku = s1,
                Seller = u
            };

            _context.Stocks.Add(StockMapper.Mapper(ss));

            //ShowcaseModel sc = new ShowcaseModel
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Inverno",
            //    StartDate = DateTime.Now,
            //    EndDate = DateTime.Now,
            //    LastUpdate = DateTime.Now
            //};

            //ShowcaseProductsModel scp = new ShowcaseProductsModel()
            //{
            //    Id = Guid.NewGuid(),
            //    ShowCase = sc,
            //    Product = p1
            //};

            //ShowCaseProductsMapper.Mapper(scp);

            //_context.Products.Add(ProductMapper.Mapper(p1));

            //_context.ShowCases.Add(ShowCaseMapper.Mapper(sc));
            //_context.ShowCaseProducts.Add(ShowCaseProductsMapper.Mapper(scp));

            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
