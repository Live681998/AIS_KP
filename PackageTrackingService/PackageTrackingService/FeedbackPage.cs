using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace PackageTrackingService
{
    class FeedbackPage
    {
        private IWebDriver driver;
        public FeedbackPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.CssSelector, Using = "#CommentAuthor")]
        private IWebElement nameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#CommentEmail")]
        private IWebElement emailTextBox;

        [FindsBy(How = How.CssSelector, Using = "#dCommentLocation")]
        private IWebElement cityTextBox;

        [FindsBy(How = How.CssSelector, Using = "#CommentTitleCode")]
        private IWebElement categoryDropDown;

        [FindsBy(How = How.CssSelector, Using = "#CommentComment")]
        private IWebElement questionTextBox;

        [FindsBy(How = How.CssSelector, Using = "#agreement")]
        private IWebElement agreementCheckBox;

        [FindsBy(How = How.CssSelector, Using = "#add-feedback")]
        private IWebElement submitButton;

        public bool PageIsOpened()
        {
            return submitButton.Displayed;
        }

        public void FillForm(string name, string email, string city, string question)
        {
            nameTextBox.SendKeys(name);
            Thread.Sleep(1000);
            emailTextBox.SendKeys(email);
            Thread.Sleep(1000);
            cityTextBox.SendKeys(city);
            Thread.Sleep(1000);
            questionTextBox.SendKeys(question);
            Thread.Sleep(1000);
            agreementCheckBox.Click();
            Thread.Sleep(1000);
            var selectElement = new SelectElement(categoryDropDown);
            selectElement.SelectByValue("1");
            Thread.Sleep(1000);
            submitButton.Click();
            Thread.Sleep(1000);
        }

        public bool CheckFillForm()
        {
            try
            {
                if (driver.SwitchTo().Alert().Text == "Вопрос добавлен")
                {
                    
                    Thread.Sleep(1000);
                    driver.SwitchTo().Alert().Accept();
                }
                return true;
            }
            
            catch(NoAlertPresentException ex)
            {
                return false;
            }
        }
    }
}
