using Microsoft.AspNetCore.Mvc;
using StuffAndThings.Data;
using StuffAndThings.Data.Entities;
using StuffAndThings.Data.Mapper;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StuffAndThings.Controllers
{
    public class LogController : Controller
    {
        public IActionResult CatalogPartialView()
        {
            DBContext _context = new DBContext();
            List<LogEntity> logsBase = _context.Logs.ToList();
            List<LogModel> logs = new List<LogModel>();
            foreach (var item in logsBase)
            {
                if (item.Type.Equals(Models.Enums.LogTypeEnum.Stocks) ||
                    item.Type.Equals(Models.Enums.LogTypeEnum.Products) ||
                    item.Type.Equals(Models.Enums.LogTypeEnum.Skus))
                {
                    logs.Add(LogMapper.Mapper(item));
                }
            }

            return View("CatalogPartialView", logs.OrderByDescending(x => x.Date));
        }

        public IActionResult UserPartialView()
        {
            DBContext _context = new DBContext();
            List<LogModel> logs = LogMapper.Mapper(_context.Logs.Where(x => x.Type == Models.Enums.LogTypeEnum.Users).ToList());

            return View("UserPartialView", logs.OrderByDescending(x => x.Date));
        }

        public IActionResult OrderPartialView()
        {
            DBContext _context = new DBContext();
            List<LogModel> logs = LogMapper.Mapper(_context.Logs.Where(x => x.Type == Models.Enums.LogTypeEnum.SaleOrders || x.Type == Models.Enums.LogTypeEnum.PurchaseOrders).ToList());

            return View("OrderPartialView", logs.OrderByDescending(x => x.Date));
        }

        [HttpPost]
        public void LogRegister(Object obj, string action, Models.Enums.LogTypeEnum type)
        {
            DBContext _context = new DBContext();
            LogModel log = new LogModel
            {
                Id = new Guid(),
                Date = DateTime.Now,
                Type = type,
                Action = action,
                JsonObject = JsonSerializer.Serialize(obj)
            };

            LogEntity logEntity = LogMapper.Mapper(log);

            _context.Logs.Add(logEntity);
            _context.SaveChanges();

        }
    }
}
