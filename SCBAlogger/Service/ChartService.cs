using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

namespace SCBAlogger.Service
{
    public class ChartService
    {


        public ChartService() { }

        public void AddJurisdictionPieChart(ExcelWorksheet ws)
        {

            // 1. Determine the used range
            int lastRow = ws.Dimension.End.Row;

            // 2. Create a pivot-like summary table on a new sheet
            var summary = ws.Workbook.Worksheets.Add("JurisdictionSummary");

            summary.Cells["A1"].Value = "Jurisdiction";
            summary.Cells["B1"].Value = "Count";

            // 3. Use LINQ over worksheet rows to group jurisdictions
            var jurisdictions = new List<string>();

            for (int row = 2; row <= lastRow; row++)
            {
                var j = ws.Cells[row, 6].Text;   // Column 6 = Jurisdiction
                if (!string.IsNullOrWhiteSpace(j))
                    jurisdictions.Add(j);
            }

            var grouped = jurisdictions
                .GroupBy(j => j)
                .Select(g => new { Jurisdiction = g.Key, Count = g.Count() })
                .ToList();

            // 4. Write summary table
            int r = 2;
            foreach (var item in grouped)
            {
                summary.Cells[r, 1].Value = item.Jurisdiction;
                summary.Cells[r, 2].Value = item.Count;
                r++;
            }

            // 5. Create the Pie Chart
            var chart = summary.Drawings.AddChart("JurisdictionPie", eChartType.Pie) as ExcelPieChart;

            chart.Title.Text = "Jurisdiction Distribution";

            // Data range (counts)
            var dataRange = summary.Cells[2, 2, r - 1, 2];

            // Label range (jurisdictions)
            var labelRange = summary.Cells[2, 1, r - 1, 1];

            chart.Series.Add(dataRange, labelRange);
            int height = 300;
            // Optional: position & size
            chart.SetPosition(1, 0, 3, 0);   // Row 1, Col 3
            chart.SetSize((int)1.5*height, height);
        }
    }
}
