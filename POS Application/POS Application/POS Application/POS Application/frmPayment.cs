using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POS_Application
{
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        public frmPayment(decimal Total)
        {
            this.TotalAmount = Total;
            InitializeComponent();
        }

        decimal TotalAmount = 0;
        decimal BalanceAmount = 0;
        private const int CS_DROPSHADOW = 0x00020000;
        public string numberRole = "MONEY";

        private void frmPayment_Load(object sender, EventArgs e)
        {
            lblDueAmt.Text = TotalAmount.ToString();
            txtAmount.Select();
            btnOkay.Enabled = false;
            Calculate();
        }

        bool PaymentSuccess = false;
        public bool ShowDialog()
        {
            base.ShowDialog();
            return PaymentSuccess;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            PaymentSuccess = true;
            this.Close();
        }
    }
}
