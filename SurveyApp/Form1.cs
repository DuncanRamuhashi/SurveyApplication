using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.ForeColor = System.Drawing.Color.Blue;
            
            page11.Show();
            page11.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
             
            label2.ForeColor = System.Drawing.Color.Black;
            label3.ForeColor = System.Drawing.Color.Blue;

            page11.Hide();
            page21.Refresh();
            page21 = new Page2();
            page21.Show();
            page21.BringToFront();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.Black;
            label2.ForeColor = System.Drawing.Color.Blue;

            page21.Hide();
            page11.Show();
            page11.BringToFront();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
