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
            List<SkuEntity> skusEntity = _context.Skus.ToList();
            List<SkuModel> skus = new List<SkuModel>();
            foreach (var item in skusEntity) skus.Add(SkuMapper.Mapper(item));
            return View(skus);
        }

        public IActionResult Create()
        {
            DBContext _context = new DBContext();
            SkuModel sku = new SkuModel();
            List<ProductEntity> pEntity = _context.Products.ToList();
            foreach (var item in pEntity) sku.Products.Add(ProductMapper.Mapper(item));
            return View(sku);
        }

        public IActionResult Upsert(SkuModel sku)
        {
            DBContext _context = new DBContext();
            ProductEntity product = _context.Products.Where(x => x.Id == sku.ProductId).FirstOrDefault();
            product.Skus.Add(SkuMapper.Mapper(sku));
            _context.Products.Update(product);
            _context.SaveChanges();

            LogController logger = new LogController();
            logger.LogRegister(sku, "Created", Models.Enums.LogType.Skus);
            return RedirectToAction("Index");
        }
    }
}
