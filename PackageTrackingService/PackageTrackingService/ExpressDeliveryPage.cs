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
    class ExpressDeliveryPage
    {
        private IWebDriver driver;
        public ExpressDeliveryPage (IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        
    }
}
