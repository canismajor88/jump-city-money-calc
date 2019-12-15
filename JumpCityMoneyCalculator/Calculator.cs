﻿namespace WindowsFormsApp2
{
    public class Calculator
    {
        private MoneyAmounts _moneyAmounts = new MoneyAmounts();

        public Calculator( MoneyAmounts moneyAmounts)
        {
            _moneyAmounts = moneyAmounts;

        }

        public double GetDropTotal()
        {
            double coinAmount = _moneyAmounts.DollarCoinAmount + (_moneyAmounts.HalfDollarAmount * .5) +
                                (_moneyAmounts.QuartersAmount * .25) + (_moneyAmounts.DimesAmount * .1) +
                                (_moneyAmounts.NicklesAmount * .05) + (_moneyAmounts.PenniesAmount * .01);

            double dollarAmount = (_moneyAmounts.HundredsAmount * 100) + (_moneyAmounts.FiftiesAmount * 50) +
                                  (_moneyAmounts.TwentiesAmount * 20) + (_moneyAmounts.FivesAmount * 5) +
                                  _moneyAmounts.OnesAmount+(_moneyAmounts.TensAmount*10);
            double total = coinAmount + dollarAmount;
            _moneyAmounts.TotalAmount = total;

            return total;
        }



    }
}
