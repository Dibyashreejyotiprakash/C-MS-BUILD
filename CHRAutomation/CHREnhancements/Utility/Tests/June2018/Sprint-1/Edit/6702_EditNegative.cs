using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.PageObject.InstantImpact.CreateDesign;
using NUnit.Framework;
using CHREnhancements.Utility.TestdataUtilities;
using System;

namespace CHREnhancements.Tests.June2018.Sprint_1.Edit
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _6702_EditNegative : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homePage;
        ProjectsPage projectspage;
        CreateDesignPage createdesignpage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void CancelCreateDesign(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homePage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                homePage.VerifyHomePage();
                projectspage.ClickOnEdit();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cancel create design failed due to " + e);
                Assert.Fail();
            }
        }
    }
}