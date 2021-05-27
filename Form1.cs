using System;
using System.Windows.Forms;

namespace Mady
{
    public partial class Form1 : Form
    {
        Form2 adressForm;
        Consult consult;
        ConsultAll consultAll;
        Search search;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adressForm = new Form2();
            adressForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            consult = new Consult();
            consult.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            consultAll = new ConsultAll();
            consultAll.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            search = new Search();
            search.Show();
        }
    }
}
