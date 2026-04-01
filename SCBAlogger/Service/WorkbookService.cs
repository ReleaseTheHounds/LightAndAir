using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SCBAlogger.Data;
using SCBAlogger.Model;
using SCBAlogger.Model.DTOS;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using SCBAlogger.Service;


/* await _context.Events.Where(e => e.Id == ev.EventId)
                     .ExecuteUpdateAsync(setters => setters
                     .SetProperty(e => e.WorkbookCreatedDate, DateTime.Now));

*/

namespace SCBAlogger.Service
{
    public class WorkbookService
    {
        

        public WorkbookService()
        {
            //TODO: Make this an installation property
            ExcelPackage.License.SetNonCommercialOrganization("StaffordCountyFireAndRescue");
        }

        public string Create(UnprocessedEventDto ev, List<EventScanDto> scans)
        {

            var jurisdictions = scans.Select(s => s.Jurisdiction).Distinct().ToList();
            // string firstSheetTitle =  (jurisdictions.Count == 1) ? $"{jurisdictions[0]}" : "All Tanks filled";
            string firstSheetTitle = ev.EventName;
            string sheetName = (jurisdictions.Count == 1) ? $"{jurisdictions[0]}" : "All Tank Fills";
            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add(sheetName);


            // add some logic to tailor this for the # of jurisdictions.
            ws.Name = "All Tanks filled";
            var headerFooter = ws.HeaderFooter;


            headerFooter.differentFirst = false;
            headerFooter.OddHeader.CenteredText = firstSheetTitle;
            headerFooter.OddHeader.RightAlignedText = ev.EventDate.ToShortDateString();
            headerFooter.OddHeader.LeftAlignedText = ev.Compressor;
            headerFooter.OddFooter.CenteredText = $"Generated on {DateTime.Now:ddMMMyyy}";
            headerFooter.OddFooter.RightAlignedText = $"Page {ExcelHeaderFooter.PageNumber} of {ExcelHeaderFooter.NumberOfPages}";
            

            // Write headers
            ws.Cells[1, 1].Value = "Serial Number";
            ws.Cells[1, 2].Value = "Hydrostat Date";
            ws.Cells[1, 3].Value = "Condition";
            ws.Cells[1, 4].Value = "Pressure";
            ws.Cells[1, 5].Value = "Operator";
            ws.Cells[1, 6].Value = "Jurisdiction";

            
            int row = 2;
            foreach (var scan in scans)
            {
                ws.Cells[row, 1].Value = scan.SerialNumber;
                ws.Cells[row, 2].Value = scan.HydroStatDate;
                ws.Cells[row, 3].Value = scan.Condition;
                ws.Cells[row, 4].Value = scan.Pressure;
                ws.Cells[row, 5].Value = scan.Operator;
                ws.Cells[row, 6].Value = scan.Jurisdiction;
                row++;
            }



            ws.Cells.AutoFitColumns();

            


            if (jurisdictions.Count > 1)
            {
                ChartService charts = new ChartService();
                charts.AddJurisdictionPieChart(ws);

                // Create a separate sheet for each jurisdiction
                foreach (var jurisdiction in jurisdictions)
                {

                    var jurisdictionSheet = package.Workbook.Worksheets.Add(jurisdiction);

                    jurisdictionSheet.HeaderFooter.OddHeader.CenteredText = $"{ev.EventName} Tank Fills for {jurisdiction}";
                    jurisdictionSheet.HeaderFooter.OddHeader.RightAlignedText = ev.EventDate.ToShortDateString();
                    jurisdictionSheet.HeaderFooter.OddHeader.LeftAlignedText = ev.Compressor;
                    jurisdictionSheet.HeaderFooter.OddFooter.CenteredText = $"{ExcelHeaderFooter.SheetName} Generated on {DateTime.Now:ddMMMyyy}";
                    jurisdictionSheet.HeaderFooter.OddFooter.RightAlignedText = $"Page {ExcelHeaderFooter.PageNumber} of {ExcelHeaderFooter.NumberOfPages}";

                    

                    jurisdictionSheet.Cells[1, 1].Value = "Serial Number";
                    jurisdictionSheet.Cells[1, 2].Value = "Hydrostat Date";
                    jurisdictionSheet.Cells[1, 3].Value = "Condition";
                    jurisdictionSheet.Cells[1, 4].Value = "Pressure";
                    jurisdictionSheet.Cells[1, 5].Value = "Operator";
                    int jurisdictionRow = 2;
                    foreach (var scan in scans.Where(s => s.Jurisdiction == jurisdiction))
                    {
                        jurisdictionSheet.Cells[jurisdictionRow, 1].Value = scan.SerialNumber;
                        jurisdictionSheet.Cells[jurisdictionRow, 2].Value = scan.HydroStatDate;
                        jurisdictionSheet.Cells[jurisdictionRow, 3].Value = scan.Condition;
                        jurisdictionSheet.Cells[jurisdictionRow, 4].Value = scan.Pressure;
                        jurisdictionSheet.Cells[jurisdictionRow, 5].Value = scan.Operator;
                        jurisdictionRow++;
                    }
                    jurisdictionSheet.Cells.AutoFitColumns();
                }

                // Add a summary sheet with the jurisdiction breakdown
                // Move the summary sheet to the end of the workbook
                package.Workbook.Worksheets.MoveToEnd(1);

            }


            string filename = $"{ev.EventName}_{DateTime.Now:ddMMMyyy}";

            var filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                $"{filename}.xlsx");

            package.SaveAs(new FileInfo(filePath));



            return filePath;

        }


    }
}
