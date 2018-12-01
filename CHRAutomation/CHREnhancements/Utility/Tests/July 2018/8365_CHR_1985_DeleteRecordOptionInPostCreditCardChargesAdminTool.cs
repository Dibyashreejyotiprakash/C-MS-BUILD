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
    public class _8365_CHR_1985_DeleteRecordOptionInPostCreditCardChargesAdminTool : Base
    {
        Interactions action;
        AdminSiteHomePage adminsitehomepage;
        PostCreditCardPage postcreditcardpage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void DeleteRecords(string browsername)
        {
            BrowserSetUp(browsername);
            action = new Interactions(Driver);
            postcreditcardpage = new PostCreditCardPage(Driver);
            adminsitehomepage = new AdminSiteHomePage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.adminurl);
                action.WaitForPageToLoad();
                adminsitehomepage.ClickOnPostCreditCardCharges();
                action.WaitForPageToLoad();
                postcreditcardpage.VerifyPostCreditCardPage();
                postcreditcardpage.ClickOnShowPayableTransaction();
                action.WaitTime(5);
                postcreditcardpage.SelectOneTransaction();

            }
            catch(Exception e)
            {
                Console.WriteLine("Searching With First Word failed due to " + e);
                Assert.Fail();
            }
        }
    }
}