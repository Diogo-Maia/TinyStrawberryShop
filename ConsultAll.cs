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
    public partial class ConsultAll : Form
    {
        private DB_Manager db;
        private DataTable dt;

        private List<List<String>> rows;
        List<string> values;

        private int current;

        public ConsultAll()
        {
            current = 0;
            rows = new List<List<string>>();
            db = new DB_Manager();

            dt = db.GetAllOrders();

            InitializeComponent();
            try
            {
                UpdateRows();
                ShowOrder();
            }
            catch
            {
            }
        }

        private void UpdateRows()
        {
            List<string> _row;

            foreach (DataRow row in dt.Rows)
            {
                _row = new List<string>();
                foreach (DataColumn col in dt.Columns)
                {
                    _row.Add(Convert.ToString(row[col]));
                }
                rows.Add(_row);
            }
        }


        private void ShowOrder()
        {
            values = new List<string>();
            foreach (string value in rows[current])
            {
                values.Add(value);
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (current <= 0)
                    current = 0;
                else
                    current--;

                ShowOrder();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (current < rows.Count - 1)
                    current++;

                ShowOrder();
            }
            catch
            {

            }

        }
    }
    
}
