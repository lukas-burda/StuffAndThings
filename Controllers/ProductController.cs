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
        [HttpGet]
        public IActionResult Index()
        {
            DBContext _context = new DBContext();
            List<ProductModel> products = ProductMapper.Mapper(_context.Products.Include(x => x.Skus).ToList());

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
            DBContext _context = new DBContext();
            ProductModel product = ProductMapper.Mapper(_context.Products.Include(x => x.Skus).Where(x => x.Id == Id).First());
            return View(product);
        }

        [HttpPost]
        public IActionResult Upsert(ProductModel product)
        {
            DBContext _context = new DBContext();
            LogController logger = new LogController();

            if (product.Id == new Guid())
            {
                _context.Products.Add(ProductMapper.Mapper(product));
                logger.LogRegister(product, "Created", Models.Enums.LogType.Products);
            }
            else
            {
                _context.Products.Update(ProductMapper.Mapper(product));
                logger.LogRegister(product, "Updated", Models.Enums.LogType.Products);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
