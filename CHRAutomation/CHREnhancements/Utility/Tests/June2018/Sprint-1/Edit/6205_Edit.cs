using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.PageObject.InstantImpact.CreateDesign;
using CHREnhancements.PageObject.InstantImpact.ItemSearchPage;
using NUnit.Framework;
using CHREnhancements.Utility.TestdataUtilities;
using System;

namespace CHREnhancements.Tests.June2018.Sprint_1.Edit
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _6205_Edit : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homePage;
        ProjectsPage projectspage;
        CreateDesignPage createdesignpage;
        POS_On_Demand posondemand;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void EditTemplate(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homePage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            posondemand = new POS_On_Demand(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homePage.ClickOnPosOnDemand();
                action.WaitForPageToLoad();
                posondemand.SelectTemplate(Testdata.templateid);
                posondemand.ClickOnCreateYourDesign();
                createdesignpage.VerifyPreviewChanges();
                createdesignpage.VerifySaveDesign(Testdata.templatename);
                createdesignpage.navigateToWorkCenterFromCreateDesinPage();
                action.WaitForPageToLoad();
                projectspage.ClickOnEdit();
                createdesignpage.VerifyPreviewChanges();
                createdesignpage.VerifyViewProof();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Edit template failed due to " + e);
                Assert.Fail();
            }
        }
    }
}