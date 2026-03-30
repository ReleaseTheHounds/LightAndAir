using System;
using System.Collections.Generic;
using System.Text;

namespace SCBAlogger.Model.DTOS
{
    public class EventScanDto
    {
        public string SerialNumber { get; set; }
        public string HydroStatDate { get; set; }
        public int Pressure { get; set; }
        public string Condition { get; set; }
        public string Jurisdiction { get; set; }
        public string Operator { get; set; }
        public String Timestamp { get; set; }
    }

}
