using StuffAndThings.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Models
{
    public class LogModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string JsonObject { get; set; }
        public string Action { get; set; }
        public LogType Type { get; set; }
    }
}
