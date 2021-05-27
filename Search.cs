using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mady
{
    public partial class Search : Form
    {
        DB_Manager db;
        private DataTable dt;

        List<string> values;

        public Search()
        {
            db = new DB_Manager();
            InitializeComponent();

            db = new DB_Manager();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = db.Search(textBox1.Text);

            UpdateRows();
            ShowOrder();
        }

        private void UpdateRows()
        {
            values = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    values.Add(Convert.ToString(row[col]));
                }
            }
        }


        private void ShowOrder()
        {
            if(values.Count > 2)
            {
                labelName.Text = values[1];
                labelAdress.Text = values[2];
                labelItems.Text = values[3];

                if (!values[4].Contains("@"))
                    labelInsta.Text = "@" + values[4];
                else
                    labelInsta.Text = values[4];

                labelNotes.Text = values[5];

                if (!values[7].Contains("€"))
                    labelPrice.Text = values[7] + " €";
                else
                    labelPrice.Text = values[7];

                checkBox1.Checked = values[6] == "1";
                checkBox2.Checked = values[8] == "1";
            }
            else
            {
                labelName.Text = "NOT FOUND";
                labelAdress.Text = "NOT FOUND";
                labelItems.Text = "NOT FOUND";
                labelInsta.Text = "NOT FOUND";
                labelNotes.Text = "NOT FOUND";
                labelPrice.Text = "NOT FOUND";
            }
            
        }
    }
}
