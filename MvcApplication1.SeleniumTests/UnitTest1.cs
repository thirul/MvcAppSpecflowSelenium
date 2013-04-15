using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;


namespace MvcApplication1.SeleniumTests
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver webDriver = null;

        [TestInitialize]
        public void Setup()
        {
            webDriver = new FirefoxDriver();
        }

        [TestMethod]
        public void TestMethod1()
        {

            webDriver.Url = "http://gmail.com";

            var emailElement = webDriver.FindElement(By.Id("Email"));
            var passwordElement = webDriver.FindElement(By.Id("Passwd"));

            emailElement.SendKeys("invalid");
            passwordElement.SendKeys("invalid");

            var signInElement = webDriver.FindElement(By.Id("signIn"));
            signInElement.Click();

            var webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            webDriverWait.Until((d) => 
            {
                // var errorMessage = webDriver.FindElement(By.ClassName("errormsg"));
                // return errorMessage.Text;

                return d.Title.Contains("sudagoni@gmail.com");
            });

            //var errorMessage1 = webDriver.FindElement(By.ClassName("errormsg"));
            //Assert.IsTrue(errorMessage1.Text.Contains("incorrect123"));

            // valid case
            //var userNameElement = webDriver.FindElement(By.Id("gbi4t"));
            //Assert.AreEqual(userNameElement.Text, "Goud Sudagoni23");

            var userImage = webDriver.FindElement(By.Id("gbi4i"));
            userImage.Click();
            var signOutElement = webDriver.FindElement(By.Id("gb_71"));
            signOutElement.Click();

            var webDriverWaitSignOut = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
            webDriverWaitSignOut.Until((d) =>
            {
                // var errorMessage = webDriver.FindElement(By.ClassName("errormsg"));
                // return errorMessage.Text;

                return d.Title.Contains("Email from Google");
            });

            Assert.IsTrue(webDriver.Title.Contains("Email from "));


        }

        [TestCleanup]
        public void CleanUp()
        {
            webDriver.Close();
        }
    }
}
