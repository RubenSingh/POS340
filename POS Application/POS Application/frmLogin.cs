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

namespace POS_Application
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text !="" && txtPassword.Text !="")
            {

                DataTable dt=new DataTable();
                dt = DBAccess.FillDataTable("Select * from tbUser where Username='"+txtUsername.Text.Trim()+"' and password='"+ txtPassword.Text.Trim() + "' COLLATE SQL_Latin1_General_CP1_CS_AS and IsActive=1", dt);

                if(dt!=null && dt.Rows.Count>0)
                {
                    Form1 mainWin = new Form1();
                    mainWin.ShowDialog();
                    this.Close();
                    //MessageBox.Show("Login Successful.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Username or password Incorrect", "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("Please enter username or password", "POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
