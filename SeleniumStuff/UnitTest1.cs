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
            IWebElement query_field = chrome.FindElement(By.Name("query_string"));
            query_field.SendKeys("Yuriko");
            query_field.SendKeys(Keys.Enter);
            IWebElement set_dropdown = chrome.FindElement(By.Name("set_id"));
            set_dropdown.SendKeys("Commander Legends");
            IWebElement submit_button = chrome.FindElement(By.Name("commit"));
            submit_button.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/price/Commander+Legends:Foil/Yuriko+the+Tigers+Shadow-etched#paper", actual_url);
        }

        

        [Fact]
        public void CheckLatestModernDecks()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement format_dropdown = chrome.FindElement(By.Name("mformat"));
            format_dropdown.Click();
            format_dropdown.SendKeys("Modern");
            format_dropdown.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            IWebElement submit_button = chrome.FindElement(By.CssSelector("a[class='btn btn-secondary']"));
            submit_button.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/metagame/modern#paper", actual_url);
        }

        [Fact]
        public void CheckLatestArticles()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement page_button = chrome.FindElement(By.CssSelector("a[href='/articles']"));
            page_button.Click();
            IWebElement next_page = chrome.FindElement(By.CssSelector("a[rel='next']"));
            next_page.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/articles?page=2", actual_url);
        }

        [Fact]
        public void CheckStandardSinglesThatMovedInPrice()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement page_link = chrome.FindElement(By.CssSelector("a[href='/movers/paper/standard']"));
            page_link.Click();
            IWebElement format_link = chrome.FindElement(By.CssSelector("a[href='/movers/paper/modern']"));
            format_link.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/movers/paper/modern", actual_url);
        }

        [Fact]
        public void CheckKamigawaPreviews()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement previews_link = chrome.FindElement(By.CssSelector("a[href='/previews']"));
            previews_link.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/spoilers/Kamigawa+Neon+Dynasty#paper", actual_url);
        }

        [Fact]
        public void CheckKamigawaSinglesPrices()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement set_dropdown = chrome.FindElement(By.CssSelector("a[href='#']"));
            set_dropdown.Click();
            IWebElement dropdown_option = chrome.FindElement(By.CssSelector("a[href='/sets/Kamigawa+Neon+Dynasty']"));
            dropdown_option.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/sets/Kamigawa+Neon+Dynasty", actual_url);
        }

        [Fact]
        public void CheckStandardSinglesPrices()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement cards_dropdown = chrome.FindElement(By.XPath("//*[contains(text(),'Cards')]"));
            cards_dropdown.Click();
            IWebElement dropdown_option = chrome.FindElement(By.CssSelector("a[href='/prices/standard']"));
            dropdown_option.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/prices/paper/standard", actual_url);
        }


        [Fact]
        public void CheckListOfTopWeeklyLosers()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement page_link = chrome.FindElement(By.CssSelector("a[href='/movers/paper/standard']"));
            page_link.Click();
            IWebElement see_more_link = chrome.FindElement(By.CssSelector("a[href='/movers-details/paper/standard/losers/wow']"));
            see_more_link.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/movers-details/paper/standard/losers/wow", actual_url);
        }


        [Fact]
        public void CheckBestsellersCategoryInMerchStore()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement store_button = chrome.FindElement(By.XPath("//*[contains(text(),'Store')]"));
            store_button.Click();
            Thread.Sleep(1000);
            IWebElement see_more_link = chrome.FindElement(By.CssSelector("a[href='/collections/best-sellers']"));
            see_more_link.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://mtggoldfishmerch.com/collections/best-sellers", actual_url);
            
        }

        [Fact]
        public void CheckArticleAboutUndeadUnleashDeck()
        {
            chrome = StartDriverWithURL("https://www.mtggoldfish.com");
            IWebElement articles_button = chrome.FindElement(By.CssSelector("a[href='/articles']"));
            articles_button.Click();
            IWebElement query_field = chrome.FindElement(By.Name("q"));
            query_field.SendKeys("Precon Upgrades for Undead Unleashed");
            query_field.SendKeys(Keys.Enter);
            IWebElement article = chrome.FindElement(By.CssSelector("a[href='/articles/precon-upgrades-for-undead-unleashed-50-wilhelt-zombie-tribal-sacrifice-mic']"));
            article.Click();
            string actual_url = chrome.Url;
            Assert.Equal("https://www.mtggoldfish.com/articles/precon-upgrades-for-undead-unleashed-50-wilhelt-zombie-tribal-sacrifice-mic", actual_url);
        }


        }
}
