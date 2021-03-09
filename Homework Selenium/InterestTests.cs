using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Homework_Selenium
{
	[TestFixture]
	class InterestTests
	{
		[Test]
		[TestCase(-1, 0)]
		[TestCase(50, 3)]
		[TestCase(150, 5)]
		[TestCase(1150, 7)]
		[Category("ParameterizedTests")]
		[Category("EquivalencePartioning")]
		[Category("CalcInterestPercentage")]

		public void IsPercentageCorrect(int accountBalance, int expectedInterest)
		{
			var actualPercentage = CalcInterestPercentage(accountBalance);

			Assert.AreEqual(expectedInterest, actualPercentage);
		}

		[Test]
		[TestCaseSource("GetValues")]
		[Category("ParameterizedTests")]
		[Category("EquivalencePartioning")]
		[Category("CalcInterestPercentage")]
		public void IsPercentageCorrectTestCaseSource(int accountBalance, int expectedInterest)
		{
			var actualPercentage = CalcInterestPercentage(accountBalance);

			Assert.AreEqual(expectedInterest, actualPercentage);

		}

		[Test]
		[TestCaseSource("TestAllValues0To100TestCaseSource")]
		[Category("ParameterizedTests")]
		[Category("CalcInterestPercentage")]

		public void TestAllValues0To100(int accountBalance)
		{
			var actualInterest = CalcInterestPercentage(accountBalance);
			Assert.AreEqual(3, actualInterest);
		}

		private static IEnumerable TestAllValues0To100TestCaseSource
		{
			get
			{
				for (int i = 0; i < 100; i++)
				{
					yield return new TestCaseData(i);
				}
			}
		}

		private static IEnumerable GetValues
		{
			get
			{
				yield return new TestCaseData(-1000, 0);
				yield return new TestCaseData(80, 3);
				yield return new TestCaseData(300, 5);
				yield return new TestCaseData(3000, 7);
			}
		}

		[Category("CalcInterestPercentage")]
		private int CalcInterestPercentage(int accountBalance)
		{
			if (accountBalance >= 0 && accountBalance <= 100)
			{
				return 3;
			}
			else if (accountBalance > 100 && accountBalance < 1000)
			{
				return 5;
			}
			else if(accountBalance > 1000)
			{
				return 7;
			}

			return 0;
		}


		[Category("CalcInterestPercentage")]
		private double CalcInterest(int accountBalance, int interest)
		{
			var percentage = interest * 0.01;
			return accountBalance * percentage;
		}
	}
}
