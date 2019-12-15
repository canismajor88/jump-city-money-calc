using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class JumpCityMoneyCalculator : Form
    {
        private MoneyAmounts moneyAmounts = new MoneyAmounts();
        public JumpCityMoneyCalculator()
        {
            InitializeComponent();
        }
        private void JumpCityMoneyCalculator_Load(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            
            DataSetter();
            Calculator Totals = new Calculator(moneyAmounts);

           txtTotal.Text = $"{Convert.ToDouble(Totals.GetDropTotal()):C}";
            btnBillAmounts.Enabled = true;
        }

        public void DataSetter()
        {
            moneyAmounts.DollarCoinAmount = ToIntAndNonNegitive(txtDollarCoins.Text);
            moneyAmounts.HalfDollarAmount = ToIntAndNonNegitive(txtHalfDollars.Text);
            moneyAmounts.QuartersAmount = ToIntAndNonNegitive(txtQuarters.Text);
            moneyAmounts.DimesAmount = ToIntAndNonNegitive(txtDimes.Text);
            moneyAmounts.NicklesAmount = ToIntAndNonNegitive(txtNickles.Text);
            moneyAmounts.PenniesAmount = ToIntAndNonNegitive(txtPennies.Text);
            moneyAmounts.HundredsAmount = ToIntAndNonNegitive(txtHundreds.Text);
            moneyAmounts.FiftiesAmount = ToIntAndNonNegitive(txtFiftys.Text);
            moneyAmounts.TwentiesAmount = ToIntAndNonNegitive(txtTwenties.Text);
            moneyAmounts.TensAmount = ToIntAndNonNegitive(txtTens.Text);
            moneyAmounts.FivesAmount = ToIntAndNonNegitive(txtFives.Text);
            moneyAmounts.OnesAmount = ToIntAndNonNegitive(txtOnes.Text);
        }
        public int ToIntAndNonNegitive(string input)
        {

            try
            {
                int result = Int32.Parse(input);
                if (result < 0)
                {
                    MessageBox.Show("Please enter positive numerical values,setting entered value to 0");
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
                MessageBox.Show("Please enter numerical values,setting entered value to 0");
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
            moneyAmounts.Clear();

        }

        private void btnBillAmounts_Click(object sender, EventArgs e)
        {
            BillHandler billHandler = new BillHandler(moneyAmounts);
            MessageBox.Show(billHandler.BillAmountsForDrop());
           
        }
    }
}
