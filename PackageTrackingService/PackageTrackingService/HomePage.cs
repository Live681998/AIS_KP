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
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.CssSelector, Using = "body > footer > div > div > div > a")]
        private IWebElement anchor;

        public bool PageIsOpened()
        {
            return anchor.Displayed;
        }
    }
}
