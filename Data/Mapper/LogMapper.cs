using StuffAndThings.Data.Entities;
using StuffAndThings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Data.Mapper
{
    public class LogMapper
    {
        public static LogModel Mapper(LogEntity logEntity)
        {
            LogModel logModel = new LogModel
            {
                Id = logEntity.Id,
                Date = logEntity.Date,
                Type = logEntity.Type,
                Action = logEntity.Action,
                JsonObject = logEntity.JsonObject
            };

            return logModel;
        }

        public static LogEntity Mapper(LogModel logModel)
        {
            LogEntity logEntity = new LogEntity
            {
                Id = logModel.Id,
                Date = logModel.Date,
                Type = logModel.Type,
                Action = logModel.Action,
                JsonObject = logModel.JsonObject
            };

            return logEntity;
        }
    }
}
