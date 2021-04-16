using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StuffAndThings.Data;
using StuffAndThings.Models;

namespace StuffAndThings.Controllers
{
    public class MaterialManagementController : Controller
    {
        public IActionResult Index()
        {
            DBContext _context = new DBContext();

            //ProductModel p = new ProductModel();
            //p.Id = new Guid();
            //p.Name = "Lukas Gay";
            //p.Code = "24";
            //p.Description = "O Lukas é Gay";
            //SkuModel s = new SkuModel();
            //s.Id = new Guid();
            //s.Name = "5";
            //s.Color = "Rosa";
            //s.Barcode = "GAY24";
            //s.AvailableQuantity = 57;
            //s.Price = 24.24;
            //p.Skus.Add(s);

            //_context.Products.Add(p);
            //_context.SaveChanges();

            ProductModel Product = new ProductModel();

            //Comentado pq iremos usar outro local para puxar a lista de produtos
            //Product.Products = _context.Products.ToList();

            return View(Product);
        }
    }
}
