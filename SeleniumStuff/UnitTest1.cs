using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumStuff
{
    public class UnitTest1 : BaseTestsSettings
    {
        IWebDriver chrome;
        
        [Fact]
        public void FindYurikoFromCMR()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement element = chrome.FindElement(By.Name("query_string"));
            element.SendKeys("Yuriko");
            element.SendKeys(Keys.Enter);
            IWebElement element2 = chrome.FindElement(By.Name("set_id"));
            element2.SendKeys("Commander Legends");
            element2 = chrome.FindElement(By.Name("commit"));
            element2.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/price/Commander+Legends:Foil/Yuriko+the+Tigers+Shadow-etched#paper", actual_url);
        }

        

        [Fact]
        public void CheckLatestModernDecks()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
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
        public void CheckLatestArticles()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='/articles']"));
            element.Click();
            IWebElement element2 = chrome.FindElement(By.CssSelector("a[rel='next']"));
            element2.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/articles?page=2", actual_url);
        }

        [Fact]
        public void CheckStandardSinglesThatMovedInPrice()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='/movers/paper/standard']"));
            element.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/movers/paper/standard", actual_url);
        }

        [Fact]
        public void CheckKamigawaPreviews()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='/previews']"));
            element.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/spoilers/Kamigawa+Neon+Dynasty#paper", actual_url);
        }

        [Fact]
        public void CheckKamigawaSinglesPrices()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='#']"));
            element.Click();
            IWebElement element2 = chrome.FindElement(By.CssSelector("a[href='/sets/Kamigawa+Neon+Dynasty']"));
            element2.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/sets/Kamigawa+Neon+Dynasty", actual_url);
        }

        [Fact]
        public void CheckStandardSinglesPrices()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement element = chrome.FindElement(By.XPath("//*[contains(text(),'Cards')]"));
            element.Click();
            IWebElement element2 = chrome.FindElement(By.CssSelector("a[href='/prices/standard']"));
            element2.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/prices/paper/standard", actual_url);
        }


        [Fact]
        public void CheckListOfTopWeeklyLosers()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='/movers/paper/standard']"));
            element.Click();
            IWebElement element2 = chrome.FindElement(By.CssSelector("a[href='/movers-details/paper/standard/losers/wow']"));
            element2.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/movers-details/paper/standard/losers/wow", actual_url);
        }


        [Fact]
        public void CheckBestsellersCategoryInMerchStore()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement element = chrome.FindElement(By.XPath("//*[contains(text(),'Store')]"));
            element.Click();
            Thread.Sleep(1000);
            IWebElement element2 = chrome.FindElement(By.CssSelector("a[href='/collections/best-sellers']"));
            element2.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://mtggoldfishmerch.com/collections/best-sellers", actual_url);
            
        }

        [Fact]
        public void CheckArticleAboutUndeadUnleashDeck()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
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



        }
}
