using System;
using System.Collections.Generic;
using System.Text;

namespace SCBAlogger.Model.DTOS
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Jurisdiction { get; set; }
        public string OperatorsCsv { get; set; }
    }

}
