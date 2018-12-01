using System;
using NUnit.Framework;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.InstantImpact.AdminSite;
using CHREnhancements.PageObject.BMAdmin;

namespace CHREnhancements.Tests.August_2018
{
    [TestFixture]
    [Parallelizable,Category("Enhancements")]
    public class _8505_CHR_2031_ResourceMessageAdminToolRemoveOverrideText : Base
    {
        Interactions action;
        AdminSiteHomePage adminsitehomepage;
        ResourceMessagePage resourcesmessagepage;
        [Test]
        public void VerifyRemoveOverrideText()
        {
            BrowserSetUp();
            action = new Interactions(Driver);
            adminsitehomepage = new AdminSiteHomePage(Driver);
            resourcesmessagepage = new ResourceMessagePage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.adminurl);
                adminsitehomepage.ClickOnResourcesMessage();
                resourcesmessagepage.VerifyResourceMessagePage();
                resourcesmessagepage.UpdateResorceMessage(Testdata.corporattionname,Testdata.distributorname);
                resourcesmessagepage.DeleteResourceMessage();
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Remove Override Text failed due to " + e);
                Assert.Fail();
            }
        }
    }
}