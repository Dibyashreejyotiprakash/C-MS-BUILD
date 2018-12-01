using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.AdminSite;
using NUnit.Framework;
using CHREnhancements.Utility.TestdataUtilities;

namespace CHREnhancements.Tests.June2018.IP_003
{
    [TestFixture]
    [Parallelizable, Category("Enhancements")]
    public class _7953_CHR_1792_AdminScreenToManageBannedWordsPhrases : Base
    {
        Interactions action;
        LoginPage loginpage;
        AdminSiteHomePage adminhomepage;
        BannedWordPhrasesPage bannedworphrase;
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void ManageBannedWords(string browsername)
        {
            BrowserSetUp(browsername);
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            adminhomepage = new AdminSiteHomePage(Driver);
            bannedworphrase = new BannedWordPhrasesPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.adminurl);
                adminhomepage.ClickOnBannedPhrases();
                bannedworphrase.AddNewBannedWord();
            }
            catch(Exception e)
            {
                Console.WriteLine("Manage banned words failed due to " + e);
                Assert.Fail();
            }
        }
    }
}