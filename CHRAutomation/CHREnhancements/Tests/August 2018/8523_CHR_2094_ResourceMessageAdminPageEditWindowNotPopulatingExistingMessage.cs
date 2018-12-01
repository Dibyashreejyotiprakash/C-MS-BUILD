using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.InstantImpact.AdminSite;
using CHREnhancements.PageObject.BMAdmin;
using NUnit.Framework;

namespace CHREnhancements.Tests.August_2018
{
    [TestFixture]
    [Parallelizable,Category("Enhancements")]
    public class _8523_CHR_2094_ResourceMessageAdminPageEditWindowNotPopulatingExistingMessage : Base
    {
        Interactions action;
        AdminSiteHomePage adminsitehomepage;
        ResourceMessagePage resourcemsgpage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VerifyExstingOverrideMssagePopulating()
        {
            BrowserSetUp();
            action = new Interactions(Driver);
            adminsitehomepage = new AdminSiteHomePage(Driver);
            resourcemsgpage = new ResourceMessagePage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.adminurl);
                adminsitehomepage.ClickOnResourcesMessage();
                resourcemsgpage.VerifyPrepopulationOfOverrideMessage(Testdata.corporattionname, Testdata.distributorname);
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Exsting Override Mssage Populating failed due to " + e);
                Assert.Fail();
            }
        }
    }
}