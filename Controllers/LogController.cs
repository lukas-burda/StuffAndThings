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
        public IActionResult StockPartialView()
        {
            DBContext _context = new DBContext();
            List<LogEntity> logsBase = _context.Logs.ToList();
            List<LogModel> logs = new List<LogModel>();
            foreach (var item in logsBase)
            {
                if (item.Type.Equals(Models.Enums.LogType.Stocks))
                {
                    logs.Add(LogMapper.Mapper(item));
                }
            }

            return View("StockPartialView", logs.OrderByDescending(x => x.Date));
        }

        public IActionResult UserPartialView()
        {
            DBContext _context = new DBContext();
            List<LogEntity> logsBase = _context.Logs.ToList();
            List<LogModel> logs = new List<LogModel>();
            foreach (var item in logsBase)
            {
                if (item.Type.Equals(Models.Enums.LogType.Users))
                {
                    logs.Add(LogMapper.Mapper(item));
                }
            }

            return View("UserPartialView", logs.OrderByDescending(x => x.Date));
        }

        public IActionResult OrderPartialView()
        {
            DBContext _context = new DBContext();
            List<LogEntity> logsBase = _context.Logs.ToList();
            List<LogModel> logs = new List<LogModel>();
            foreach (var item in logsBase)
            {
                if (item.Type.Equals(Models.Enums.LogType.SaleOrders) || item.Type.Equals(Models.Enums.LogType.PurchaseOrders))
                {
                    logs.Add(LogMapper.Mapper(item));
                }
            }

            return View("OrderPartialView", logs.OrderByDescending(x => x.Date));
        }

        [HttpPost]
        public void MovimentationRegister(Object obj, string action, Models.Enums.LogType type)
        {
            DBContext _context = new DBContext();
            LogModel log = new LogModel();
            log.Id = new Guid();
            log.Date = DateTime.Now;
            log.Type = type;
            log.Action = action;
            log.JsonObject = JsonSerializer.Serialize(obj);

            LogEntity logEntity = LogMapper.Mapper(log);

            _context.Logs.Add(logEntity);
            _context.SaveChanges();

        }
    }
}
