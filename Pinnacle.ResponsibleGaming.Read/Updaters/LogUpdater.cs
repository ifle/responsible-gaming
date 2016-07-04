using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pinnacle.ResponsibleGaming.Read.Mappers;
using Pinnacle.ResponsibleGaming.Read.Models;

namespace Pinnacle.ResponsibleGaming.Read.Updaters
{
    public class LogUpdater
    {
        private readonly DbContext _dbContext;

        public LogUpdater(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Update(DepositLimitSet depositLimitSet)
        {
            var key = "log/" + depositLimitSet.CustomerId;

            var logEntry = new LogEntry().Map(depositLimitSet);
            var document = await _dbContext.Set<Document>().FirstOrDefaultAsync(x => x.Key == key);
            if (document != null)
            {
                var log = JsonConvert.DeserializeObject<Log>(document.Value);
                log.Add(logEntry);
                document.Value = JsonConvert.SerializeObject(log);
            }
            else
            {
                document = new Document
                {
                    Key = key,
                    Value = JsonConvert.SerializeObject(new Log { logEntry })
                };
            }

            _dbContext.Set<Document>().AddOrUpdate(document);
            
             _dbContext.SaveChanges();
        }
        public async Task Update(DepositLimitDisabled depositLimitDisabled)
        {
            var key = "Log/" + depositLimitDisabled.CustomerId;

            var logEntry = new LogEntry().Map(depositLimitDisabled);
            var document = await _dbContext.Set<Document>().FirstOrDefaultAsync(x => x.Key == key);
            if (document != null)
            {
                var log = JsonConvert.DeserializeObject<Log>(document.Value);
                log.Add(logEntry);
                document.Value = JsonConvert.SerializeObject(log);
            }
            else
            {
                document = new Document
                {
                    Key = key,
                    Value = JsonConvert.SerializeObject(new Log { logEntry })
                };
            }

            _dbContext.Set<Document>().AddOrUpdate(document);

            await _dbContext.SaveChangesAsync();
        }
    }
}
