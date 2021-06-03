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
            sc.Products = ProductController.GetAllProducts();
            return View(sc);
        }

        [HttpGet]
        public static List<ShowcaseModel> GetAllShowcases()
        {
            DBContext _context = new DBContext();
            List<ShowcaseModel> showcases = ShowCaseMapper.Mapper(_context.Showcases.ToList());
            foreach (var item in showcases)
            {
                item.ShowcaseSkus = ShowcaseSkusMapper.Mapper(_context.ShowcaseSkus.Where(y => y.ShowCaseId == item.Id).Include(x => x.Sku).ToList());
                foreach (var sku in item.ShowcaseSkus)
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
            DBContext _context = new DBContext();
            if (sc.Id == new Guid())
            {
                sc.Id = Guid.NewGuid();
                _context.Showcases.Add(ShowCaseMapper.Mapper(sc));

                foreach (var scs in sc.ShowcaseSkus)
                {
                    scs.ShowCase.Id = sc.Id;
                    _context.ShowcaseSkus.Add(ShowcaseSkusMapper.Mapper(scs));
                }
                _context.SaveChanges();
            }
            return null;
        }
        #endregion

    }
}
