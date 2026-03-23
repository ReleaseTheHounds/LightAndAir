using SCBAlogger.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SCBAlogger.Services
{

    public class WorkbookGenerator
    {
        public Task WorkbookGeneratorAsync(Event ev)
        {
            Debugger.Break();
            return Task.CompletedTask;
        }
    }
}
//private void CreateNewWorkBook()
//{
//    ExcelPackage.License.SetNonCommercialPersonal("Stafford County Fire and Rescue");
//    using (var package = new ExcelPackage())
//    {
//        var events = _context.UnprocessedEvents
//       .FromSql($"Execute dbo.GetUnprocessedEvents")
//       .ToList();
//        string? sheetName = String.Empty;
//        if (events.Count > 0)
//        {
//            // TODO: the resuls are now orders on EventDate to premit them to be batched on Month and Year. Add the checks for changes in Month  and year to close out a workbook and start another
//            DateTime tmpDate = events[0].EventDate;
//            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(tmpDate.Month);
//            string workbookName = $"C:\\temp\\Scans{monthName}{tmpDate.Year}.xlsx";
//            // this creates a permonth/year workbook for the events.
//            // If there are multiple events in the same month they will be added to the same workbook but different sheets.
//            WindowsLog.WriteLogEntry(EventLogEntryType.Information, $"Retrieved {events.Count} unprocessed events from the database", 7001);
//            foreach (UnprocessedEvents t in events)
//            {
//                sheetName = $"{t.Name}";
//                DateTime eventDate = t.EventDate;
//                if ( sheetName == "")
//                {
//                    throw new Exception("Event Name is null or empty, cannot create sheet name");
//                }
//                var sheet = package.Workbook.Worksheets.Add(sheetName);
//                var stuff = _context.EventScans
//                     .FromSql($"Execute dbo.GetEventScans {t.ID}")
//                     .ToList();
//                WindowsLog.WriteLogEntry(EventLogEntryType.Information, $"Retrieved {stuff.Count} scans for event {t.ID}", 7002);

//                sheet.Cells["A1"].LoadFromCollection(stuff, true);
//                package.SaveAs(workbookName);

//                Event anEvent = _context.Events.Find(t.ID);
//                if (anEvent !=null)
//                {
//                    anEvent.ExcelFileName = workbookName;
//                }  
//            }
//            _context.SaveChanges();
//        }
//    }
//}
