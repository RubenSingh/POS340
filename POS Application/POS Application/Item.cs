using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_Application.DAL;

using System.Data.SqlClient;

namespace POS_Application
{
    public partial class FrmItem : Form
    {
        public FrmItem()
        {
            InitializeComponent();
        }

        private void FrmItem_Load(object sender, EventArgs e)
        {

        }

        
        string conn = DBAccess.ConnectionString;
        DataRow dr;

        private void btnSave_Click(object sender, EventArgs e)
        {
            int chkdisc = 0;
            try
            {
                if (chkDiscount.Checked == true)
                {
                    chkdisc = 1;
                }


                string qry = "INSERT INTO tbItem(ID, ItemName, Price, Quantity, Tax, IsDiscount) VALUES('" + txtDepartment.Text.Trim() + "','" + txtName.Text.Trim() + "','" + txtPrice.Text.Trim() + "','" + txtQty.Text.Trim() + "','" + txtTax.Text.Trim() + "','" + chkdisc + "')";//('" + txtDepartment.Text.Trim() + "', '" + txtName.Text.Trim() + "', '" + txtPrice.Text.Trim() + "', '" + txtQty.Text.Trim() + "', '" + txtTax.Text.Trim() + "', '" + chkDiscount.Checked + "')";

                bool success = DBAccess.ExecuteInsertQuery(qry);

                if (success)
                {
                    MessageBox.Show("Item Inserted Successfully.", "POS Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Item Insertion Failed.", "POS Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }
        }

        void ClearText()
        {
            txtName.Clear();
            txtQty.Clear();
            txtPrice.Clear();
            txtDepartment.Clear();
            txtTax.Clear();
            chkDiscount.Checked = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Deptext_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
