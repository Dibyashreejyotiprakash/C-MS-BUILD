using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.AdminSite;
using CHREnhancements.Utility.TestdataUtilities;
using NUnit.Framework;

namespace CHREnhancements.Tests.June2018.IP_006
{
    [TestFixture]
    [Parallelizable,Category("Enhancements")]
    public class _8173_CHR_953_DeleteProductUnit : Base
    {
        Interactions action;
        AdminSiteHomePage adminsitehomepage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VerifyDeeleteProductUnit(string browsername)
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
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Delete Product Unit failed due to " + e);
                Assert.Fail();
            }
        }
    }
}