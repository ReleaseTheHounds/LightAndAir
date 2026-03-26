using System;
using System.Collections.Generic;
using System.Text;

namespace SCBAlogger.Model.DTOS
{
    public class CylinderDto
    {
        public int CylinderId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime HydroDate { get; set; }
        public string Owner { get; set; }
    }

}
