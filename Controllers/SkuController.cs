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
        #region GET
        public IActionResult Index()
        {
            List<SkuModel> skus = GetAllSkus();
            return View(skus);
        }

        public IActionResult Create()
        {
            SkuModel sku = new SkuModel();
            sku.Products = ProductController.GetAllProducts();
            return View(sku);
        }

        public IActionResult Edit(Guid Id)
        {
            SkuModel sku = GetSkuById(Id);
            sku.Product = ProductController.GetProductById(sku.ProductId);
            sku.ProductId = sku.Product.Id;
            return View(sku);
        }

        public IActionResult DeleteSkuById(Guid Id)
        {
            try
            {
                DBContext _context = new DBContext();
                LogController log = new LogController();
                SkuEntity skuEntity = _context.Skus.Where(x => x.Id == Id).FirstOrDefault();
                log.LogRegister(skuEntity, "Deleted", Models.Enums.LogTypeEnum.Skus);
                _context.Remove(skuEntity);
                _context.SaveChanges();
                return RedirectToAction("SucessMessage", "Home", new { message = "Sku have been deleted.|Index" });
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorMessage", "Home", new { message = "Sku have not been deleted.|Index" });
            }

        }

        public static List<SkuModel> GetAllSkus()
        {
            DBContext _context = new DBContext();
            List<SkuModel> skus = SkuMapper.Mapper(_context.Skus.ToList());
            return skus;
        }

        public static SkuModel GetSkuById(Guid Id)
        {
            DBContext _context = new DBContext();
            SkuModel sku = SkuMapper.Mapper(_context.Skus.Where(x => x.Id == Id).FirstOrDefault());
            return sku;
        }
        #endregion

        #region POST
        public IActionResult Upsert(SkuModel sku)
        {
            DBContext _context = new DBContext();
            LogController logger = new LogController();
            if (sku.Id == new Guid())
            {
                ProductModel product = ProductController.GetProductById(sku.ProductId);

                product.Skus.Add(sku);
                _context.Products.Update(ProductMapper.Mapper(product));
                                
                logger.LogRegister(sku, "Created", Models.Enums.LogTypeEnum.Skus);
            }
            else
            {
                _context.Skus.Update(SkuMapper.Mapper(sku));
                logger.LogRegister(sku, "Updated", Models.Enums.LogTypeEnum.Skus);
            }
                
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion
    }
}
