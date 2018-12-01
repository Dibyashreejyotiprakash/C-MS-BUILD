using System;
using CHREnhancements.Initiate;
using OpenQA.Selenium;
using CHREnhancements.Interaction;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.Gmail
{
    class LoginGmailPage : Base
    {
        public static By UserName
        { get { return (By.XPath("//*[@name='identifier']")); } }

        public static By Next
        { get { return (By.XPath("//*[text()='Next']")); }}

        public static By Password
        { get { return (By.XPath("//*[@name='password']")); } }

        public static By MailBySender
        { get { return (By.XPath("//*[@class='yX xY ']/div[2]/span[text()='brandmuscle'][1]")); } }

        public static By Link
        { get { return (By.XPath("//*[text()='Click here to view the design']")); } }

        Interactions action;
        public LoginGmailPage(IWebDriver Driver)
        {
        this.Driver = Driver;
        PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Login to Gmail
        public void LoginToGmail(string un,string pwd)
        {
            try
            {
                action.Type(UserName,un);
                action.WaitVisible(Next);
                action.Click(Next);
                action.WaitVisible(Password);
                action.Type(Password,pwd);
                action.WaitVisible(Next);
                action.Click(Next);
            }
            catch (Exception e)
            {
                Console.WriteLine("VerifyHomePage failed due to: " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Verify mail by sender

        public void VerifyMailBySender()
        {
            try
            {
                action.WaitVisible(MailBySender);
                action.WaitVisible(MailBySender);
                action.Click(MailBySender);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Mail failed due to: " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        public void ClickOnLink()
        {
            try
            {
                action.WaitVisible(Link);
                action.Click(Link);
                action.WaitTime(30);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click On Link failed due to: " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

    }
}
