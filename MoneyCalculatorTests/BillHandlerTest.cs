using System;
using WindowsFormsApp2;
using NUnit.Framework;

namespace MoneyCalculatorTests
{
    [TestFixture]
    public class BillHandlerTest
    {
       private double _registerTotal = 0;//amount register is supposed to be at for drop
        [Test]
        public void CheckRegisterStateRegisterUnderTargetAmountTest()
        {
             _registerTotal = 37.91;
            var moneyAmounts = TestHelper.BuildMoneyAmounts(1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1,_registerTotal);
            
            var sut = new BillHandler(moneyAmounts);
            var expected = "register has less than " + moneyAmounts.targetRegisterAmount + " dollars, the register must be fixed.";
            string actual = sut.BillAmountsForDrop();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CheckRegisterStateRegisterTooManyLargeBillsTest()
        {
            _registerTotal = 161.91;
            var moneyAmounts = TestHelper.BuildMoneyAmounts(1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0,_registerTotal);
            
            var sut = new BillHandler(moneyAmounts);
            var expected = "go to safe and break large bills and then use form again.";
            var actual = sut.BillAmountsForDrop();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BillAmountsForDroTest()
        {
            _registerTotal = 114.18;
            var moneyAmounts = TestHelper.BuildMoneyAmounts(0, 0, 20, 64, 40, 78, 1, 1, 0, 2, 9, 35, _registerTotal);

            var sut = new BillHandler(moneyAmounts);
            var expected = "Take Out 0 hundreds, 0 fifties, 0 twenties, 1 tens, 0 fives,and 4 ones.";
            var actual = sut.BillAmountsForDrop();
            Assert.AreEqual(expected, actual);
        }
    }
}