using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace SCBAlogger
{
    internal class WindowsLog
    {   static public string LogName = "Application";
        static  public string Source  = "SCBALogger";
        public int EventID { get; set; }
        public string Message { get; set; }
        public DateTime TimeGenerated { get; set; }

        public WindowsLog()
        {
            EventID = 0;
            Message = string.Empty;
            TimeGenerated = DateTime.Now;
        }

        public static void WriteLogEntry(EventLogEntryType entryType, string Message, int EventID)
        {
            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, LogName);
            }
            using EventLog eventLog = new(LogName);
            eventLog.Source = Source;
            eventLog.WriteEntry(Message, entryType, EventID);
        }
    }
}
