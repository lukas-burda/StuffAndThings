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
        public IActionResult Index()
        {
            DBContext _context = new DBContext();
            List<LogEntity> logsBase = _context.Logs.ToList();
            List<LogModel> logs = new List<LogModel>();

            foreach (var item in logsBase) logs.Add(LogMapper.Mapper(item));

            return View(logs);
        }

        [HttpPost]
        public void ModelsMovimentationLog(Object obj, string action)
        {
            DBContext _context = new DBContext();
            LogModel log = new LogModel();
            log.Id = new Guid();
            log.Date = DateTime.Now;
            log.Type = Models.Enums.LogType.Stocks;

            log.Action = action;
            log.JsonObject = JsonSerializer.Serialize(obj);

            LogEntity logEntity = LogMapper.Mapper(log);

            _context.Logs.Add(logEntity);
            _context.SaveChanges();

        }
    }
}
