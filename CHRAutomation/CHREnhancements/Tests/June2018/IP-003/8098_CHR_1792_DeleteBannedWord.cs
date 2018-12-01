using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using CHREnhancements.PageObject.InstantImpact.Login;
using CHREnhancements.PageObject.InstantImpact.AdminSite;
using CHREnhancements.Utility.TestdataUtilities;
using NUnit.Framework;

namespace CHREnhancements.Tests.June2018.IP_003
{
    [TestFixture]
    [Parallelizable, Category("Enhancements")]
    public class _8098_CHR_1792_DeleteBannedWord : Base
    {
        Interactions action;
        LoginPage loginpage;
        AdminSiteHomePage adminhomepage;
        BannedWordPhrasesPage bannedworphrasepage;
        [Test]
        public void DeleteBannedWord()
        {
            BrowserSetUp();
            loginpage = new LoginPage(Driver);
            action = new Interactions(Driver);
            adminhomepage = new AdminSiteHomePage(Driver);
            bannedworphrasepage = new BannedWordPhrasesPage(Driver);
            try
            {
                Testdata.DatabaseValues();
                action.GoToURL(Testdata.adminurl);
                adminhomepage.ClickOnBannedPhrases();
                bannedworphrasepage.AddNewBannedWord();
                bannedworphrasepage.VerifyBannedWordAddedSuccessfully();
                bannedworphrasepage.DeleteBannedWord();
            }
            catch(Exception e)
            {
                Console.WriteLine("Delete banned words failed due to " + e);
                Assert.Fail();
            }
        }
    }
}