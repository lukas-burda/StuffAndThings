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
            LogModel logModel = new LogModel();
            logModel.Id = logEntity.Id;
            logModel.Date = logEntity.Date;
            logModel.Type = logEntity.Type;
            logModel.Action = logEntity.Action;
            logModel.JsonObject = logEntity.JsonObject;

            return logModel;
        }

        public static LogEntity Mapper(LogModel logModel)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.Id = logModel.Id;
            logEntity.Date = logModel.Date;
            logEntity.Type = logModel.Type;
            logEntity.Action = logModel.Action;
            logEntity.JsonObject = logModel.JsonObject;

            return logEntity;
        }
    }
}
