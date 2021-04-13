using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POS_Application.DAL;

namespace POS_Application
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "Insert into tbCustomer(FirstName,LastName,MobileNo,Email,State,City,Address,Zipcode)values('" + txtFirstName.Text.Trim() + "','" + txtLastName.Text.Trim() + "','" + txtMobile.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtState.Text.Trim() + "','" + txtCity.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + txtZip.Text.Trim() + "')";

                bool success = DBAccess.ExecuteInsertQuery(qry);

                if (success)
                {
                    MessageBox.Show("Customer Inserted Successfully.", "POS Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Customer Insertion Failed.", "POS Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        void ClearText()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMobile.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtZip.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
