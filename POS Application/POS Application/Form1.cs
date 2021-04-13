using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStoreManager_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Panelitems.Visible = true;
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            FrmItem objItem = new FrmItem();
            objItem.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Panelitems.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            Customer objCustomer = new Customer();
            objCustomer.ShowDialog();
        }
    }
}
