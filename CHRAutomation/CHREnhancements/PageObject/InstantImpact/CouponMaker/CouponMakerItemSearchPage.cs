using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.CouponMaker
{
    public class CouponMakerItemSearchPage : Base
    {
        public static By SearchField
        { get { return (By.XPath("//*[@id='Body_txtSearch']")); } }

        public static By SearchButton
        { get { return (By.XPath("//*[@id='ctl00_Body_btnSearch']")); } }

        public static By Template
        { get { return (By.XPath("//*[@class='caption description text-center']")); } }

        public static By CreateYourDesign
        { get { return (By.XPath("//*[@id='Body_btnProductDesign']")); } }

        Interactions action;
        public CouponMakerItemSearchPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }


        //Search template with template id
        public void SearchCouponTemplate(string templateid)
        {
            try
            {
                action.WaitVisible(SearchField,10);
                action.Type(SearchField, templateid);
                action.WaitTime(10);
                action.WaitVisible(SearchButton);
                action.Click(SearchButton);
            }
            catch (Exception e)
            {
                Console.WriteLine("Search coupon maker template failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Select template
        public void SelectTemplate()
        {
            try
            {
                action.ScrollToViewElement(Template);
                action.WaitVisible(Template);
                action.Click(Template);
            }
            catch(Exception e)
            {
                Console.WriteLine("Select template failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //CLick on Create Your Own Design
        public void ClickOnCareteYourOwnDesign()
        {
            try
            {
                action.ScrollToViewElement(CreateYourDesign);
                action.Click(CreateYourDesign);
            }
            catch(Exception e)
            {

            }
        }
    }
}