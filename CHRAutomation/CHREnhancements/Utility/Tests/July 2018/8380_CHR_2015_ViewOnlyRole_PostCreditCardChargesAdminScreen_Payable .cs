using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.AdminSite;
using CHREnhancements.Utility.TestdataUtilities;
using NUnit.Framework;

namespace CHREnhancements.Tests.July_2018
{
    [TestFixture]
    [Parallelizable, Category("Enhancements")]
    public class _8380_CHR_2015_ViewOnlyRole_PostCreditCardChargesAdminScreen_Payable : Base
    {
        Interactions action;
        AdminSiteHomePage adminsitehomepage;
        PostCreditCardPage postcreditcardpage;
        SiteSecurity sitesecuritypage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VerifyViewOnRole(string browsername)
        {
            BrowserSetUp(browsername);
            action = new Interactions(Driver);
            postcreditcardpage = new PostCreditCardPage(Driver);
            adminsitehomepage = new AdminSiteHomePage(Driver);
            sitesecuritypage = new SiteSecurity(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.adminurl);
                action.WaitForPageToLoad();
                adminsitehomepage.ClickOnSiteSecurity();
                action.WaitForPageToLoad();
                sitesecuritypage.Updateuser();
                adminsitehomepage.ClickOnPostCreditCardCharges();
                action.WaitTime(4);
                postcreditcardpage.ClickOnPaidTransaction();

            }
            catch(Exception e)
            {
                Console.WriteLine("Verify View Only Role failed due to " + e);
                Assert.Fail();
            }
        }
    }
}