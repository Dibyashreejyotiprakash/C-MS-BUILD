using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.CheckOut
{
    public class CheckOutPage : Base
    {
        public static By DesignTrackerAccountDropdown
        { get { return (By.XPath("//*[@id='ctl00_Body_desTrackAccComboBox_Input']")); } }

        public static By SelectAccounttext
        { get { return (By.XPath("//*[text()='DIAGEO On-Premise (2) ']")); } }

        public static By Po_Ziptextbox
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_ucBP_104']")); } }

        public static By Commentinputfield
        { get { return (By.XPath("//*[@id='Body_tbComments']")); } }

        public static By ContinueToReviewBtn
        { get { return (By.XPath("//*[@id='ctl00_Body_bottomContToCheckOutBtn']")); } }

        public static By ListOfPO
        { get { return (By.XPath("//*[text()='PO#:*']/following-sibling::span[@class='riSingle RadInput RadInput_Bootstrap']/input[contains(@name,'ctl00$Body$shopCartItemsListView')]")); } }

        public static By CommentsField
        { get { return (By.XPath("//*[@id='Body_tbComments']")); } }

        public static By CheckoutBtn
        { get { return (By.XPath("//*[@id='ctl00_Body_bottomContToCheckOutBtn']")); } }

        Interactions action;
        public CheckOutPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify Checkout page
        public void VerifyCheckOutPage()
        {
            try
            {
                string act_currenturl = Driver.Url;
                Console.WriteLine("Current url is " + act_currenturl);
                if(act_currenturl.Contains("Checkout"))
                {
                    Console.WriteLine("Checkout page verified successfully.");
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify CheckOut Page failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Procced to Review
        public void ProceedToReview()
        {
            try
            {
                action.WaitVisible(DesignTrackerAccountDropdown);
                action.Click(DesignTrackerAccountDropdown);
                action.WaitVisible(Po_Ziptextbox);
                action.Type(Po_Ziptextbox,"2434567");
                action.WaitVisible(Commentinputfield);
                action.Type(Commentinputfield,"For Testing purpose only");
                action.ScrollToViewElement(ContinueToReviewBtn);
                action.Click(ContinueToReviewBtn);
            }
            catch(Exception e)
            {
                Console.WriteLine("Proceed to review failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Give input to Po#
        public void GiveFillingDetails(string details)
        {
            try
            {
                action.WaitVisible(ListOfPO);
                IList<IWebElement> pos = action.GetElements(ListOfPO);
                int total_pos2 = pos.Count;
                for (int i=0;i<total_pos2;i++)
                {
                    pos[i].SendKeys(details);
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Give filling details failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Give Comments 
        public void GiveComments(string comments)
        {
            try
            {
                action.WaitVisible(Commentinputfield);
                action.Type(Commentinputfield, comments);
            }
            catch(Exception e)
            {
                Console.WriteLine("Give comments failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Continue to review
        public void ClickOnContinueReview()
        {
            try
            {
                action.WaitVisible(ContinueToReviewBtn);
                action.Click(ContinueToReviewBtn);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on continue to review failed due to : " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

    }
}
