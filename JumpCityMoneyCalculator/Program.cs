using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var moneyAmount = new MoneyAmounts();
            var calculator = new Calculator(moneyAmount);
            var billHandler = new BillHandler(moneyAmount);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new JumpCityMoneyCalculator.JumpCityMoneyCalculator(moneyAmount,calculator,billHandler));
        }
    }
}