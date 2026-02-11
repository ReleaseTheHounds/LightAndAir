using System.Diagnostics;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;

namespace SCBAlogger
{
    public partial class CreateBarcode : Form
    {


        public CreateBarcode()
        {
            InitializeComponent();
        }

        static Bitmap ToBitmap(BitMatrix matrix)
        {
            int width = matrix.Width;
            int height = matrix.Height;
            var bmp = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp.SetPixel(x, y, matrix[x, y] ? Color.Black : Color.White);
                }
            }
            return bmp;
        }

        private void BarcodeTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                var barcodeWriter = new BarcodeWriter();
                barcodeWriter.Options.PureBarcode = false;
                barcodeWriter.Options.Height = 50;
                barcodeWriter.Options.Width = 300;
                barcodeWriter.Options.Margin = 25;
                barcodeWriter.Options.GS1Format = true;
                barcodeWriter.Options.NoPadding = true;
                barcodeWriter.Format = BarcodeFormat.CODE_128;

                var bitmap = barcodeWriter.WriteAsBitmap(BarcodeTextBox.Text);


                BarcodeImage.Image = bitmap;
                System.Windows.Forms.Clipboard.SetImage(bitmap);
                EventLog.WriteEntry("SCBALogger", $"Created a barcode for {BarcodeTextBox.Text} and copied it to the clipboard.", EventLogEntryType.Information, 30003, 1);

            }
        }

        private void CreateBarcode_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
