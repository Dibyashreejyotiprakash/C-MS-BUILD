using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace CHREnhancements.PageObject.InstantImpact.Review 
{
    public class ReviewPage : Base
    {
        public static By CheckOutBtn
        { get { return (By.XPath("//*[@id='Body_bottomContToCheckOutBtn']")); } }

        Interactions action;
        public ReviewPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }


        //Verify review page
        public void VerifyReviewPage()
        {
            try
            {
                string act_currenturl = Driver.Url;
                if (act_currenturl.Contains("Review"))
                {
                    Console.WriteLine("Review page verified successfully.");
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Review page failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on PlaceOrder
        public void ClickOnPlaceOrder()
        {
            try
            {
                action.ScrollToViewElement(CheckOutBtn);
                action.Click(CheckOutBtn);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click On Place Order failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
    }
}
