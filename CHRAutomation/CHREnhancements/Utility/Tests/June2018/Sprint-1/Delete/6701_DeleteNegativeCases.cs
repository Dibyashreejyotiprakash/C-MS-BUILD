using System;
using NUnit.Framework;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.Utility.TestdataUtilities;

namespace CHREnhancements.Tests.June2018.Sprint_1.Delete
{
    [TestFixture]
    [Parallelizable, Category("IIEnhancements")]
    public class _6701_DeleteNegativeCases : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homePage;
        ProjectsPage projectspage;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void NegativeCases(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            homePage = new HomePage(Driver);
            projectspage = new ProjectsPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                action.WaitForPageToLoad();
                homePage.VerifyHomePage();
                projectspage.DismissPopupSingleTemplate();
                projectspage.DismissPopupMultipleTemplate();
                projectspage.DismissPopupAllTemplate();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.Write("Negative cases failed due to " + e);
                Assert.Fail();
            }

        }
    }
}
