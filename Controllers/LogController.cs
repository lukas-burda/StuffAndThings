﻿using Microsoft.AspNetCore.Mvc;
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
            //List<LogEntity> logsBase = _context.Logs.ToList();
            List<LogEntity> logsBase = _context.Logs.ToList();

            List<LogModel> logs = new List<LogModel>();
            foreach (var item in logsBase)
            {
                //if (item.Action.Equals(Models.Enums.LogType.Stocks))
                //{
                    logs.Add(LogMapper.Mapper(item));
                //}
            }

            return View("StockPartialView", logs);
        }

        //public IActionResult Stock()
        //{
        //    
        //}

        //public IActionResult OrderIndex()
        //{
        //    DBContext _context = new DBContext();
        //    List<LogEntity> logsBase = _context.Logs.ToList();
        //    List<LogModel> logs = new List<LogModel>();

        //    foreach (var item in logsBase)
        //    {
        //        if (!item.Action.Equals(Models.Enums.LogType.SaleOrders))
        //        {
        //            logsBase.Remove(item);
        //        }

        //        logs.Add(LogMapper.Mapper(item));
        //    }

        //    return View(logs);
        //}

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

        public void MovimentationRegister(Object obj, string action, Models.Enums.OrderType type)
        {
            DBContext _context = new DBContext();
            LogModel log = new LogModel();
            log.Id = new Guid();
            log.Date = DateTime.Now;
            switch (type)
            {
                case Models.Enums.OrderType.PurchaseOrder:
                    log.Type = Models.Enums.LogType.PurchaseOrders;
                    break;
                case Models.Enums.OrderType.SaleOrder:
                    log.Type = Models.Enums.LogType.SaleOrders;
                    break;
                default:
                    log.Type = Models.Enums.LogType.None;
                    break;
            }
            log.Action = action;
            log.JsonObject = JsonSerializer.Serialize(obj);

            LogEntity logEntity = LogMapper.Mapper(log);

            _context.Logs.Add(logEntity);
            _context.SaveChanges();

        }
    }
}
