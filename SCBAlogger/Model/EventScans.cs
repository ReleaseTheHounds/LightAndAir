using System;
using System.Collections.Generic;
using System.Text;

namespace SCBAlogger.Model
{
    public partial class EventScans
    {
        public string SerialNumber { get; set; } = null!;   
        public string HydrostatDate { get; set; } = null!;
        public string Condition { get; set; } = null!;
        public int Pressure { get; set; }
        public string Jurisdiction { get; set; } = null!;
        public string OperatorName { get; set; } = null!;
        public string Name { get; set; } = null!;

    }
}
