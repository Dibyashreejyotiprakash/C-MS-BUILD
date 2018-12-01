using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace CHREnhancements.PageObject.BMAdmin
{
    public class BudgetManager_DistributorBudgetSetup : Base
    {
        public static By CoporationTextFiled
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rcbCorpId_Input']")); } }
        
        public static By BudgetNameTextField
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_txtBudgetName']")); } }
        
        public static By ClientPoNoTextFiled
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_txtClientPONumber']")); } }

        public static By BudgetTypeDropdown
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_ddlBudgetType']")); } }

        public static By BudgetTypeValue
        { get { return (By.XPath("//*[text()='Brand']")); } }

        public static By DefaultBudgetCheckBox
        { get { return (By.XPath("//*[@id='cphMain_cphMain_cbxDefaultBudget']")); } }

        public static By HardStopCheckBox
        { get { return (By.XPath("//*[@id='cphMain_cphMain_cbxHardStop']")); } }

        public static By MarketsTextField
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rcbMarkets_Input']")); } }

        public static By StartDateTextField
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_RadDatePicker1_dateInput']")); } }

        public static By EndDateTextField
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_RadDatePicker2_dateInput']")); } }

        public static By InitialBudgetAmountTextField
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_txtInitialBudgetAmount']")); } }

        public static By LowBudgetAlert
        { get { return (By.XPath("//*[@id='cphMain_cphMain_cbxLowBudgetAlert']")); } }

        public static By LowBudgetthresholdTextField
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_txtLowBudgetAmount']")); } }

        public static By SubmitBtn
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_btnSubmit_input']")); } }

        public static By CancelBtn
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_btnCancel_input']")); } }

        public static By UpdateCompletedMessage
        { get { return (By.XPath("//*[@id='cphMain_cphMain_cmAppMessages_blSummary']/li")); } }

        Interactions action;

        public BudgetManager_DistributorBudgetSetup(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify DistributorBudgetSetup page
        public void VerifyDistributorBudgetSetUp()
        {
            try
            {
                action.VerifyCurrentPage("Distributor Budget Set up page", "DistributorBudgetSetup.aspx");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Distributor Budget SetUp failed due to " + e);
                throw e;
            }
        }

        public void SubmitDistributorBudgetSetUp(string CorporationName,string BudgetName,string ClientPoNo,string StartDate,string EndDate,string InitialBudgetAmount, string LowBudgetThreshold)
        {
            try
            {
                action.Type(CoporationTextFiled, CorporationName);
                action.Type(BudgetNameTextField, BudgetName);
                action.Type(ClientPoNoTextFiled, ClientPoNo);
                action.Click(BudgetTypeDropdown);
                action.WaitVisible(BudgetTypeValue);
                action.Click(BudgetTypeValue);
                action.WaitVisible(DefaultBudgetCheckBox);
                action.Click(DefaultBudgetCheckBox);
                action.WaitTime(5);
                action.WaitVisible(HardStopCheckBox);
                action.WaitTime(5);
                action.Click(HardStopCheckBox);
                action.WaitTime(5);
                action.Type(StartDateTextField, StartDate);
                action.WaitTime(5);
                action.Type(EndDateTextField, EndDate);
                action.WaitTime(5);
                action.Type(InitialBudgetAmountTextField, InitialBudgetAmount);
                action.WaitVisible(LowBudgetAlert);
                action.Click(LowBudgetAlert);
                action.Type(LowBudgetthresholdTextField, LowBudgetThreshold);
                action.Click(SubmitBtn);
                action.WaitVisible(UpdateCompletedMessage);
                bool stausofupdatedmessage = action.IsElementDisplayed(UpdateCompletedMessage);
                Console.WriteLine("Status of message is " + stausofupdatedmessage);
                string message = action.GetText(UpdateCompletedMessage);
                Console.WriteLine("The Displayed Message is " + message);
                if(stausofupdatedmessage)
                {
                    Console.WriteLine("Distributor budget Set up completed successfully");
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Submit Distributor Budget SetUp failed due to " + e);
                throw e;
            }
        }

    }
}