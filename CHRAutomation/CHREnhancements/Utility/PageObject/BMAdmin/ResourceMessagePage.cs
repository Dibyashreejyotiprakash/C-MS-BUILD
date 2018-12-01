using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.BMAdmin
{
    public class ResourceMessagePage : Base
    {
        public static By CorporationName
        { get { return (By.XPath("//*[@id='ctl00_cphMain_rcbCorpId_Input']")); } }

        public static By DistributorNameTextField
        { get { return (By.XPath("//*[@id='ctl00_cphMain_rcbDistId_Input']")); } }

        public static By DistributorDropdown
        { get { return (By.XPath("(//*[@class='rcbActionButton'])[2]")); } }

        public static By DistributorName
        { get { return (By.XPath("//*[text()='Nutro Pet Food Products']")); } }

        public static By EditBtn
        { get { return (By.XPath("//*[text()='Edit']")); } }

        public static By DescriptionOverrideTextField
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridResource_ctl00_ctl05_radOverrideResource']")); } }

        public static By OverridePopup
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridResource_ctl00_ctl05_ctl00']")); } }

        public static By OverridePopupCancelBtn
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridResource_ctl00_ctl05_btnCancel_input']")); } }

        public static By UpdateBtn
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridResource_ctl00_ctl05_btnSave_input']")); } }

        public static By DeleteBtn
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridResource_ctl00_ctl04_lnkDelete']")); } }

        public static By CancelBtn
        { get { return (By.XPath("//*[@id='ctl00_cphMain_RadGridResource_ctl00_ctl05_btnCancel_input']")); } }

        public static By OverrideTextMessage
        { get { return (By.XPath("//*[@class='rgRow']/td[9]")); } }
        

        Interactions action;
        public ResourceMessagePage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify Resource Message Page
        public void  VerifyResourceMessagePage()
        {
            try
            {
                action.VerifyCurrentPage("Resource message page", "ResourceMessage.aspx");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Resource Message Page failed due to " + e);
                throw e;
            }
        }

        //Upadte Resouce Message
        public void UpdateResorceMessage(string corporationname,string distributorname)
        {
            try
            {
                action.Type(CorporationName, corporationname);
                Console.WriteLine("Mouse hover on"+ corporationname+ "tab");
                action.Type(DistributorNameTextField, distributorname);
                action.Click(EditBtn);
                action.WaitVisible(OverridePopup);
                bool statusofoverridepopup = action.IsElementDisplayed(OverridePopup);
                if (statusofoverridepopup)
                {
                    Console.WriteLine("Override pop up displayed");
                    IWebElement element = Driver.FindElement(DescriptionOverrideTextField);
                    string exstingvalue = element.GetAttribute("value");
                    Console.WriteLine("The exsting override text is " + exstingvalue);
                    if(exstingvalue.Equals(""))
                    {
                        action.Type(DescriptionOverrideTextField, "Override Text Message");
                        action.Click(UpdateBtn);
                    }
                    else
                    {
                        action.Click(OverridePopupCancelBtn);
                        Console.WriteLine("Pop up canceled");
                    }
                }
                else
                {
                    Assert.Fail();
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("Update Resorce Message failed due to " + e);
                throw e;
            }
        }

        //Delete Resource Message
        public void DeleteResourceMessage()
        {
            try
            {
                action.Click(DeleteBtn);
                IAlert alert = Driver.SwitchTo().Alert();
                alert.Accept();   
            }
            catch(Exception e)
            {
                Console.WriteLine("Delete Resource Message failed due to " + e);
                throw e;
            }
        }

        //Verify Override message is prepopulating
        public void VerifyPrepopulationOfOverrideMessage(string corporationname, string distributorname)
        {
            string exstingvalue = null;
            try
            {
                action.Type(CorporationName, corporationname);
                action.WaitVisible(DistributorDropdown);
                action.Click(DistributorDropdown);
                action.WaitVisible(DistributorName);
                action.Click(DistributorName);
                action.WaitTime(5);
                string textmessage = action.GetText(OverrideTextMessage);
                if(textmessage.Equals(" "))
                {
                    action.Click(EditBtn);
                    action.WaitVisible(OverridePopup);
                    action.Type(DescriptionOverrideTextField, "Override Text Message");
                    action.Click(UpdateBtn);
                    action.Click(EditBtn);
                    IWebElement element = Driver.FindElement(DescriptionOverrideTextField);
                    exstingvalue = element.GetAttribute("value");
                    if(exstingvalue.Equals(textmessage))
                    {
                        Console.WriteLine("Same Exsting Override Text Message prepopulating.");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
                else
                {
                    action.Click(EditBtn);
                    action.WaitVisible(OverridePopup);
                    IWebElement element = Driver.FindElement(DescriptionOverrideTextField);
                    exstingvalue = element.GetAttribute("value");
                    Console.WriteLine("Override text is " + exstingvalue);
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Prepopulation Of Override Message failed due to " + e);
                throw e;
            }
        }
        
    }
}
    