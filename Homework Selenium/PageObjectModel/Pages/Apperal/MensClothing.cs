using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Selenium.PageObjectModel.Pages.Apperal
{
    class MensClothing : BasePage
    {
        private static string expectedPageTitle = "Men's Clothing";

        public MensClothing(IWebDriver webDriver) : base(webDriver)
        {

        }

        public bool isMensClothingTitleCorrect()
        {
            return this.webDriver.FindElement(PageTitle).Text.Equals(expectedPageTitle);
        }
    }
}
