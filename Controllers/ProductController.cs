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
            List<ProductEntity> productsBase = _context.Products.Include(x => x.Skus).ToList();
            List<ProductModel> products = new List<ProductModel>();
            foreach (var item in productsBase) products.Add(ProductMapper.Mapper(item));
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
            ProductEntity productBase = _context.Products.Include(x => x.Skus).Where(x => x.Id == Id).First();
            ProductModel product = ProductMapper.Mapper(productBase);
            return View(product);
        }

        [HttpPost]
        public IActionResult Upsert(ProductModel product)
        {
            DBContext _context = new DBContext();
            LogController log = new LogController();

            if (product.Id == new Guid())
                _context.Products.Add(ProductMapper.Mapper(product));
            else
                _context.Products.Update(ProductMapper.Mapper(product));

            return RedirectToAction("Index");
        }
    }
}
