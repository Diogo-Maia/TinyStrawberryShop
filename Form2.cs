using System;
using System.Windows.Forms;

namespace Mady
{
    public partial class Form2 : Form
    {
        private DB_Manager db;

        public Form2()
        {
            db = new DB_Manager();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.PushOrder(textBoxName.Text, textBoxAdress.Text,
                textBoxItems.Text, textBoxInsta.Text, textBoxPrice.Text ,textBoxNotes.Text);

            textBoxName.Text = "";
            textBoxAdress.Text = "";
            textBoxInsta.Text = "";
            textBoxItems.Text = "";
            textBoxNotes.Text = "";
            textBoxPrice.Text = "";
        }
    }
}
