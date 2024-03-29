﻿using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.PageObject.InstantImpact.ItemSearchPage;
using CHREnhancements.Utility.TestdataUtilities;
using NUnit.Framework;
using CHREnhancements.PageObject.InstantImpact.CreateDesign;

namespace CHREnhancements.Tests.June2018.Sprint_2.Override_Save_design
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _6822_SaveNewDesignName : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        ProjectsPage projectspage;
        CreateDesignPage createdesignpage;
        POS_On_Demand posondemand;
        [Test]
        public void SaveNewDeisgnFromEdit()
        {
            BrowserSetUp();
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homepage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            posondemand = new POS_On_Demand(Driver);
            try
            {
                Testdata.DatabaseValues();
                GetUrl("INSTANTIMPACT");
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homepage.ClickOnPosOnDemand();
                action.WaitForPageToLoad();
                posondemand.SelectTemplate(Testdata.templateid);
                posondemand.ClickOnCreateYourDesign();
                createdesignpage.VerifyPreviewChanges();
                createdesignpage.VerifySaveDesign(Testdata.templatename);
                createdesignpage.VerifyConfirmationMsg();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Save new deisgn from edit failed due to " + e);
                Assert.Fail();
            }
        }
    }
}