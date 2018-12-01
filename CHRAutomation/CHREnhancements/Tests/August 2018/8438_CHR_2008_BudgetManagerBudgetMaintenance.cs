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
    public class _8438_CHR_2008_BudgetManagerBudgetMaintenance : Base
    {
        Interactions action;
        AdminSiteHomePage adminsitehomepage;
        BudgetMaintenance budgetmaintenance;
        [Test]
        public void VerifyBudgetMaintenanceUpdate()
        {
            BrowserSetUp();
            action = new Interactions(Driver);
            adminsitehomepage = new AdminSiteHomePage(Driver);
            budgetmaintenance = new BudgetMaintenance(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.adminurl);
                action.WaitForPageToLoad();
                adminsitehomepage.VerifyAdminHomePage();
                adminsitehomepage.ClickOnBudgetMaintenance();
                action.WaitForPageToLoad();
                budgetmaintenance.CorporationSearch();
                budgetmaintenance.CheckforBudgetDetailsTable();
                budgetmaintenance.UpdateDefaultBudget();
                budgetmaintenance.UpdateHardStop();
                budgetmaintenance.ClickOnUpadte();
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Budget Maintenance Update failed due to " + e);
                Assert.Fail();
            }
        }
    }
}