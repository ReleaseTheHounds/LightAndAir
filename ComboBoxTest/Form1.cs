namespace ComboBoxTest
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            comboBox.Items.Add("C#");
            comboBox.Items.Add("Java");
            comboBox.Items.Add("Python");

            bool exists = comboBox.Items.Contains("Java1");
            MessageBox.Show(exists ? "Item found!" : "Item not found!");

        }


    }
}
