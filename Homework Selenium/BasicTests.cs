using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Homework_Selenium
{
	[TestFixture]
	public class BasicTests : BaseTest
	{

		[Test]
		[TestCase("tomsmith", "SuperSecretPassword!", "You logged into a secure area!\r\n×")]
		[TestCase("jivko", "SuperSecretPassword!", "Your username is invalid!\r\n×")]
		[TestCase("tomsmith", "Azis", "Your password is invalid!\r\n×")]
		[TestCase("galin", "notTheRightPassword!", "Your username is invalid!\r\n×")]


		public void LoginCredentialTest(string username, string password, string expected)
		{
			
			driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

			Assert.IsTrue(driver.Url.Contains("https://the-internet.herokuapp.com/login"));

			driver.FindElement(By.Id("username")).Clear();
			driver.FindElement(By.Id("username")).SendKeys(username);

			driver.FindElement(By.Id("password")).Clear();
			driver.FindElement(By.Id("password")).SendKeys(password);

			driver.FindElement(By.ClassName("radius")).Click();

			string actualResult = driver.FindElement(By.Id("flash")).Text;

			Assert.AreEqual(expected, actualResult);

		}

		[Test]
		[TestCase("tomsmith", "SuperSecretPassword!", "You logged out of the secure area!\r\n×")]
		public void LoginLogout(string username, string password, string expected)
		{
			driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

			Assert.IsTrue(driver.Url.Contains("https://the-internet.herokuapp.com/login"));

			driver.FindElement(By.Id("username")).Clear();
			driver.FindElement(By.Id("username")).SendKeys(username);

			driver.FindElement(By.Id("password")).Clear();
			driver.FindElement(By.Id("password")).SendKeys(password);

			driver.FindElement(By.ClassName("radius")).Click();

			Thread.Sleep(2000);

			driver.FindElement(By.XPath("//*[@id=\"content\"]/div/a")).Click();

			string actualResult = driver.FindElement(By.Id("flash")).Text;

			Assert.AreEqual(expected, actualResult);


		}

		[Test]
		public void DropDownTest()
		{
			driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html");
			SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("select-demo")));
			Random random = new Random();
			int randomIndex = random.Next(dropdown.Options.Count);
			dropdown.SelectByIndex(randomIndex);
			
			string selectedDropDownValue = dropdown.SelectedOption.Text;

			Assert.AreEqual(selectedDropDownValue, dropdown.SelectedOption.Text);

			string dropDownContent = dropdown.Options.ToString();

			Console.WriteLine(dropDownContent);

			driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html");
			SelectElement multidropdown = new SelectElement(driver.FindElement(By.Id("multi-select")));

			multidropdown.SelectByValue("New York");
			multidropdown.SelectByValue("New Jersey");
			multidropdown.SelectByValue("Ohio");
			

			driver.FindElement(By.Id("printMe")).Click();

			for (int i = 0; i < multidropdown.Options.Count; i++)
			{
				Console.WriteLine(multidropdown.Options[i].Text);
			}

		}

		[Test]
		public void RadioButtonTest()
		{
			driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-radiobutton-demo.html");

			IList<IWebElement> elements = driver.FindElements(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/div[2]/label/input"));

			Random random = new Random();
			int randomIndex = random.Next(elements.Count);

			elements[randomIndex].Click();

			

			for (int i = 0; i < elements.Count; i++)
			{
				Console.WriteLine(elements[i].GetAttribute("value"));

				if (elements[i].Selected)
				{					
					Assert.AreEqual(elements[randomIndex].GetAttribute("value"), elements[i].GetAttribute("value"));					
				}
			}


		}

		[Test]
		public void CheckBoxTest()
		{

			driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-checkbox-demo.html");

			IList<IWebElement> checkboxes = driver.FindElements(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/div[contains(@class,'checkbox')]/label"));

			Random random = new Random();
			int randomIndex = random.Next(checkboxes.Count);

			checkboxes[randomIndex].Click();

			for (int i = 0; i < checkboxes.Count; i++)
			{
				Console.WriteLine(checkboxes[i].Text);

				if (checkboxes[i].FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/div[1]/label/input")).Selected)
				{
					Assert.AreEqual(checkboxes[i].Text, checkboxes[randomIndex].Text);
				}
				
			
			}

			Thread.Sleep(2000);
		}



		[Test]
		public void SelectAllCheckboxesTest()
		{

			driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-checkbox-demo.html");

			IList<IWebElement> checkboxes = driver.FindElements(By.ClassName("cb1-element"));


			for (int i = 0; i < checkboxes.Count; i++)
			{
				if (!checkboxes[i].Selected)
				{
					checkboxes[i].Click();
					Assert.IsTrue(checkboxes[i].Selected);
				}
			}

		}


		[Test]
		public void HoverTest()
		{

			driver.Navigate().GoToUrl("https://the-internet.herokuapp.com");


			driver.FindElement(By.LinkText("JQuery UI Menus")).Click();

			Actions action = new Actions(driver);

			action.MoveToElement(driver.FindElement(By.Id("ui-id-3")));
			action.Build().Perform();

			Thread.Sleep(1000);

			action.MoveToElement(driver.FindElement(By.Id("ui-id-4")));
			action.Build().Perform();

			Thread.Sleep(1000);

			driver.FindElement(By.Id("ui-id-6")).Click();
			

		}

		[Test]
		public void FormFill()
		{
			driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

			driver.FindElement(By.Id("firstName")).Clear();
			driver.FindElement(By.Id("firstName")).SendKeys("Galin");

			driver.FindElement(By.Id("lastName")).Clear();
			driver.FindElement(By.Id("lastName")).SendKeys("Stanchev");

			driver.FindElement(By.Id("userEmail")).Clear();
			driver.FindElement(By.Id("userEmail")).SendKeys("galin.stanchev@mentormate.com");


			IList<IWebElement> elements = driver.FindElements(By.Id("genterWrapper"));

			Random random = new Random();
			int randomIndex = random.Next(elements.Count);

			elements[randomIndex].Click();

			driver.FindElement(By.Id("userNumber")).Clear();
			driver.FindElement(By.Id("userNumber")).SendKeys("0885202493");

			

			Thread.Sleep(2000);

			driver.FindElement(By.Id("subjectsInput")).Clear();
			driver.FindElement(By.Id("subjectsInput")).SendKeys("Subject47");

	

			IList<IWebElement> checkboxes = driver.FindElements(By.Id("hobbiesWrapper"));

			Random random2 = new Random();
			int randomIndex2 = random2.Next(checkboxes.Count);

			checkboxes[randomIndex2].Click();



			driver.FindElement(By.Id("currentAddress")).Clear();
			driver.FindElement(By.Id("currentAddress")).SendKeys("Haskovo");

			IWebElement dropdown = driver.FindElement(By.Id("state"));
			dropdown.Click();

			Actions keyDown = new Actions(driver);
			keyDown.SendKeys(Keys.Down).Perform();

			keyDown.SendKeys(Keys.Enter).Perform();

			dropdown = driver.FindElement(By.Id("city"));

			dropdown.Click();

			
			keyDown.SendKeys(Keys.Down).Perform();

			keyDown.SendKeys(Keys.Enter).Perform();


			Thread.Sleep(2000);

			driver.FindElement(By.Id("submit")).Click();

			Thread.Sleep(2000);
		}

	

	}
}
