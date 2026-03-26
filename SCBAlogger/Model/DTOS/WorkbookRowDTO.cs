using System;
using System.Collections.Generic;
using System.Text;

namespace SCBAlogger.Model.DTOS
{
    public class WorkbookRowDto
    {
        public int CylinderId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime HydroDate { get; set; }
        public int Pressure { get; set; }
        public string Condition { get; set; }
        public string Owner { get; set; }
    }

}
