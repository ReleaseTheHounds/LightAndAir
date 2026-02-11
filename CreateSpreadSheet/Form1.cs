using OfficeOpenXml;

namespace CreateSpreadSheet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<String> GetList()
            {
                List<String> list = new List<String>();
                list.Add("One");
                list.Add("Two");
                list.Add("Three");
                return list;
            }


            ExcelPackage.License.SetNonCommercialPersonal("Stafford County Fire and Rescue");
            using (var package = new ExcelPackage(@"c:\temp\myWorkbook.xlsx"))
            {

                var myList = GetList();

                var sheet = package.Workbook.Worksheets.Add("Cropp");
                sheet.Cells["A1"].LoadFromCollection(myList, true);
                // Save to file
                package.Save();
            }
        }
    }
}
