using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.Utility.TestdataUtilities;
using NUnit.Framework;
using CHREnhancements.PageObject.InstantImpact.AdminSite;

namespace CHREnhancements.Tests.June2018.IP_006
{
    [TestFixture]
    [Parallelizable, Category("Enhancements")]
    public class _8147_CHR_954_FulfillmentItemDeactivation : Base
    {
        Interactions action;
        AdminSiteHomePage adminsitehomepage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VerifyFulfillmentDeactivation(string browsername)
        {
            BrowserSetUp(browsername);
            action = new Interactions(Driver);
            adminsitehomepage = new AdminSiteHomePage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.adminurl);
                adminsitehomepage.ClickOnFulfillmentSearch();
                adminsitehomepage.SelectCorporationFromDropDown();
                adminsitehomepage.ClickOnSearch();
                adminsitehomepage.ClickOnEditFromFulfillmentGrid();
                adminsitehomepage.ClickOnEditFromSkuGrid();
                adminsitehomepage.SelectInactiveChkBox();
                adminsitehomepage.ClickOnUpdate();
                adminsitehomepage.VerifyDeactivatedSku();
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify manage banned words in admin failed due to " + e);
                Assert.Fail();
            }
        }
    }
}