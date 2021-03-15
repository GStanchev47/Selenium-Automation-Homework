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
using Homework_Selenium;

namespace Homework_Selenium
{
    [TestFixture]
    public class AdvancedTests : BaseTest
    {
        [Test]
       public void Task2Test()
        {
            driver.Navigate().GoToUrl("https://demo.cs-cart.com");

            Actions actions = new Actions(driver);

            Wait.ElementToBeClickable(driver,By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/a[2]"));   // Waiting for the Apparel button to be clickable

            actions.MoveToElement(driver.FindElement(By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/a[2]")));  //Hovering over the Apparel button
            actions.Build().Perform();

            IList<IWebElement> elements = driver.FindElements(By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/div/ul/li/a"));  // Creating list of all apparel's elements

            Random random = new Random();
            int randomIndex = random.Next(elements.Count);

            elements[randomIndex].Click();  // Clicking random Apparel Element

            elements = driver.FindElements(By.XPath("//ul[@id=\"ranges_31_10\"]/li/label/input")); //Assigning all the brand checkboxes to the list of elements 

            randomIndex = random.Next(elements.Count);

            elements[randomIndex].Click();  //Clicking on random Brand checkbox

            Wait.InvisibilityOfElement(driver, By.Id("ajax_loading_box")); //Waiting for the loading animation to end

            elements = driver.FindElements(By.XPath("//div[@class='ty-grid-list__image']"));  //Assiging all the image elements to the list of elements

            if (elements.Count == 1)
            {
                driver.FindElement(By.XPath("//*[@id=\"product_filters_31\"]/div/div[3]/a")).Click();  //if the result is only one, click the reset button
                Wait.InvisibilityOfElement(driver, By.Id("ajax_loading_box")); //Waiting for the loading animation to end
            }

            Wait.ElementToBeClickable(driver, By.Id("sw_elm_sort_fields")); //Waiting for the Sort button to be clickable

           
            Wait.InvisibilityOfElement(driver, By.XPath("//button[@type='button' and contains(., \"product\")]")); //Waiting for the Pop-up message to dissapear


            driver.FindElement(By.Id("sw_elm_sort_fields")).Click();  //Clicking the Sort button

            elements = driver.FindElements(By.XPath("//*[@id=\"elm_sort_fields\"]/li"));

            Wait.ElementToBeClickable(driver, By.XPath("//ul[@id=\"elm_sort_fields\"]/li"));

            elements[elements.Count - 1].Click();

            string lowest = driver.FindElement(By.XPath("//*[@id=\"slider_31_1_left\"]")).GetAttribute("value");

            int lowestPrice = 1 + Int32.Parse(lowest);

            driver.FindElement(By.Id("slider_31_1_right")).Clear();
            driver.FindElement(By.Id("slider_31_1_right")).SendKeys("" + lowestPrice);

            Wait.VisibilityOfElement(driver, By.Id("ajax_loading_box"));
            Wait.InvisibilityOfElement(driver, By.Id("ajax_loading_box"));

            actions.MoveToElement(driver.FindElement(By.XPath("//*[@class=\'ty-grid-list__image\']")));
            

            Wait.ElementToBeClickable(driver, By.XPath("//*[@id=\"pagination_contents\"]/div[2]/div[1]/div/form/div[5]/div/a"));

            driver.FindElement(By.XPath("//*[@id=\"pagination_contents\"]/div[2]/div[1]/div/form/div[5]/div/a")).Click();

            Wait.VisibilityOfElement(driver, By.XPath("//*[@id=\"product_main_info_form_ajax\"]/form/div[2]/h1/a/bdi"));
            string itemSelected = driver.FindElement(By.XPath("//*[@id=\"product_main_info_form_ajax\"]/form/div[2]/h1/a/bdi")).Text;

            Wait.ElementToBeClickable(driver, By.XPath("//button[@type='submit' and contains(., \"cart\")]"));
            driver.FindElement(By.XPath("//button[@type='submit' and contains(., \"cart\")]")).Click();

            driver.FindElement(By.XPath("//*[@class='cm-notification-close close']")).Click();

            driver.FindElement(By.Id("sw_dropdown_8")).Click();

            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id=\"dropdown_8\"]/div/div[1]/ul/li/div[2]/a")).Text, itemSelected);

            Thread.Sleep(2000);

        }


        [Test]
        public void Task3()
        {
            driver.Navigate().GoToUrl("https://demo.cs-cart.com");

            Wait.ElementToBeClickable(driver, By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/a[2]"));

            IWebElement footer = driver.FindElement(By.XPath("//*[@id=\"tygh_footer\"]/div/div[2]/div"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", footer);

            driver.FindElement(By.LinkText("Reviews")).Click();

            driver.FindElement(By.XPath("//*[@id=\"content_discussion\"]/a")).Click();

            Wait.VisibilityOfElement(driver, By.Id("dsc_name_0"));

            driver.FindElement(By.Id("dsc_name_0")).Clear();
            driver.FindElement(By.Id("dsc_name_0")).SendKeys("Galin Stanchev");

            IList<IWebElement> elements = driver.FindElements(By.XPath("//label[@class='ty-rating__label']"));

            Random random = new Random();

            int randomIndex = random.Next(elements.Count);

            elements[randomIndex].Click();

            driver.FindElement(By.Id("dsc_message_0")).Clear();

            if (randomIndex == 0)
            {
                driver.FindElement(By.Id("dsc_message_0")).SendKeys("Amazing Site ! Keep up the good work! ");
            }

            else if (randomIndex == 1)
            {
                driver.FindElement(By.Id("dsc_message_0")).SendKeys("Good site :) !");
            }

            else if (randomIndex == 2)
            {
                driver.FindElement(By.Id("dsc_message_0")).SendKeys("It has its good and bad sides.");
            }

            else if (randomIndex == 3)
            {
                driver.FindElement(By.Id("dsc_message_0")).SendKeys("The reason I am giving " + randomIndex + " stars is because the site has a lot of room of improvement");
            }

            else if (randomIndex == 4)
            {
                driver.FindElement(By.Id("dsc_message_0")).SendKeys("Awfull. A lot of bugs. Do you even have QA's doing automated tests on that?");
            }

            IWebElement frame = driver.FindElement(By.TagName("iframe"));
           
            driver.SwitchTo().Frame(frame);

            driver.FindElement(By.XPath("//*[@id=\"recaptcha-anchor\"]/div[1]")).Click();

            Wait.InvisibilityOfElement(driver, By.XPath("//*[@id=\"recaptcha-anchor\"]/div[3]"));

            driver.SwitchTo().ParentFrame();

            driver.FindElement(By.XPath("//*[@id=\"add_post_form_0\"]/div[2]/button")).Click();

            

            Thread.Sleep(5000);

        }


        [Test]
        public void Task4()
        {
            driver.Navigate().GoToUrl("https://demo.cs-cart.com");

            Wait.ElementToBeClickable(driver, By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/a[2]"));

            driver.FindElement(By.XPath("//*[@id=\"currencies_2\"]/div[1]/a[3]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/a[2]")).Click();

            Wait.VisibilityOfElement(driver, By.XPath("//*[@id=\"content_31_1\"]/p/bdi[1]/span"));

            string currency = driver.FindElement(By.XPath("//*[@id=\"content_31_1\"]/p/bdi[1]/span")).Text;

            Assert.AreEqual("£", currency);

            driver.FindElement(By.XPath("//*[@id=\"currencies_2\"]/div[1]/a[1]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"text_links_3\"]/li[1]/a")).Click();


            IWebElement blog = driver.FindElement(By.XPath("//*[@id=\"pagination_contents\"]/div[3]/a[1]/h2"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", blog);
            

            Thread.Sleep(5000);
        }


        [Test]
        public void Task5()
        {
            driver.Navigate().GoToUrl("https://demo.cs-cart.com");

            Wait.ElementToBeClickable(driver, By.XPath("//*[@id=\"tygh_main_container\"]/div[2]/div/div[2]/div/div/ul/li[4]/a[2]"));

            driver.FindElement(By.XPath("//*[@id=\"bp_bottom_panel\"]/div[3]/a/span")).Click();

            List<string> tabs = driver.WindowHandles.ToList();

            driver.SwitchTo().Window(tabs[1]);

            driver.FindElement(By.XPath("//*[@id=\"navbar_64\"]/ul/li[3]/a")).Click();

            driver.FindElement(By.XPath("//*[@id=\"success_stories_main\"]/div[1]/div/div[1]/div[2]/a/h3/i")).Click();

            tabs = driver.WindowHandles.ToList();

            driver.SwitchTo().Window(tabs[2]);

            driver.Close();

            driver.SwitchTo().Window(tabs[1]);

            driver.Close();

            driver.SwitchTo().Window(tabs[0]);

            Assert.IsTrue(driver.Url.Contains("https://demo.cs-cart.com/"));

            Thread.Sleep(5000);
        }


        [TearDown]
        public void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotFileName = TestContext.CurrentContext.Test.FullName;
                screenshot.SaveAsFile(@"C:\Users\Axl\source\repos\Selenium-Automation-Homework-main\" + screenshotFileName + ".jpeg");
            }
        }

    }
}
