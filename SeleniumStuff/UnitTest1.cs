using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumStuff
{
    public class UnitTest1 : IDisposable
    {
        IWebDriver chrome;
        public UnitTest1()
        {
            chrome = new ChromeDriver();
        }
        [Fact]
        public void Test1()
        {
            chrome.Navigate().GoToUrl("https://www.mtggoldfish.com");
            IWebElement element = chrome.FindElement(By.Name("query_string"));
            element.SendKeys("Yuriko");
            element.SendKeys(Keys.Enter);
            IWebElement element2 = chrome.FindElement(By.Name("set_id"));
            element2.SendKeys("Commander Legends");
            element2 = chrome.FindElement(By.Name("commit"));
            //element2.SendKeys(Keys.Enter);
            element2.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/price/Commander+Legends:Foil/Yuriko+the+Tigers+Shadow-etched#paper", actual_url);
        }

        

        [Fact]
        public void Test2()
        {
            chrome.Navigate().GoToUrl("https://www.mtggoldfish.com");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.Name("mformat"));
            element.Click();
            element.SendKeys("Modern");
            element.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            IWebElement element2 = chrome.FindElement(By.CssSelector("a[class='btn btn-secondary']"));
            element2.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/metagame/modern#paper", actual_url);
        }

        [Fact]
        public void Test3()
        {
            chrome.Navigate().GoToUrl("https://www.mtggoldfish.com");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='/articles']"));
            element.Click();
            //IWebElement element = chrome.FindElement(By.ClassName("article-tile-thumbnail"));
            //element.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/articles", actual_url);
        }

        [Fact]
        public void Test4()
        {
            chrome.Navigate().GoToUrl("https://www.mtggoldfish.com");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='/movers/paper/standard']"));
            element.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/movers/paper/standard", actual_url);
        }

        [Fact]
        public void Test5()
        {
            chrome.Navigate().GoToUrl("https://www.mtggoldfish.com");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='/previews']"));
            element.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/spoilers/Kamigawa+Neon+Dynasty#paper", actual_url);
        }

        [Fact]
        public void Test6()
        {
            chrome.Navigate().GoToUrl("https://www.mtggoldfish.com");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='#']"));
            element.Click();
            IWebElement element2 = chrome.FindElement(By.CssSelector("a[href='/sets/Kamigawa+Neon+Dynasty']"));
            element2.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/sets/Kamigawa+Neon+Dynasty", actual_url);
        }

        [Fact]
        public void Test7()
        {
            chrome.Navigate().GoToUrl("https://www.mtggoldfish.com");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.XPath("//*[contains(text(),'Cards')]"));
            element.Click();
            IWebElement element2 = chrome.FindElement(By.CssSelector("a[href='/prices/standard']"));
            element2.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/prices/paper/standard", actual_url);
        }


        [Fact]
        public void Test8()
        {
            chrome.Navigate().GoToUrl("https://www.mtggoldfish.com");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='/movers/paper/standard']"));
            element.Click();
            IWebElement element2 = chrome.FindElement(By.CssSelector("a[href='/movers-details/paper/standard/losers/wow']"));
            element2.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/movers-details/paper/standard/losers/wow", actual_url);
        }


        [Fact]
        public void Test9()
        {
            chrome.Navigate().GoToUrl("https://www.mtggoldfish.com");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.XPath("//*[contains(text(),'Store')]"));
            element.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://mtggoldfishmerch.com/", actual_url);
            
        }

        [Fact]
        public void Test10()
        {
            chrome.Navigate().GoToUrl("https://www.mtggoldfish.com");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='/articles']"));
            element.Click();
            IWebElement element2 = chrome.FindElement(By.Name("q"));
            element2.SendKeys("Precon Upgrades for Undead Unleashed");
            element2.SendKeys(Keys.Enter);
            element2 = chrome.FindElement(By.CssSelector("a[href='/articles/precon-upgrades-for-undead-unleashed-50-wilhelt-zombie-tribal-sacrifice-mic']"));
            element2.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/articles/precon-upgrades-for-undead-unleashed-50-wilhelt-zombie-tribal-sacrifice-mic", actual_url);
        }


            public void Dispose()
            {
                chrome.Quit();
            }
        }
}
