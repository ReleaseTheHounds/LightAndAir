using OfficeOpenXml;
using SCBAlogger.Model;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using SCBAlogger.Model.DTOS;


namespace SCBAlogger.Service
{
    public class WorkbookService
    {

        public WorkbookService()
        {
            //TODO: Make this an installation property
            ExcelPackage.License.SetNonCommercialOrganization("StaffordCountyFireAndRescue");
        }

        public DateTime Create(UnprocessedEventDto ev, List<EventScanDto> scans)
        {

            var jurisdictions = scans.Select(s => s.Jurisdiction).Distinct().ToList();
            // string firstSheetTitle =  (jurisdictions.Count == 1) ? $"{jurisdictions[0]}" : "All Tanks filled";
            string firstSheetTitle = ev.EventName;
            string sheetName = (jurisdictions.Count == 1) ? $"{jurisdictions[0]}" : "All Tanks";
            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add(sheetName);


            // add some logic to tailor this for the # of jurisdictions.
            ws.Name = "All Tanks filled";
            var headerFooter = ws.HeaderFooter;
         

            headerFooter.differentFirst = false;
            headerFooter.FirstHeader.CenteredText = firstSheetTitle;
            headerFooter.FirstHeader.RightAlignedText = ev.EventDate.ToShortDateString();
            headerFooter.FirstHeader.LeftAlignedText = ev.Compressor;
            headerFooter.FirstFooter.CenteredText = $"Generated on {DateTime.Now:ddMMMyyy}";    
            headerFooter.FirstFooter.RightAlignedText = $"Page {ExcelHeaderFooter.PageNumber} of {ExcelHeaderFooter.NumberOfPages}";
            headerFooter.

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
                jurisdictions.RemoveAt(0);


                //headerFooter.differentFirst = false;
                //headerFooter.FirstHeader.CenteredText = firstSheetTitle;
                //headerFooter.FirstHeader.RightAlignedText = ev.EventDate.ToShortDateString();
                //headerFooter.FirstHeader.LeftAlignedText = ev.Compressor;
                //headerFooter.FirstFooter.CenteredText = $"Generated on {DateTime.Now:ddMMMyyy}";
                //headerFooter.FirstFooter.RightAlignedText = $"Page {ExcelHeaderFooter.PageNumber} of {ExcelHeaderFooter.NumberOfPages}";


                foreach (var jurisdiction in jurisdictions)
                {
                    var jurisdictionSheet = package.Workbook.Worksheets.Add(jurisdiction);
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
            }


            string filename = $"{ev.EventName}_{DateTime.Now:ddMMMyyy}";




            
            var filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                $"Event_{filename}.xlsx");

            package.SaveAs(new FileInfo(filePath));

            return DateTime.Now;

        }


    }
}
