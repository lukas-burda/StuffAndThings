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

        public static List<LogModel> Mapper(List<LogEntity> leList)
        {
            List<LogModel> lmList = new List<LogModel>();
            foreach (var le in leList)
            {
                LogModel logModel = new LogModel
                {
                    Id = le.Id,
                    Date = le.Date,
                    Type = le.Type,
                    Action = le.Action,
                    JsonObject = le.JsonObject
                };

                lmList.Add(logModel);
            }
            
            return lmList;
        }

        public static List<LogEntity> Mapper(List<LogModel> lmList)
        {
            List<LogEntity> leList = new List<LogEntity>();
            foreach (var lm in lmList)
            {
                LogEntity logEntity = new LogEntity
                {
                    Id = lm.Id,
                    Date = lm.Date,
                    Type = lm.Type,
                    Action = lm.Action,
                    JsonObject = lm.JsonObject
                };

                leList.Add(logEntity);
            }
            
            return leList;
        }
    }
}
