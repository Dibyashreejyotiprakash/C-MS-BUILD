using System;
using NUnit.Framework;
using CHREnhancements.Initiate;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Projects;
using CHREnhancements.PageObject.InstantImpact.ClientSpecificLandingPage;
using CHREnhancements.Utility.TestdataUtilities;
using System.IO;
using System.Reflection;

namespace CHREnhancements.Tests.June2018.Sprint_1.Delete
{
    [TestFixture]
    [Parallelizable,Category("IIEnhancements")]

    public class _6198_SingleDelete : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homePage;
        ProjectsPage projectspage;
        SelectCorporateDistributionPage corpdistpage;
        Testdata testdata;
        [Test]
        public void SingleDelete()
        {
           BrowserSetUp();
            loginpage = new LoginPage(Driver);
            testdata = new Testdata();
            action = new Interactions(Driver);
            homePage = new HomePage(Driver);
            corpdistpage = new SelectCorporateDistributionPage(Driver);
            projectspage = new ProjectsPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                GetUrl("INSTANTIMPACT");
                loginpage.LoginToApplication(Testdata.username, Testdata.password);
                action.WaitForPageToLoad();
                homePage.VerifyHomePage();
                projectspage.DeleteSingleTemplate();
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(path, "download.jpeg");
                Console.WriteLine(filePath);
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Sigle delete failed due to " + e);
                Assert.Fail();
            }
        }

    }
}