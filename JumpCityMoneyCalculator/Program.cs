using System;
using System.Windows.Forms;
using RegisterDropCalculator;
using Unity;

namespace WindowsFormsApp2
{
    internal static class Program
    {
        private static readonly UnityContainer Container = new UnityContainer();

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfigureServices();
            Application.Run(Container.Resolve<JumpCityMoneyCalculator.JumpCityMoneyCalculator>());
        }

        private static void ConfigureServices()
        {
            Container.RegisterType<Calculator>();
            Container.RegisterType<BillHandler>();
            Container.RegisterType<MoneyAmounts>();
        }
    }
}
