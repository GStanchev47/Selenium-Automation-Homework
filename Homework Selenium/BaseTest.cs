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
    public class BaseTest
    {
        public IWebDriver driver;

        [SetUp]
        public void SetDriver()
        {
            driver = new ChromeDriver(@"C:\Users\Axl\source\repos\Selenium-Automation-Homework-main\Drivers");
            driver.Manage().Window.Maximize();
        }


        [TearDown]
        public void QuitDriver()
        {
            driver.Dispose();
        }
    }
}
