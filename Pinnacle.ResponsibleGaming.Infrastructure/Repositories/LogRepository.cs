<<<<<<< HEAD
﻿using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;
=======
﻿using Pinnacle.ResponsibleGaming.Domain.Entities;
>>>>>>> feature/with_messaging
using Pinnacle.ResponsibleGaming.Domain.Repositories;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;

namespace Pinnacle.ResponsibleGaming.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
<<<<<<< HEAD
        private readonly Context _context;

        public LogRepository(Context context)
=======
        private readonly ResponsibleGamingContext _context;

        public LogRepository(ResponsibleGamingContext context)
>>>>>>> feature/with_messaging
        {
            _context = context;
        }

        public void Add(Log log)
        {
<<<<<<< HEAD
            _context.Set<Log>().Add(log);
=======
            _context.Logs.Add(log);
>>>>>>> feature/with_messaging
        }
    }
}
