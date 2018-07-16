using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    class Program
    {
        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("www.test.com");
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void Execute()
        {

            // Get Text 

            String TypedText = driver.FindElement(By.Id("test")).GetAttribute("value");
            Console.WriteLine("Value from the textbox is" + TypedText);

            // Select Drop Down Menu DDL

            var option = driver.FindElement(By.Id("test"));
            var SelectElement = new SelectElement(option);
            SelectElement.SelectByText("Basildon");

            // Hover and Click 

            Actions action = new Actions(driver);
            IWebElement element = driver.FindElement(By.Id("test"));
            action.MoveToElement(element).Build().Perform();
            driver.FindElement(By.Id("test")).Click();

            // OR

            Actions action5 = new Actions(driver);
            action5.MoveToElement(driver.FindElement(By.Id("vacancy"))).Click().Build().Perform();
            string value = driver.FindElement(By.Name("contract")).GetAttribute("contracts");


            // Double Click

            Actions action1 = new Actions(driver);
            IWebElement element1 = driver.FindElement(By.Id("test"));
            action1.DoubleClick(element1).Build().Perform();

            // Right click

            Actions action2 = new Actions(driver);
            IWebElement element2 = driver.FindElement(By.Id("test"));
            action2.ContextClick(element2).Build().Perform();

            //Scroll Down Window 

            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[4]/div/d")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scroll(0, 290);");

            Console.WriteLine("Scrolled down");
            js.ExecuteScript("scroll(290, 0);");
            Console.WriteLine("Scrolled up");

            // Wait /Sleep

            System.Threading.Thread.Sleep(2000);

            // clear text box 

            driver.FindElement(By.Name("test")).Clear();

            //  Send text/ keys

            driver.FindElement(By.Name("test")).SendKeys("henry");

            // Click

            driver.FindElement(By.Name("test")).Click();

            // Verify Element displayed

            IWebElement element8 = driver.FindElement(By.Name("test"));
            Console.WriteLine(element8.Displayed);
            Console.Read();

            Assert.IsTrue(driver.FindElement(By.Id("test")).Displayed);

            //Assert checkbox ticked 

            try
            {
                Assert.IsTrue(driver.FindElement(By.Id("test")).Selected);
                Console.Write("Checkbox selected");
            }
            catch (Exception e)
            {

                Console.Write(e);
            }

            // Assert Are Equal to

            Assert.AreEqual("google", driver.Title);
            Console.WriteLine("Title pass");

            // Assert page source

            String HtmlPage = driver.PageSource;

            String Hmtpage = "BBC";
            try
            {
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains(Hmtpage));
            }
            catch (Exception e)
            {

                Console.Write(e);
            }

            // Assert image displayed 

            Assert.IsTrue(driver.FindElement(By.Name("test")).Displayed);

            // Assert is False

            Assert.IsFalse(driver.FindElement(By.Name("test")).Selected);

            //Page Objects 

            //public IWebElement usernameTextBox => _driver.FindElement(By.Id("test"));

            // Refresh page

            driver.Navigate().Refresh();

            // Navigate forward/ backwards

            driver.Navigate().Back();

            // Accept alert

            // if else

            String password = "123";

            if (password == "123")
            {
                Console.WriteLine("passwod correct");
            }

            // Switch Statement

            int myNumber = 5;
            switch (myNumber)
            {
                case 1:
                    Console.WriteLine("the number is 1");
                    break;
                case 2:
                    Console.WriteLine("the number is 2");
                    break;
                case 3:
                    Console.WriteLine("the number is 2");
                    break;
                default:
                    Console.WriteLine("number unknown");
                    break;
            }

            //Foreach loop

            var price = driver.FindElements(By.Id("productprices"));
            foreach (var p in price) 
            {
                Console.WriteLine(p.Text);
            }

           // Order by 
            var myOrdredList = from p in price
                               orderby price ascending //or descending
                               select p;

            //OR

            var sortedList = price.OrderBy(p => p.Text);
           // foreach (IWebElement element6 in sortedList)
           foreach (var p in price)
            {
                Console.WriteLine(p.Text);
            }
        }
    }
}
