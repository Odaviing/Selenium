using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumStuff
{
    public class BaseTestsSettings : IDisposable
    {
        private IWebDriver _chrome;

        public IWebDriver StartDriverWithURL(string url)
        {
            _chrome = new ChromeDriver();
            _chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            _chrome.Manage().Window.Maximize();
            _chrome.Navigate().GoToUrl(url);
            return _chrome;
        }
        public void Dispose()
        {
            _chrome.Quit();
        }
    }

    
}
