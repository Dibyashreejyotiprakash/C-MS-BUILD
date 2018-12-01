using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.AdminSite;
using CHREnhancements.Utility.TestdataUtilities;
using NUnit.Framework;

namespace CHREnhancements.Tests.June2018.IP_006
{
    [TestFixture]
    [Parallelizable, Category("Enhancements")]
    public class _8150_CHR_952_DisassociateFulfillmentItems : Base
    {
        Interactions action;
        AdminSiteHomePage adminsitehomepage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VerifyDisassociateFulfillmentItem(string browsername)
        {
            BrowserSetUp(browsername);
            action = new Interactions(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.adminurl);
                adminsitehomepage.ClickOnFulfillmentSearch();
                adminsitehomepage.SelectCorporationFromDropDown();
                adminsitehomepage.ClickOnSearch();
                adminsitehomepage.ClickOnEditForDisassociation();
                adminsitehomepage.ClickOnEditFromSkuGrid();
                adminsitehomepage.DisassociateSku();
                adminsitehomepage.ClickOnUpdate();
                adminsitehomepage.CaptureSku();
                adminsitehomepage.ClickOnFulfillmentSearch();
                adminsitehomepage.VerifyDisassociatedItem();
            }
            catch(Exception e)
            {
                Console.WriteLine("Disassocitaing Item failed due to " + e);
                Assert.Fail();
            }
        }
    }
}