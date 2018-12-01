using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.AdminSite
{
    public class BannedWordPhrasesPage : Base
    {
        public static By BannedPhrasesHeader
        { get { return (By.XPath("(//*[@href='/InstantImpact/BannedWords/BannedPhrases.aspx']/span")); } }

        public static By AddNewBannedWordBtn
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridTemplate_ctl00_ctl02_ctl00_AddNewRecordButton']")); } }

        public static By Description
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridTemplate_ctl00_ctl02_ctl03_radExternalItem']")); } }

        public static By AddBtn
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridTemplate_ctl00_ctl02_ctl03_btnSave_input']")); } }

        public static By ConfirmationMsg
        { get { return (By.XPath("//*[text()='The word was saved successfully.']")); } }

        public static By NewlyAddedBannedWordTxt
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridTemplate']/table//tbody/tr[1]/td[4]")); } }

        public static By EditBannedWordBtn
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridTemplate']/table//tbody/tr[1]/td[2]/a")); } }

        public static By UpdateBtn
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridTemplate_ctl00_ctl05_btnSave_input']")); } }

        public static By Delete
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridTemplate']/table//tbody/tr[1]/td[3]/a")); } }

        Interactions action;
        public BannedWordPhrasesPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify Banned Phrases page
        public void VerifyBannedPhrasesPage()
        {
            try
            {
                action.WaitVisible(BannedPhrasesHeader);
                bool statusofbannedphrasesheader = action.IsElementDisplayed(BannedPhrasesHeader);
                Console.WriteLine("Status of Banned phrases header is " + statusofbannedphrasesheader);
                Assert.IsTrue(statusofbannedphrasesheader);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify banned phrases page failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Add New Banned Word
        public void AddNewBannedWord()
        {
            try
            {
                string bannedword = action.StringGenerator(4);
                action.WaitVisible(AddNewBannedWordBtn);
                action.Click(AddNewBannedWordBtn);
                action.WaitVisible(Description);
                action.Type(Description,bannedword);
                action.WaitVisible(AddBtn);
                action.Click(AddBtn);
                action.WaitVisible(ConfirmationMsg);
                bool statusofconfirmationmsg = action.IsElementDisplayed(ConfirmationMsg);
                Console.WriteLine("Status of Confirmation msg is " + statusofconfirmationmsg);
                Assert.IsTrue(statusofconfirmationmsg);
            }
            catch(Exception e)
            {
                Console.WriteLine("Add new banned word failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Verify Banned word added successfully
        public void VerifyBannedWordAddedSuccessfully()
        {
            try
            {
                action.WaitVisible(ConfirmationMsg);
                string confirmationmessage = action.GetText(ConfirmationMsg);
                Console.WriteLine("Confirmation message is " + confirmationmessage);
                Assert.IsTrue(confirmationmessage.Contains("The word was saved successfully."), confirmationmessage + "Error msg -Confirmation message is not comming");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Banned Word Added Successfully failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Get Banned Word from Admin Banned Words page 
        public string GetAddedBannedWord()
        {
            try
            {
                action.WaitVisible(NewlyAddedBannedWordTxt);
                string newbannedword = action.GetText(NewlyAddedBannedWordTxt);
                Console.WriteLine("New banned word is " + newbannedword);

                return newbannedword;
            }
            catch(Exception e)
            {
                Console.WriteLine("Get added banned word failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Edit
        public void ClickOnEdit()
        {
            try
            {
                action.WaitVisible(EditBannedWordBtn);
                action.Click(EditBannedWordBtn);
                action.WaitVisible(UpdateBtn);
                action.Click(UpdateBtn);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on edit failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Delete Banned Word
        public void DeleteBannedWord()
        {
            try
            {
                action.WaitVisible(Delete);
                action.Click(Delete);
                //Type(Keys.Enter);
            }
            catch(Exception e)
            {
                Console.WriteLine("Delete failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

    }
}
