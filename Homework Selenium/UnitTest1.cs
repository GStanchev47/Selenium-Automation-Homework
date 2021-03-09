using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Homework_Selenium
{
	[TestFixture]
	public class UnitTest1
	{
		IWebDriver driver;

		[SetUp]

		public void SetDriver()
		{
			driver = new ChromeDriver(@"C:\Users\Axl\source\repos\Homework Selenium\Drivers");
			driver.Manage().Window.Maximize();
		}


		[Ignore("just to try ignore")]
		[Test]		
		[Category("SimpleTest")]
		public void OpenGoogle()
		{
			driver.Navigate().GoToUrl("https://google.com");
		}

		[Test]
		[Category("SimpleTest")]
		public void OpenAbv()
		{
			driver.Navigate().GoToUrl("https://www.abv.bg");

			Assert.AreEqual("https://www.abv.bg/", driver.Url);

		}

		[Test]
		[Category("SimpleTest")]
		public void OpenYouTube()
		{
			driver.Navigate().GoToUrl("https://www.youtube.com");
		}

		[Test]
		[Category("SimpleTest")]
		public void OpenGoogleTranslate ()
		{
			driver.Navigate().GoToUrl("https://translate.google.com");
		}

		[Test]
		[Category("SimpleTest")]
		public void OpenMentorMate()
		{
			driver.Navigate().GoToUrl("https://www.mentormate.com");
		}


		[Test]
		[TestCase("https://www.google.bg")]
		[TestCase("https://www.youtube.com")]
		[TestCase("https://translate.google.com")]
		[TestCase("https://www.abv.bg")]
		[TestCase("https://mentormate.com/")]
		[Category("ParameterizedTests")]
		public void LoadWebPagesParameterized(string url)
		{
			driver.Navigate().GoToUrl(url);

			Assert.IsTrue(driver.Url.Contains(url));
		}


		[TearDown]
		public void QuitDriver()
		{
			driver.Dispose();
		}

	}
}