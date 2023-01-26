namespace Tax_calculator
{
    public partial class Form1 : Form
    {
        decimal taxDue = 0;
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (txtPrice.Text != String.Empty)
            {
                if (!txtPrice.Text.Contains("$"))
                {
                    txtPrice.Text = "$" + Math.Round(Convert.ToDouble(txtPrice.Text), 2);
                }
                else
                {
                    txtPrice.Text = "$" + Math.Round(Convert.ToDouble(txtPrice.Text.Substring(1)), 2);
                }
            }
        }
        private void reset_all()
        {
            txtPrice.Text = "$0.00";
            txtTaxDue.Text = "$0.00";
            txtPrice.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset_all();
        }
        private void getTaxDue()
        {
            if (txtPrice.Text.Contains("$"))
                taxDue = Convert.ToDecimal(txtPrice.Text.Substring(1));


            
            
                taxDue = Convert.ToDecimal(txtPrice.Text.Substring(1)) * (scaleTaxRate.Value / 100);

            

            txtTaxDue.Text = taxDue.ToString();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            getTaxDue();
        }
    }
}