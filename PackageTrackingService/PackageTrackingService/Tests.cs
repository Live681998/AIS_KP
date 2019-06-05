using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;

namespace PackageTrackingService
{
    class Tests
    {
        IWebDriver driver;
        NavigationElements navigation;

        [OneTimeSetUp]
        public void TestSetUp()
        {
            this.driver = new ChromeDriver();
            driver.Url = "file:///C:/Files/github/AIS_CourseWork/AIS_KP/template/index.html";
            navigation = new NavigationElements(driver);
        }

        [Test]
        public void OpenFeedbackTest()
        {
            //Thread.Sleep(1000);

            FeedbackPage feedback = navigation.ToFeedbackPage();
            //Thread.Sleep(1000);
            Assert.IsTrue(feedback.PageIsOpened());
        }

        [Test]
        public void FillTrackingTest()
        {
            TrackingPage tracking = navigation.ToTrackingPage();
            tracking.FillForm("1812536");
            Assert.IsTrue(tracking.CheckFillForm());
        }

        [Test]
        public void FillFeedbackTestPositive()
        {
            FeedbackPage feedback = navigation.ToFeedbackPage();
            feedback.FillForm("Ivan", "el@gm62.com", "Gothem", "How are you?");

            Assert.IsTrue(feedback.CheckFillForm());
        }

        [Test]
        public void FillFeedbackTestNegative()
        {
            FeedbackPage feedback = navigation.ToFeedbackPage();
            feedback.FillForm(null, null, null, null);

            Assert.IsTrue(feedback.CheckFillForm());
        }

        [Test]
        public void FillFeedbackTestNegative2()
        {
            FeedbackPage feedback = navigation.ToFeedbackPage();
            feedback.FillForm("Ivan", "el", "Gothem", "How are you?");

            Assert.IsTrue(feedback.CheckFillForm());
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            driver.Quit();
        }
    }

    


}
