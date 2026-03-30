using System;
using System.Collections.Generic;
using System.Text;

namespace SCBAlogger.Model.DTOS
{
    public class UnprocessedEventDto
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Compressor { get; set; }
        public DateTime EventDate { get; set; }
       
    }

}
