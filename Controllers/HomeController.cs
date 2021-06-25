using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
            List<ShowcaseModel> showcases = ShowcaseController.GetAllShowcases();
            return View(showcases);
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

        public IActionResult ErrorMessage(string message)
        {
            try
            {
                String[] splitedMessage = message.Split("|");
                return View("Error", new ErrorViewModel { Message = splitedMessage[0], ViewToGo = splitedMessage[1], RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception)
            {

                return View("Index");
            }

        }

        public IActionResult Sucess()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SucessMessage(string message)
        {
            try
            {
                String[] splitedMessage = message.Split("|");
                return View("Sucess", new ErrorViewModel { Message = splitedMessage[0], ViewToGo = splitedMessage[1], RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception)
            {

                return View("Index");
            }
            
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
                ImageUrl = "https://i.imgur.com/ps6alt2.jpg",
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
                ImageUrl = "https://i.imgur.com/ps6alt2.jpg",
                Price = 7.00
            };

            p1.Skus.Add(s1);
            p1.Skus.Add(s2);

            _context.Products.Add(ProductMapper.Mapper(p1));

            ProductModel p2 = new ProductModel
            {
                Id = Guid.NewGuid(),
                Name = "Fanta Laranja",
                Code = "0002",
                Description = "Refri de laranja",
                ImageUrl = "https://i.imgur.com/cxKXQ0k.png",
                Skus = new List<SkuModel>()
            };

            SkuModel s3 = new SkuModel
            {
                Id = Guid.NewGuid(),
                Name = "350 ml",
                Barcode = "79300251362",
                Price = 4.50,
                Color = "#f24f00",
                ImageUrl = "https://i.imgur.com/cxKXQ0k.png"
            };

            p2.Skus.Add(s3);

            _context.Products.Add(ProductMapper.Mapper(p2));

            UserModel u = new UserModel
            {
                Id = Guid.NewGuid(),
                FullName = "Shopping Palladium",
                Document = "08355847000109",
                Discriminator = Models.Enums.DiscriminatorEnum.Seller
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

            ShowcaseModel sc = new ShowcaseModel
            {
                Id = Guid.NewGuid(),
                Name = "Inverno",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                LastUpdate = DateTime.Now
            };

            ShowcaseItemsModel scp1 = new ShowcaseItemsModel()
            {
                Id = Guid.NewGuid(),
                ShowCase = sc,
                Sku = s2
            };

            ShowcaseItemsModel scp2 = new ShowcaseItemsModel()
            {
                Id = Guid.NewGuid(),
                ShowCase = sc,
                Sku = s3
            };

            ShowcaseItemsMapper.Mapper(scp1);
            ShowcaseItemsMapper.Mapper(scp2);

            _context.Showcases.Add(ShowcaseMapper.Mapper(sc));
            _context.ShowcaseItems.Add(ShowcaseItemsMapper.Mapper(scp1));
            _context.ShowcaseItems.Add(ShowcaseItemsMapper.Mapper(scp2));

            AddressModel address = new AddressModel
            {
                Id = Guid.NewGuid()
            };

            _context.Add(AddressMapper.Mapper(address));

            OrderModel order = new OrderModel
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Discount = 0,
                SubTotal = 0,
                Total = 0,
                FriendlyCode = "LUKAS",
                Buyer = new UserModel
                {
                    Id = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                },
                Seller = new UserModel
                {
                    Id = u.Id,
                },
                Address = address
            };

            _context.Order.Add(OrderMapper.Mapper(order));

            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
