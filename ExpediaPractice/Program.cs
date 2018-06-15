using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpediaPractice
{
    public class Program
    {

        IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
        {
        }
        [SetUp]
        public void Initialize()

        {
            driver.Navigate().GoToUrl("https://www.expedia.co.uk/");
            driver.Manage().Window.Maximize();
            Console.WriteLine("Navigate to Url");
        }
        [Test]
        public void Executetest()

        {
            //Origin
            driver.FindElement(By.Id("package-origin-hp-package")).Clear();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("package-origin-hp-package")).SendKeys("London, England, UK (LHR-Heathrow)");
            Console.WriteLine("Typed Origin");

            // Get value from textbox ie Origin text box

            IWebElement outPutvalue = driver.FindElement(By.Id("package-origin-hp-package"));
            string currencyValue = outPutvalue.GetAttribute("value");
            Console.WriteLine("Value from textbox is: " + currencyValue);


            //Destination
            driver.FindElement(By.Id("package-destination-hp-package")).Clear();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("package-destination-hp-package")).SendKeys("Newark, New Jersey, United States of America");
            Console.WriteLine("Typed destination");

            // Departing
            driver.FindElement(By.Id("package-departing-hp-package")).Clear();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("package-departing-hp-package")).SendKeys("12/06/2018");
            Console.WriteLine("Typed Departing date");
            //Returning
            driver.FindElement(By.Id("package-returning-hp-package")).Clear();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("package-returning-hp-package")).SendKeys("16/06/2018");
            Console.WriteLine("Typed returning date");

            // Select rooms DDL
            var option = driver.FindElement(By.Id("package-rooms-hp-package"));
            var SelectElement = new SelectElement(option);
            System.Threading.Thread.Sleep(3000);
            SelectElement.SelectByText("1");
            Console.WriteLine("Selected 1 room");

            //Select Adult DDL

            var option1 = driver.FindElement(By.Id("package-1-adults-hp-package"));
            var SelectElement1 = new SelectElement(option1);
            System.Threading.Thread.Sleep(3000);
            SelectElement1.SelectByText("2");
            Console.WriteLine("Selected 2 Adults");

            //Select Children DDL

            var option3 = driver.FindElement(By.Id("package-1-children-hp-package"));
            var SelectElement3 = new SelectElement(option3);
            System.Threading.Thread.Sleep(3000);
            SelectElement3.SelectByText("2");
            Console.WriteLine("Selected 2 Children");

            //Select Child 1 Age DDL

            var Henry  = driver.FindElement(By.Id("package-1-age-select-1-hp-package"));
            var SelectHenry = new SelectElement(Henry); 
            System.Threading.Thread.Sleep(3000);
            SelectHenry.SelectByText("6");
            Console.WriteLine("Selected Children 1 as 6 years old");

            //Select Child 2 Age DDL

            var option5 = driver.FindElement(By.Id("package-1-age-select-2-hp-package"));
            var SelectElement5 = new SelectElement(option5);
            System.Threading.Thread.Sleep(3000);
            SelectElement5.SelectByText("1");
            Console.WriteLine("Selected Children 2 as 1 years old");

            //Select direct flight checkbox/ I need a hotel 
            driver.FindElement(By.Id("packageDirectFlight-hp-package")).Click();
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Ticked direct flight checkbox");

            //Select I need a hotel checkbox
            driver.FindElement(By.Id("partialHotelBooking-hp-package")).Click();
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Ticked i only need a hotel for part stay checkbox");

            //Assert hotel checkbox ticked
            try
            {
                Assert.IsTrue(driver.FindElement(By.Id("partialHotelBooking-hp-package")).Selected);
                Console.WriteLine("Assertion: I only need a hotel for part stay Checkbox selected");
            }
            catch (Exception e)
            {

                Console.Write(e);
            }

            //Assert Nector logo imagine displayed 
            try
            {
                Assert.IsTrue(driver.FindElement(By.ClassName("wizard-bpg-logo-wrapper")).Displayed);
                Console.WriteLine("Assertion: Nector image displayed");
            }
            catch (Exception e)
            {

                Console.Write(e);
            }

            //Verify element present (Airline rules link)

            IWebElement element = driver.FindElement(By.ClassName("cols-nested"));
            Console.WriteLine("Airline age rules displayed");


            // Assert page source 

            String html_page = "Advanced options";
            try
            {
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains(html_page));
                Console.WriteLine("Assertion: Page source pass");
            }
            catch (Exception e)
            {

                Console.Write(e);
            }

            //Select preferred class

            var option6 = driver.FindElement(By.Id("package-advanced-preferred-class-hp-package"));
            var SelectElement6 = new SelectElement(option6);
            System.Threading.Thread.Sleep(3000);
            SelectElement6.SelectByText("First class");
            Console.WriteLine("Selected First class as preferred class");

            // Click search button
            driver.FindElement(By.Id("search-button-hp-package")).Click();
            Console.WriteLine("Clicked searched button");






        }


    }

    }



