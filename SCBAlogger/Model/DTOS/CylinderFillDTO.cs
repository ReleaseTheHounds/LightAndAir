using System;
using System.Collections.Generic;
using System.Text;

namespace SCBAlogger.Model.DTOS
{
    public class CylinderFillDto
    {
        public int FillId { get; set; }
        public int EventId { get; set; }
        public int CylinderId { get; set; }
        public int Pressure { get; set; }
        public string Condition { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
