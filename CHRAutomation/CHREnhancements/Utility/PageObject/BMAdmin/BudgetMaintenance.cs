using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.BMAdmin
{
    public class BudgetMaintenance : Base
    {
        public static By CorporationTextField
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_cbsBudget_rcbCorporation_Input']")); } }

        public static By SearchBtn
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rbSearch_input']")); } }

        public static By BudgetDetailsTable
        { get { return (By.XPath("//*[@id='cphMain_cphMain_pnlBudgetMaintenance']")); } }

        public static By FirstArrow
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rgBudgets_ctl00_ctl04_GECBtnExpandColumn']")); } }

        public static By TableToEdit
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rgBudgets_ctl00_ctl06_Detail10']")); } }

        public static By EditBudgetLevelParent
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rgBudgets_ctl00_ctl06_Detail10_ctl08_EditButton']")); } }

        public static By LevelName
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rgBudgets_ctl00_ctl06_Detail10_ctl09_rtbLevelName']")); } }

        public static By Region
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rgBudgets_ctl00_ctl06_Detail10_ctl09_ddlRegion']")); } }

        public static By DefaultBudgetCheckBox
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rgBudgets_ctl00_ctl06_Detail10_ctl09_cbDefault']")); } }

        public static By HardStopCheckBox
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rgBudgets_ctl00_ctl06_Detail10_ctl09_cbHardStop']")); } }

        public static By UpdateBtn
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rgBudgets_ctl00_ctl06_Detail10_ctl09_rbUpdateBudgetLevel']")); } }

        public static By CancelBtn
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rgBudgets_ctl00_ctl06_Detail10_ctl09_rbCancelBudgetLevel']")); } }

        public static By EditBtnOnSecondParentLevel
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rgBudgets_ctl00_ctl06_Detail10_ctl08_EditButton']")); } }

        public static By LowBudgetAlert
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rgBudgets_ctl00_ctl06_Detail10_ctl09_cbAlert']")); } }





        Interactions action;
        public BudgetMaintenance(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify Budget Maintenance Page
        public void VerifyBudgetMaintenancePage()
        {
            try
            {
                action.VerifyCurrentPage("Budget Maintenance Page", "BudgetMaintenance.aspx");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Budget Maintenance Page failed due to " + e);
                throw e;
            }
        }

        //Search Corporation To Update Budget Maintenance
        public void CorporationSearch()
        {
            try
            {
                action.Type(CorporationTextField, "Republic Distributing");
                action.Click(SearchBtn);
            }
            catch(Exception e)
            {
                Console.WriteLine("Corporation Search failed due to " + e);
                throw e;
            }
        }

        //Update budget details
        public void CheckforBudgetDetailsTable()
        {
            try
            {
                action.WaitVisible(BudgetDetailsTable);
                bool statusofbudgetdetails = action.IsElementDisplayed(BudgetDetailsTable);
                Console.WriteLine("Visibility of Budget Deatils Page is " + statusofbudgetdetails);
                if(statusofbudgetdetails)
                {
                    action.Click(FirstArrow);
                    Console.WriteLine("Clciked on first arrow");
                    action.WaitVisible(TableToEdit);
                    if(action.IsElementDisplayed(TableToEdit))
                    {
                        action.WaitVisible(EditBtnOnSecondParentLevel);
                        action.Click(EditBtnOnSecondParentLevel);
                    }
                }
                else
                {
                    Console.WriteLine("Budget Details are not there");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Update Budget Details failed due to " + e);
                throw e;
            }
        }

        //Update Budget Details
        public void UpdateDefaultBudget()
        {
            try
            {
                IWebElement elelemnt = Driver.FindElement(LevelName);
                string existinglevelnamevalue = elelemnt.GetAttribute("value");
                Console.WriteLine("The existing value of level name is " + existinglevelnamevalue);
                if(action.IsElementSelected(DefaultBudgetCheckBox))
                {
                    Console.WriteLine("Default value is selected previously..");
                    action.Click(DefaultBudgetCheckBox);
                    if(!(action.IsElementSelected(DefaultBudgetCheckBox)))
                    {
                        Console.WriteLine("Default value is unselected..");
                    }
                }
                else if(!(action.IsElementSelected(DefaultBudgetCheckBox)))
                {
                    Console.WriteLine("Default value is not selected");
                    action.Click(DefaultBudgetCheckBox);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Update default budget value failed due to " + e);
                throw e;
            }
        }

        //Update Hard Stop
        public void UpdateHardStop()
        {
            try
            {
                if (action.IsElementSelected(HardStopCheckBox))
                {
                    Console.WriteLine("Hard Stop Check box is selected previously..");
                    action.Click(HardStopCheckBox);
                    if (!(action.IsElementSelected(HardStopCheckBox)))
                    {
                        Console.WriteLine("Hard Stop Check box is unselected..");
                    }
                }
                else if (!(action.IsElementSelected(HardStopCheckBox)))
                {
                    Console.WriteLine("Hard Stop Check box is not selected previously");
                    action.Click(DefaultBudgetCheckBox);
                    Console.WriteLine("Hard Stop Check box is selected");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Update Hard Stop failed due to " + e);
                throw e;
            }
        }

        //Update Hard Stop
        public void UpdateLowBudgetAlert()
        {
            try
            {
                if (action.IsElementSelected(LowBudgetAlert))
                {
                    Console.WriteLine("Low Budget Alert is selected previously..");
                    action.Click(LowBudgetAlert);
                    if (!(action.IsElementSelected(LowBudgetAlert)))
                    {
                        Console.WriteLine("Low Budget check box is unselected..");
                    }
                }
                else if (!(action.IsElementSelected(LowBudgetAlert)))
                {
                    Console.WriteLine("Low budget alert box is not selected previously");
                    action.Click(DefaultBudgetCheckBox);
                    Console.WriteLine("Low budget alert box is selected");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Update Hard Stop failed due to " + e);
                throw e;
            }
        }

        //CLick on Update Button
        public void ClickOnUpadte()
        {
            try
            {
                action.WaitVisible(UpdateBtn);
                action.Click(UpdateBtn);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Update button failed due to " + e);
                throw e;
            }
        }

    }
}