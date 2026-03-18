using System;
using System.Collections.Generic;
using System.Text;

namespace SCBAlogger.Model
{
    public partial class UnprocessedEvents
    {
    
       public int ID { get; set; }

        public DateTime EventDate { get; set; }

        public  string? Name { get; set; }


    }
}