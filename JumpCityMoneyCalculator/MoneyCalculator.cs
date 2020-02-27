using System;
using System.Windows.Forms;
using RegisterDropCalculator;

namespace JumpCityMoneyCalculator
{
    public partial class JumpCityMoneyCalculator : Form
    {
        private readonly BillHandler _billHandler;
        private readonly Calculator _calculator;
        private readonly MoneyAmounts _moneyAmounts;

        public JumpCityMoneyCalculator(MoneyAmounts moneyAmounts, Calculator calculator, BillHandler billHandler)
        {
            _moneyAmounts = moneyAmounts;
            _calculator = calculator;
            _billHandler = billHandler;

            InitializeComponent();
        }

        private void JumpCityMoneyCalculator_Load(object sender, EventArgs e)
        {
            AlertUser("This form is a work in progress and does not represent final product, if there any problems or issues please contact Caleb.");
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            DataSetter();

            txtTotal.Text = $"{Convert.ToDouble(_calculator.GetDropTotal()):C}";
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

        // public int ToIntAndNonNegative(string input)
        // {
        //     try
        //     {
        //         var result = int.Parse(input);
        //         if (result < 0)
        //         {
        //             AlertUser("Please enter positive numerical values,setting entered value to 0");
        //             result = 0;
        //         }
        //
        //         return result;
        //     }
        //     catch (FormatException)
        //     {
        //         if (input == string.Empty) return 0;
        //         AlertUser("Please enter numerical values, setting entered value to 0", "Error");
        //         return 0;
        //     }
        // }

        public int ToIntAndNonNegative(string input)
        {
            if (int.TryParse(input, out var result) && result >= 0) return result;

            var output = string.IsNullOrEmpty(input) ? "blank" : input;

            AlertUser($"Please enter a positive number: {output} is invalid");

            return 0;
        }

        private static void AlertUser(string text, string caption = null)
        {
            MessageBox.Show(text, caption);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDollarCoins.Text = string.Empty;
            txtHalfDollars.Text = string.Empty;
            txtQuarters.Text = string.Empty;
            txtDimes.Text = string.Empty;
            txtNickles.Text = string.Empty;
            txtPennies.Text = string.Empty;
            txtHundreds.Text = string.Empty;
            txtFiftys.Text = string.Empty;
            txtTwenties.Text = string.Empty;
            txtTens.Text = string.Empty;
            txtFives.Text = string.Empty;
            txtOnes.Text = string.Empty;
            txtTotal.Text = string.Empty;
            btnBillAmounts.Enabled = false;
            _moneyAmounts.Clear();
        }

        private void btnBillAmounts_Click(object sender, EventArgs e)
        {
            AlertUser(_billHandler.BillAmountsForDrop());
        }
    }
}
