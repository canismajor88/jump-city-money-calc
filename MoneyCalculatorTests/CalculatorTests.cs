﻿
using WindowsFormsApp2;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MoneyCalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private double _registerTotal = 0;//amount register is supposed to be at for drop
        [Test]
        public void TestAllZeros()
        {
            _registerTotal = 0;
            var moneyAmounts = TestHelper.BuildMoneyAmounts(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,_registerTotal);
            var sut = new Calculator(moneyAmounts);
            var expected = _registerTotal;
            var actual = sut.GetDropTotal();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAllOnes()
        {
            _registerTotal = 187.91;
            var moneyAmounts = TestHelper.BuildMoneyAmounts(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,_registerTotal);
            var sut = new Calculator(moneyAmounts);
            var expected = _registerTotal;
            var actual = sut.GetDropTotal();
            Assert.AreEqual(expected, actual);
        }
    }
}