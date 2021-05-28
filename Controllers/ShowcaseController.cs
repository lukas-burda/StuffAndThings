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
            showcases.ForEach(x => x.ShowcaseProducts = ShowCaseProductsMapper.Mapper(_context.ShowCaseProducts.Where(y => y.ShowCaseId == x.Id).Include(x => x.Product).ToList()));

            return showcases;
        }
    }
}
