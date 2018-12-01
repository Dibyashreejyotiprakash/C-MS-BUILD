using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.Share
{
    class ShareTemplatePage : Base
    {
        public static By SenderMail
        { get { return (By.XPath("//*[@id='txtEmail']")); } }

        public static By Add
        { get { return (By.XPath("//*[@id='Body_AddEmails']")); } }

        public static By Subject
        { get { return (By.XPath("//*[@id='Body_Txt_Subject']")); } }

        public static By Send
        { get { return (By.XPath("//*[@id='Body_btnShare']")); } }

        public static By ConfirmationMsgPopup
        { get { return (By.XPath("//*[@id='ctl00_Body_ucMB_ucRadNotification_C_radNotifyTextWrapper']")); } }

        Interactions action;
        public ShareTemplatePage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Share Template
        public void ShareTemplate(string sendermailid)
        {
            try
            {
                action.WaitForPageToLoad();
                action.WaitVisible(SenderMail);
                action.Type(SenderMail,sendermailid);
                action.WaitVisible(Send);
                action.ScrollToViewElement(Send);
                action.Click(Send);
                string msg = action.GetText(ConfirmationMsgPopup);
                Console.WriteLine("Message is " + msg);
            }
            catch (Exception e)
            {
                Console.WriteLine("Share Template is failed due to: " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
    }
}
