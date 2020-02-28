using System;
using System.Windows.Forms;
using RegisterDropCalculator;
using Unity;

namespace WindowsFormsApp2
{
    internal static class Program
    {
        private static readonly UnityContainer Container = new UnityContainer();


        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfigureContainer();
            Application.Run(Container.Resolve<JumpCityMoneyCalculator.JumpCityMoneyCalculator>());
        }

        private static void ConfigureContainer()
        {
            //new instance gets created each time 
            Container.RegisterType<AbstractCalculator,Calculator>();
            Container.RegisterType<IBillHandler, BillHandler>();
            //create only one instance of money amounts
            Container.RegisterSingleton<MoneyAmounts>();
        }
    }
}