﻿using System;
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

        [Test]
        public void clickingOnSearchTakesToSearchPageClickOnSearchButtonSearchPageShows()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 860);
            driver.FindElement(By.Id("js-show-all")).Click();
            {
                var elements = driver.FindElements(By.XPath("//div[contains(style,\'display: none       \')]"));
                Assert.True(elements.Count == 0);
            }
        }

        [Test]
        public void deleteButtonRemovesInputAllFieldsWithLabelAsStringNonExistant()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1020);
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G2");
            driver.FindElement(By.Name("phone")).SendKeys("2262262266");
            driver.FindElement(By.Name("email")).SendKeys("moj@moj.com");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys("Hi");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.LinkText("Moj Abb")).Click();
            driver.FindElement(By.Id("remove")).Click();
            driver.FindElement(By.Id("js-show-all")).Click();
            Assert.That(driver.FindElement(By.CssSelector(".contact-item")).Text, Is.Not.EqualTo("First name:Moj\\\\nLast name:Abb\\\\nAddress:Westwood\\\\nCity:Kitchener\\\\nProvince:ON\\\\nPostal Code:N2T2G2\\\\nPhone:2262262266\\\\nEmail:moj@moj.com\\\\nNotes:Hi"));
        }

        [Test]
        public void homeButtonGoesToIndexPageAllFieldsWithLabelAsStringGoesToIndexPage()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1020);
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G2");
            driver.FindElement(By.Name("phone")).SendKeys("2262262266");
            driver.FindElement(By.Name("email")).SendKeys("moj@moj.com");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys("Hi");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.LinkText("Moj Abb")).Click();
            driver.FindElement(By.Id("home")).Click();
            Assert.That(driver.FindElement(By.CssSelector("h3")).Text, Is.EqualTo("Add a new contact"));
        }

        [Test]
        public void savedDataEqualsInputAllFieldsWithLabelAsStringAllFieldsWithLabelAsString()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 1020);
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G2");
            driver.FindElement(By.Name("phone")).SendKeys("2262262266");
            driver.FindElement(By.Name("email")).SendKeys("moj@moj.com");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys("Hi");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.LinkText("Moj Abb")).Click();
            driver.FindElement(By.Id("home")).Click();
            driver.FindElement(By.Id("js-show-all")).Click();
            Assert.That(driver.FindElement(By.CssSelector(".contact-item")).Text, Is.EqualTo("First name:Moj\\\\nLast name:Abb\\\\nAddress:Westwood\\\\nCity:Kitchener\\\\nProvince:ON\\\\nPostal Code:N2T2G2\\\\nPhone:2262262266\\\\nEmail:moj@moj.com\\\\nNotes:Hi"));
        }

        [Test]
        public void hyperlinkTakesToNextPageClickOnNewContactRedirectToShowPage()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/");
            driver.Manage().Window.Size = new System.Drawing.Size(900, 755);
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G2");
            driver.FindElement(By.Name("phone")).SendKeys("2262262266");
            driver.FindElement(By.Name("email")).SendKeys("moj@moj.com");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys("Hi");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.LinkText("Moj Abb")).Click();
            Assert.That(driver.FindElement(By.CssSelector("h2")).Text, Is.EqualTo("Keep or delete contact"));
        }

        [Test]
        public void clickingOnNewTakesToInputDataPageClickOnNewButtonAddANewContactPageShows()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/");
            driver.Manage().Window.Size = new System.Drawing.Size(945, 860);
            driver.FindElement(By.Id("js-show-all")).Click();
            driver.FindElement(By.Id("js-add-new")).Click();
            Assert.That(driver.FindElement(By.CssSelector("h3")).Text, Is.EqualTo("Add a new contact"));
        }

        [Test]
        public void wrongEmailFormatNotSubmittedinputContactDataWithWrongEmailForamtsubmitDoesNotCreateHyperlink()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(900, 755);
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G2");
            driver.FindElement(By.Name("phone")).SendKeys("2262262266");
            driver.FindElement(By.Name("email")).SendKeys("moj@moj");
            driver.FindElement(By.Name("notes")).SendKeys("Hi");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G2");
            driver.FindElement(By.Name("phone")).SendKeys("2262262266");
            driver.FindElement(By.Name("email")).SendKeys("moj@moj");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys("hi");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G2");
            driver.FindElement(By.Name("phone")).SendKeys("2262262266");
            driver.FindElement(By.Name("email")).SendKeys("moj@moj");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys("hi");
            driver.FindElement(By.CssSelector("div > input")).Click();
            Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Email!"));
        }

        [Test]
        public void wrongPhoneNumberFormatSubmittedinputContactDataWithWrongPhoneNumberForamtsubmitDoesNotCreateHyperlink()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(900, 755);
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.Name("postalCode")).SendKeys("2N2N2N");
            driver.FindElement(By.Name("phone")).SendKeys("226226226600");
            driver.FindElement(By.Name("email")).SendKeys("moj@moj.com");
            driver.FindElement(By.Name("notes")).SendKeys("Hi");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G2");
            driver.FindElement(By.Name("phone")).SendKeys("2262262266");
            driver.FindElement(By.Name("email")).SendKeys("moj@moj.com");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys("hi");
            driver.FindElement(By.Name("phone")).Click();
            driver.FindElement(By.Name("phone")).SendKeys("22622622");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G2");
            driver.FindElement(By.Name("phone")).SendKeys("2262262266");
            driver.FindElement(By.Name("email")).SendKeys("moj@moj.com");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys("hi");
            driver.FindElement(By.Name("phone")).Click();
            driver.FindElement(By.Name("phone")).SendKeys("22622622");
            driver.FindElement(By.CssSelector("div > input")).Click();
            Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Phone number"));
        }

        [Test]
        public void wrongPostalCodeFormatSubmittedinputContactDataWithWrongPostalCodeForamtsubmitDoesNotCreateHyperlink()
        {
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(900, 755);
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G2");
            driver.FindElement(By.Name("phone")).SendKeys("2262262266");
            driver.FindElement(By.Name("email")).SendKeys("moj@moj");
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys("moj@moj.com");
            driver.FindElement(By.Name("postalCode")).Click();
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys("hi");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).SendKeys("Moj");
            driver.FindElement(By.Name("lastName")).SendKeys("Abb");
            driver.FindElement(By.Name("address")).SendKeys("Westwood");
            driver.FindElement(By.Name("city")).SendKeys("Kitchener");
            driver.FindElement(By.Name("province")).SendKeys("ON");
            driver.FindElement(By.Name("postalCode")).SendKeys("N2T2G");
            driver.FindElement(By.Name("phone")).SendKeys("2262262266");
            driver.FindElement(By.Name("email")).SendKeys("moj@moj.com");
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys("hi");
            driver.FindElement(By.CssSelector("div > input")).Click();
            driver.FindElement(By.CssSelector("div > input")).Click();
            Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo("Postal code"));
        }
    }
}