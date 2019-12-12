using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Selenium
{
    [TestClass]
    public class BuscarGoogle
    {
        [TestMethod]
        public void BuscarSelenium()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions))
            {
                driver.Navigate().GoToUrl("https://www.google.com/");

                IWebElement query = driver.FindElement(By.Name("q"));

                query.SendKeys("Selenium");
                query.Submit();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until((d) => { return d.Title.ToLower().StartsWith("selenium"); });

                Assert.AreEqual(driver.Title, "Selenium - Buscar con Google");
            }
        }
    }
}
