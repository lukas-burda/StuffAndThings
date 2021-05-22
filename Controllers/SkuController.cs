using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StuffAndThings.Data;
using StuffAndThings.Data.Entities;
using StuffAndThings.Data.Mapper;
using StuffAndThings.Models;

namespace StuffAndThings.Controllers
{
    public class SkuController : Controller
    {
        public IActionResult Index()
        {
            DBContext _context = new DBContext();
            List<SkuModel> skus = SkuMapper.Mapper(_context.Skus.ToList());
            return View(skus);
        }

        public IActionResult Create()
        {
            DBContext _context = new DBContext();
            SkuModel sku = new SkuModel();
            sku.Products = ProductMapper.Mapper(_context.Products.ToList());
            return View(sku);
        }

        public IActionResult Edit(Guid Id)
        {
            DBContext _context = new DBContext();
            SkuModel sku = new SkuModel();
            sku = SkuMapper.Mapper(_context.Skus.Where(x => x.Id == Id).FirstOrDefault());
            sku.Product = ProductMapper.Mapper(_context.Products.Where(x => x.Id == sku.ProductId).FirstOrDefault());
            sku.ProductId = sku.Product.Id;
            return View(sku);
        }

        public IActionResult Upsert(SkuModel sku)
        {
            DBContext _context = new DBContext();
            LogController logger = new LogController();
            if (sku.Id == new Guid())
            {
                ProductEntity product = _context.Products.Where(x => x.Id == sku.ProductId).FirstOrDefault();

                product.Skus.Add(SkuMapper.Mapper(sku));
                _context.Products.Update(product);
                                
                logger.LogRegister(sku, "Created", Models.Enums.LogType.Skus);
            }
            else
            {
                _context.Skus.Update(SkuMapper.Mapper(sku));
                logger.LogRegister(sku, "Updated", Models.Enums.LogType.Skus);
            }
                
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
