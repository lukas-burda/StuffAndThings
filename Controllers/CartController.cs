using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StuffAndThings.Data;

namespace StuffAndThings.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(Guid Id)
        {
            DBContext _context = new DBContext();
            LogController log = new LogController();

            //To-Do
            //Aqui haverá adição de produtos no carrinho
            //Com validação de existência = soma, inexistente = inserção 

            return View();
        }
    }
}
