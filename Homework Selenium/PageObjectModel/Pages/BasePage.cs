using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Selenium.PageObjectModel.Pages
{
    class BasePage
    {

        protected static readonly By PageTitle = By.XPath("//h1");

        protected IWebDriver webDriver { get; }

        public BasePage(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        
    }
}
