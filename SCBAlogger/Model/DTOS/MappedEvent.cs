using System;
using System.Collections.Generic;
using System.Text;

namespace SCBAlogger.Model.DTOS
{
 public class MappedEvent
    {
       public string SerialNumber { get; set; }
       public  string HydrostatDate { get; set; } 
       public int Pressure { get; set; }
       public string Condition { get; set; }
       public string JuridictionName { get; set; }
       public string OperatorName { get; set; }   
       public string EventName { get; set; }    

    }
}
