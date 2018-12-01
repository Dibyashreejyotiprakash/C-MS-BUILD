using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.InstantImpact.AdminSite;
using CHREnhancements.PageObject.BMAdmin;
using OpenQA.Selenium;
using NUnit.Framework;

namespace CHREnhancements.Tests.August_2018
{
    [TestFixture]
    [Parallelizable, Category("Enhancements")]
    public class _8436_CHR_2009_BudgetManagerDistributorBudgetSetup : Base
    {
        AdminSiteHomePage adminsitehomepage;
        BudgetManager_DistributorBudgetSetup budgetdistributormanager;
        Interactions action;
        [Test]
        public void VerifyDistributedBudgetSetup()
        {
            BrowserSetUp();
            adminsitehomepage = new AdminSiteHomePage(Driver);
            budgetdistributormanager = new BudgetManager_DistributorBudgetSetup(Driver);
            action = new Interactions(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.adminurl);
                action.WaitForPageToLoad();
                adminsitehomepage.VerifyAdminHomePage();
                adminsitehomepage.ClickOnDisrtibutorBudgetSetup();
                action.WaitForPageToLoad();
                budgetdistributormanager.VerifyDistributorBudgetSetUp();
                budgetdistributormanager.SubmitDistributorBudgetSetUp("44 - Diageo","Test@123","125436","10/12/2018","10/13/2018","100000","320000");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Distributed Budget Setup failed due to " + e);
                Assert.Fail();
            }
        }
    }
}