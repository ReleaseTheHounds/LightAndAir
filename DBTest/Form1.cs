using DBTest.Model;

namespace DBTest
{
    public partial class Form1 : Form
    {

        private readonly ScbaContext _context = new ScbaContext();
        private BindingSource _bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {

            bool iscreated = _context.Database.CanConnect();

            _bindingSource.DataSource = _context.ScannedTanks.ToList();

            dataGridView1.DataSource = _bindingSource;




        }
    }
}
