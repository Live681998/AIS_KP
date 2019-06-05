using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace PackageTrackingService
{
    class TrackingPage
    {
        private IWebDriver driver;

        public TrackingPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.CssSelector, Using = "#track-form > input[type=text]:nth-child(2)")]
        private IWebElement trackingTextBox;

        [FindsBy(How = How.CssSelector, Using = "#track-form > a")]
        private IWebElement trackingButton;

        public bool PageIsOpened()
        {
            return trackingButton.Displayed;
        }

        public void FillForm(string tracking)
        {
            trackingTextBox.SendKeys(tracking);
            trackingButton.Click();
        }

        public bool CheckFillForm()
        {
            if (!string.IsNullOrWhiteSpace(trackingTextBox.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
