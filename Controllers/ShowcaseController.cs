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
        public static List<ShowcaseModel> GetAllShowcases()
        {
            DBContext _context = new DBContext();
            List<ShowcaseModel> showcases = ShowCaseMapper.Mapper(_context.ShowCases.ToList());
            foreach (var item in showcases)
            {
                item.ShowcaseSkus = ShowcaseSkusMapper.Mapper(_context.ShowCaseProducts.Where(y => y.ShowCaseId == item.Id).Include(x => x.Sku).ToList());
                foreach (var sku in item.ShowcaseSkus)
                {
                    sku.Sku.Product = ProductMapper.Mapper(_context.Products.Where(x => x.Id == sku.Sku.ProductId).FirstOrDefault());
                }
            }

            return showcases;
        }
    }
}
