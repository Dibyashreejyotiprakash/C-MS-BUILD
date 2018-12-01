using System;
using CHREnhancements.Initiate;
using NUnit.Framework;
using System.Collections.Generic;
using CHREnhancements.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;

namespace CHREnhancements.PageObject.InstantImpact.AdminSite
{
    public class PostCreditCardPage : Base
    {
        public static By ShowAllTransactions
        { get { return (By.XPath("//*[@id='cphMain_btnShowAll']")); } }

        public static By ShowPayableTransaction
        { get { return (By.XPath("//*[@id='cphMain_btnShowPayable']")); } }

        public static By ShowPendingTransaction
        { get { return (By.XPath("//*[@id='cphMain_btnShowUnpaid']")); } }

        public static By SHowPaidTransaction
        { get { return (By.XPath("//*[@id='cphMain_btnShowPaid']")); } }

        public static By Dtjob
        { get { return (By.XPath("//*[@id='ctl00_cphMain_gvAuthCreditCardOrders_ctl00_ctl02_ctl02_FilterTextBox_DTJobID']")); } }

        public static By Confirmation
        { get { return (By.XPath("//*[@id='ctl00_cphMain_gvAuthCreditCardOrders_ctl00_ctl02_ctl02_FilterTextBox_ConfNum']")); } }

        public static By ListOfTranscations
        { get { return (By.XPath("//*[@class='rgRow']")); } }

        public static By ListOfSelectBtn
        { get { return (By.XPath("//*[@class='rgRow']/td/a")); } }

        public static By ReviewPay
        { get { return (By.XPath("//*[@id='cphMain_btnReviewChanges']")); } }

        public static By AddCreditCard
        { get { return (By.XPath("//*[@id='cphMain_btnCreateCreditCard']")); } }

        public static By ResetChanges
        { get { return (By.XPath("//*[@id='cphMain_btnResetChanges']")); } }

        public static By Delete
        { get { return (By.XPath("//*[@id='cphMain_btnDelete']")); } }

        public static By Cancel
        { get { return (By.XPath("//*[@id='cphMain_btnPayInFullCancel']")); } }

        public static By GenerateScripts
        { get { return (By.XPath("//*[@id='cphMain_btnGenerateReceipt']")); } }

        public static By VoidTransaction
        { get { return (By.XPath("//*[@id='cphMain_btnVoidTransaction']")); } }

        Interactions action;
        public PostCreditCardPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //verify   Post Credit Card Pages
        public void VerifyPostCreditCardPage()
        {
            try
            {
                action.VerifyCurrentPage("Post Creidt Card Page", "CreditCardPostChargesSelect");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Post Credit Card Page failed due to " + e);
                throw e;
            }
        }
        //CLick on ShowAll Transaction
        public void ClickOnShowAllTransaction()
        {
            try
            {
                action.WaitVisible(ShowAllTransactions);
                action.Click(ShowAllTransactions);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Show All Transaction failed due to " + e);
                throw e;
            }
        }

        //Click on Show Payable Transaction
        public void ClickOnShowPayableTransaction()
        {
            try
            {
                action.WaitVisible(ShowPayableTransaction);
                action.Click(ShowPayableTransaction);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Show Payable Transaction failed due to " + e);
                throw e;
            }
        }

        //Click on Paid Transaction
        public void ClickOnPaidTransaction()
        {
            try
            {
                action.WaitVisible(ShowPayableTransaction);
                action.Click(ShowPayableTransaction);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Paid Transaction failed due to " + e);
                throw e;
            }
        }

        //Click on Select Button of one transaction
        public void SelectOneTransaction()
        {
            try
            {
                IList<IWebElement> transactions = action.GetElements(ListOfTranscations);
                int totalnooftransaction_present = transactions.Count();
                if(totalnooftransaction_present > 0)
                {
                    IList<IWebElement> selectbtns = action.GetElements(ListOfSelectBtn);
                    int totalselectbtns = selectbtns.Count();
                    for (int i=0;i<=totalselectbtns;i++)
                    {
                        selectbtns[i].Click();
                        if(i==0)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Transactions present");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Select one transaction failed due to " + e);
                throw e;
            }
        }

    }
}