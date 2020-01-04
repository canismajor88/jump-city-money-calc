using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace JumpCityMoneyCalculator
{
    public partial class JumpCityMoneyCalculator : Form
    {
        private readonly MoneyAmounts _moneyAmounts = new MoneyAmounts();
        public JumpCityMoneyCalculator()
        {
            InitializeComponent();
        }
        private void JumpCityMoneyCalculator_Load(object sender, EventArgs e)
        {
            MessageBox.Show(@"This form is a work in progress and does not represent final product, if there any problems or issues please contact Caleb ");
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            
            DataSetter();
            Calculator Totals = new Calculator(_moneyAmounts);

           txtTotal.Text = $"{Convert.ToDouble(Totals.GetDropTotal()):C}";
            btnBillAmounts.Enabled = true;
        }

        public void DataSetter()
        {
            _moneyAmounts.DollarCoinAmount = ToIntAndNonNegative(txtDollarCoins.Text);
            _moneyAmounts.HalfDollarAmount = ToIntAndNonNegative(txtHalfDollars.Text);
            _moneyAmounts.QuartersAmount = ToIntAndNonNegative(txtQuarters.Text);
            _moneyAmounts.DimesAmount = ToIntAndNonNegative(txtDimes.Text);
            _moneyAmounts.NicklesAmount = ToIntAndNonNegative(txtNickles.Text);
            _moneyAmounts.PenniesAmount = ToIntAndNonNegative(txtPennies.Text);
            _moneyAmounts.HundredsAmount = ToIntAndNonNegative(txtHundreds.Text);
            _moneyAmounts.FiftiesAmount = ToIntAndNonNegative(txtFiftys.Text);
            _moneyAmounts.TwentiesAmount = ToIntAndNonNegative(txtTwenties.Text);
            _moneyAmounts.TensAmount = ToIntAndNonNegative(txtTens.Text);
            _moneyAmounts.FivesAmount = ToIntAndNonNegative(txtFives.Text);
            _moneyAmounts.OnesAmount = ToIntAndNonNegative(txtOnes.Text);
        }
        public int ToIntAndNonNegative(string input)
        {

            try
            {
                int result = Int32.Parse(input);
                if (result < 0)
                {
                    MessageBox.Show(@"Please enter positive numerical values,setting entered value to 0");
                    result = 0;
                }
                return result;

            }
            catch (FormatException)
            {
                if (input == "")
                {
                    return 0;
                }
                MessageBox.Show(@"Please enter numerical values,setting entered value to 0",@"Error");
                return 0;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDollarCoins.Text = "";
            txtHalfDollars.Text = "";
            txtQuarters.Text = "";
            txtDimes.Text = "";
            txtNickles.Text = "";
            txtPennies.Text = "";
            txtHundreds.Text = "";
            txtFiftys.Text = "";
            txtTwenties.Text = "";
            txtTens.Text = "";
            txtFives.Text = "";
            txtOnes.Text = "";
            txtTotal.Text = "";
            btnBillAmounts.Enabled = false;
            _moneyAmounts.Clear();

        }

        private void btnBillAmounts_Click(object sender, EventArgs e)
        {
            BillHandler billHandler = new BillHandler(_moneyAmounts);
            MessageBox.Show(billHandler.BillAmountsForDrop());
           
        }
    }
}
