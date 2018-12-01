using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.Home;
using CHREnhancements.Utility.TestdataUtilities;
using CHREnhancements.PageObject.InstantImpact.ItemSearchPage;
using CHREnhancements.PageObject.InstantImpact.Projects;
using NUnit.Framework;


namespace CHREnhancements.Tests.July_2018
{
    [TestFixture]
    [Parallelizable, Category("Enhancements")]
    public class _8369_CHR_2037_IIv4SearchOnlySearchingFirstWordTextSearch : Base
    {
        Interactions action;
        LoginPage loginpage;
        HomePage homepage;
        ProjectsPage projectspage;
        POS_On_Demand posondemand;
        [Test]
        public void SearchingWithFirstWord()
        {
            BrowserSetUp();
            loginpage = new LoginPage(Driver);
            homepage = new HomePage(Driver);
            action = new Interactions(Driver);
            posondemand = new POS_On_Demand(Driver);
            projectspage = new ProjectsPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.url);
                loginpage.LoginToApplication(Testdata.username,Testdata.password);
                projectspage.ClickOnPosOnDemand();
                posondemand.VerifySearch();
            }
            catch(Exception e)
            {
                Console.WriteLine("Searching With First Word failed due to " + e);
                Assert.Fail();
            }
        }
    }
}