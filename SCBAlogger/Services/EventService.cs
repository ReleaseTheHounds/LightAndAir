using SCBAlogger.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCBAlogger.Services
{
    public class EventService
    {
     
        private readonly IDatabaseExecutionService _dbExec;

        public EventService(IDatabaseExecutionService dbexec)
        {
            _dbExec = dbexec; 
        }

        public Task<List<Event>> GetUnprocessedEventsAsync()
        {
            return _dbExec.ExecMappedListAsync<Event>(
                "dbo.GetUnprocessedEvents",
                reader => new Event
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    EventDate = reader.GetDateTime(reader.GetOrdinal("EventDate")),
                    Name = reader.GetString(reader.GetOrdinal("Name"))

                }
            );
        }

    }
}
