using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffAndThings.Data;
using StuffAndThings.Data.Entities;
using StuffAndThings.Data.Mapper;
using StuffAndThings.Models;

namespace StuffAndThings.Controllers
{
    public class ProductController : Controller
    {
        #region GET
        [HttpGet]
        public IActionResult Index()
        {
            List<ProductModel> products = GetAllProducts();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            ProductModel product = GetProductById(Id);
            return View(product);
        }

        public IActionResult DeleteProductById(Guid Id)
        {
            try
            {
                DBContext _context = new DBContext();
                LogController log = new LogController();
                ProductEntity productEnitity = _context.Products.Where(x => x.Id == Id).FirstOrDefault();
                log.LogRegister(productEnitity, "Deleted", Models.Enums.LogTypeEnum.Products);
                _context.Remove(productEnitity);
                _context.SaveChanges();
                return RedirectToAction("SucessMessage", "Home", new { message = "Product have been deleted.|Index" });
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorMessage", "Home", new { message = "Product have not been deleted.|Index" });
            }

        }

        public static List<ProductModel> GetAllProducts()
        {
            DBContext _context = new DBContext();
            List<ProductModel> products = ProductMapper.Mapper(_context.Products.Include(x => x.Skus).ToList());
            return products;
        }

        public static ProductModel GetProductById(Guid Id)
        {
            DBContext _context = new DBContext();
            ProductModel product = ProductMapper.Mapper(_context.Products.Include(x => x.Skus).FirstOrDefault());
            return product;
        }
        #endregion

        #region POST
        [HttpPost]
        public IActionResult Upsert(ProductModel product)
        {
            DBContext _context = new DBContext();
            LogController logger = new LogController();

            if (product.Id == new Guid())
            {
                _context.Products.Add(ProductMapper.Mapper(product));
                logger.LogRegister(product, "Created", Models.Enums.LogTypeEnum.Products);
            }
            else
            {
                _context.Products.Update(ProductMapper.Mapper(product));
                logger.LogRegister(product, "Updated", Models.Enums.LogTypeEnum.Products);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
