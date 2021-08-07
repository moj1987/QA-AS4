using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace ContactsWebAppTestWithSelenium
{
    public class ContactSystemTest
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void allFieldsrequiredinputContactDatasubmitCreatesHyperlink()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(900, 755);
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Click();
            {
                var element = driver.FindElement(By.Id("name"));
                Actions builder = new Actions(driver);
                builder.DoubleClick(element).Perform();
            }
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Click();
            {
                var element = driver.FindElement(By.Id("name"));
                Actions builder = new Actions(driver);
                builder.DoubleClick(element).Perform();
            }
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Name("lastName")).Click();
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Name("city")).Click();
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Name("province")).Click();
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Name("postalCode")).Click();
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G2");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Name("phone")).Click();
            driver.FindElement(By.Name("phone")).SendKeys("2262262266");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys("moj@moj.com");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys("Hi");
            driver.FindElement(By.CssSelector("div > input")).Click();
            Assert.That(driver.FindElement(By.LinkText("Moj Abb")).Text, Is.EqualTo("Moj Abb"));
        }
    }
}