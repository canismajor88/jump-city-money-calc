namespace WindowsFormsApp2
{
    public class BillHandler
    {
        private readonly MoneyAmounts _moneyAmounts;
        private int _truncatedDropTotal;
        private string _outputText="";

        public BillHandler(MoneyAmounts moneyAmounts)
        {
            _moneyAmounts = moneyAmounts;
            _truncatedDropTotal = (int) _moneyAmounts.TotalAmount;
        }


        private bool RegisterStateCheck()
        {
            var smallBillAmount = 0;
            smallBillAmount = _moneyAmounts.TwentiesAmount * 20 + _moneyAmounts.FivesAmount * 5 +
                              _moneyAmounts.OnesAmount;

            if (_moneyAmounts.TotalAmount < _moneyAmounts.targetRegisterAmount)
            {
                _outputText="register has less than $100 dollars, the register must be fixed.";

                return false;
            }

            if (smallBillAmount < _moneyAmounts.targetRegisterAmount)
            {
                _outputText="go to safe and break large bills and then use form again.";
                return false;
            }

            return true;
        }

        private int BillAmountsProcessor(int billAmount, int billWorth)
        {
            int i;
            for (i = 0; i != billAmount && _truncatedDropTotal > _moneyAmounts.targetRegisterAmount; i++)
                _truncatedDropTotal -= billWorth;
            //put the bill back
            if (_truncatedDropTotal < _moneyAmounts.targetRegisterAmount)
            {
                i--;
                _truncatedDropTotal += billWorth;
            }

            return i;
        }

        public string BillAmountsForDrop()
        {
            if (RegisterStateCheck())
            {
                _outputText = "Take Out " + BillAmountsProcessor(_moneyAmounts.HundredsAmount, 100) + " hundreds, "
                             + BillAmountsProcessor(_moneyAmounts.FiftiesAmount, 50) + " fifties, " +
                             BillAmountsProcessor(_moneyAmounts.TwentiesAmount, 20) + " twenties, "
                             + BillAmountsProcessor(_moneyAmounts.TensAmount, 10) + " tens, " +
                             BillAmountsProcessor(_moneyAmounts.FiftiesAmount, 5) + " fives,and " +
                             BillAmountsProcessor(_moneyAmounts.OnesAmount, 1) + " ones.";

            }
            return _outputText;
        }
    }
}