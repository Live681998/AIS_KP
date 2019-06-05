using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace PackageTrackingService
{
    class NavigationElements
    {
        private IWebDriver driver;

        public NavigationElements(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.CssSelector, Using = "#nav > ul > li.current_page_item > a")]
        private IWebElement home;

        [FindsBy(How = How.CssSelector, Using = "#nav > ul > li:nth-child(4) > a")]
        private IWebElement feedback;

        [FindsBy(How = How.CssSelector, Using = "#nav > ul > li.opener > ul > li.opener > ul > li:nth-child(1) > a")]
        private IWebElement express;

        [FindsBy(How = How.CssSelector, Using = "#nav > ul > li:nth-child(3) > a")]
        private IWebElement tracking;

        [FindsBy(How = How.CssSelector, Using = "#nav > ul > li.opener.active > a")]
        private IWebElement services;

        [FindsBy(How = How.CssSelector, Using = "#nav > ul > li.opener > ul > li.opener > a")]
        private IWebElement delivery;

        public HomePage ToHomePage()
        {
            home.Click();
            return new HomePage(driver);
        }

        public FeedbackPage ToFeedbackPage()
        {
            feedback.Click();
            return new FeedbackPage(driver);
        }

        public TrackingPage ToTrackingPage()
        {
            tracking.Click();
            return new TrackingPage(driver);
        }

        public ExpressDeliveryPage ToExpressDeliveryPage()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(services);
            actions.MoveToElement(delivery);
            actions.Click();
            return new ExpressDeliveryPage(driver);
        }
    }
}
