using NUnit.Framework;
using System;
using CHREnhancements.Initiate;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.Utility.TestdataUtilities;

namespace CHREnhancements.Tests.June2018.Sprint_1.Delete
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class _6276_DeleteAll : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homePage;
        ProjectsPage projectspage;
        Testdata testdata;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void DeleteAll(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            testdata = new Testdata();
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
                projectspage.DeleteAllTemplates();
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("DeleteAll failed due to " + e);
                Assert.Fail();
            }
        }
    }
}