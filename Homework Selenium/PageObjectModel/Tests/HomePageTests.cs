using Homework_Selenium.PageObjectModel.Pages;
using Homework_Selenium.PageObjectModel.Pages.Apperal;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_Selenium.PageObjectModel.Tests
{
    class HomePageTests : BaseTest
    {

        [Test]
        public void VerifyHomePageLoaded()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            Assert.IsTrue(homePage.IsTitleCorrect());
        }

        [Test]
        public void RandomApparelPage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            Wait.ElementToBeClickable(driver, By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/a[2]"));
            homePage.NavigateToRandomApparel();
            Thread.Sleep(5000);
        }
       
    }
}
