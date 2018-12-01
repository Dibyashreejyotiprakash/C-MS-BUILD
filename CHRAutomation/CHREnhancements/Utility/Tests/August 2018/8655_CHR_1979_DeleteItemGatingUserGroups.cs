using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.AdminSite;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.BMAdmin;
using NUnit.Framework;

namespace CHREnhancements.Tests.August_2018
{
    [TestFixture]
    [Parallelizable, Category("Enhancements")]
    public class _8655_CHR_1979_DeleteItemGatingUserGroups : Base
    {
        Interactions action;
        AdminSiteHomePage adminsitehomepage;
        ItemGatingUserGroup itemgatingusergrp;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void VerifyDeleteItemGatingUserGroups(string browsername)
        {
            BrowserSetUp(browsername);
            action = new Interactions(Driver);
            adminsitehomepage = new AdminSiteHomePage(Driver);
            itemgatingusergrp = new ItemGatingUserGroup(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.adminurl);
                //adminsitehomepage.ClickOnStandardItemGating();
                //itemgatingusergrp.CreateNewUserGroup();
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Delete Item Gating User Groups failed due to " + e);
                Assert.Fail();
            }
        }
    }
}