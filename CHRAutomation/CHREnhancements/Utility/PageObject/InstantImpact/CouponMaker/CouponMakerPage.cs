using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.CouponMaker
{
    class CouponMakerPage : Base
    {
        public static By Template
        { get { return (By.XPath("//*[@id='ctl00_Body_rlvSearchResults_ctrl0_imgThumbnail']")); } }

        public static By CouponMakerTab
        { get { return (By.XPath("//*[@class='rmLink rmRootLink']/span[text()='Coupon Maker']")); } }

        public static By Back
        { get { return (By.XPath("//*[@id='Body_lnkBack']")); } }

        Interactions action;
        public CouponMakerPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        
        //Click on Coupon Maker
        public void ClickOnCoupnMaker()
        {
            try
            {
                action.WaitVisible(CouponMakerTab);
                action.Click(CouponMakerTab);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Coupon maker failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
    }
}
