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
    public class _8363_CHR_1440_AbilityToRefundTransactionsFromCreditCardAdmin : Base
    {
        Interactions action;
        AdminSiteHomePage adminsitehomepage;
        PostCreditCardPage postcreditcardpage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VoidTransaction(string browsername)
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
                postcreditcardpage.ClickOnPaidTransaction();
                postcreditcardpage.SelectOneTransaction();
            }
            catch(Exception e)
            {
                Console.WriteLine("Void Transaction failed due to " + e);
                Assert.Fail();
            }
        }
    }
}