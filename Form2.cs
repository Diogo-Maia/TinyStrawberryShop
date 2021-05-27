using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Mady
{
    public partial class Form2 : Form
    {
        private DB_Manager db = new DB_Manager();

        public Form2()
        {
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
        }
    }
}
