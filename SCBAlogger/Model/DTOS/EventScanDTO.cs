using System;
using System.Collections.Generic;
using System.Text;

namespace SCBAlogger.Model.DTOS
{
    public class EventScanDto
    {
        public string CylinderId { get; set; }
        public string SerialNumber { get; set; }
        public int Pressure { get; set; }
        public string Condition { get; set; }
        public String Timestamp { get; set; }
    }

}
