using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffAndThings.Data;
using StuffAndThings.Data.Mapper;
using StuffAndThings.Models;

namespace StuffAndThings.Controllers
{
    public class ShowcaseController : Controller
    {
        #region GET
        [HttpGet]
        public IActionResult Index()
        {
            List<ShowcaseModel> scList = GetAllShowcases();
            return View(scList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ShowcaseModel sc = new ShowcaseModel();
            sc.Skus = SkuController.GetAllSkus();
            return View(sc);
        }

        [HttpGet]
        public static List<ShowcaseModel> GetAllShowcases()
        {
            DBContext _context = new DBContext();
            List<ShowcaseModel> showcases = ShowcaseMapper.Mapper(_context.Showcases.ToList());
            foreach (var item in showcases)
            {
                item.ShowcaseItems = ShowcaseItemsMapper.Mapper(_context.ShowcaseItems.Where(y => y.ShowCaseId == item.Id).Include(x => x.Sku).ToList());
                foreach (var sku in item.ShowcaseItems)
                {
                    sku.Sku.Product = ProductMapper.Mapper(_context.Products.Where(x => x.Id == sku.Sku.ProductId).FirstOrDefault());
                }
            }

            return showcases;
        }

        [HttpGet]
        public static List<ShowcaseModel> GetAllAvailableShowcases()
        {
            DBContext _context = new DBContext();
            List<ShowcaseModel> showcases = ShowcaseMapper.Mapper(_context.Showcases.Where(x => x.StartDate <= DateTime.Now && x.EndDate >= DateTime.Now).ToList());
            foreach (var item in showcases)
            {
                item.ShowcaseItems = ShowcaseItemsMapper.Mapper(_context.ShowcaseItems.Where(y => y.ShowCaseId == item.Id).Include(x => x.Sku).ToList());
                foreach (var sku in item.ShowcaseItems)
                {
                    sku.Sku.Product = ProductMapper.Mapper(_context.Products.Where(x => x.Id == sku.Sku.ProductId).FirstOrDefault());
                }
            }

            return showcases;
        }
        #endregion

        #region POST
        [HttpPost]
        public IActionResult Upsert(ShowcaseModel sc)
        {

            var SkuCodes = sc.ShowCaseItemCodes.Split("\r\n");
            DBContext _context = new DBContext();
            if (sc.Id == new Guid())
            {
                sc.Id = Guid.NewGuid();
                _context.Showcases.Add(ShowcaseMapper.Mapper(sc));

                foreach (var item in SkuCodes)
                {
                    ShowcaseItemsModel scs = new ShowcaseItemsModel();
                    scs.ShowCase = sc;
                    scs.Sku = SkuMapper.Mapper(_context.Skus.Where(x => x.Barcode == item).FirstOrDefault());
                    _context.ShowcaseItems.Add(ShowcaseItemsMapper.Mapper(scs));

                }

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion

    }
}
