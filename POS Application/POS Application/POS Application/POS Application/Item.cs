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
            GetDepartment();
        }

       
        string conn = DBAccess.ConnectionString;
        DataRow dr;

        public void GetDepartment()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    using (SqlCommand command = new SqlCommand("select Department_ID, DepartmentName from tbDepartment", connection))
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dr = dt.NewRow();
                        dr.ItemArray = new object[] { 0, "--Select--" };
                        dt.Rows.InsertAt(dr, 0);
                        ddlDepartment.ValueMember = "Department_ID";
                        ddlDepartment.DisplayMember = "DepartmentName";
                        ddlDepartment.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int chkdisc = 0;
            try
            {
                int DeptID = Convert.ToInt32(ddlDepartment.SelectedValue.ToString());

                if (chkDiscount.Checked == true)
                {
                    chkdisc = 1;
                }


                string qry = "INSERT INTO tbItem(ID, ItemName, Price, Quantity, Tax, IsDiscount) VALUES('" + DeptID + "','" + txtName.Text.Trim() + "','" + txtPrice.Text.Trim() + "','" + txtQty.Text.Trim() + "','" + txtTax.Text.Trim() + "','" + chkdisc + "')";//('" + txtDepartment.Text.Trim() + "', '" + txtName.Text.Trim() + "', '" + txtPrice.Text.Trim() + "', '" + txtQty.Text.Trim() + "', '" + txtTax.Text.Trim() + "', '" + chkDiscount.Checked + "')";

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
            ddlDepartment.SelectedIndex = 0;
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
