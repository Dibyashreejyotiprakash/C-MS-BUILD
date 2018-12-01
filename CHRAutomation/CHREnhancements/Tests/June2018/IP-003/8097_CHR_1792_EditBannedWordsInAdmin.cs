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
    public class _8097_CHR_1792_EditBannedWordsInAdmin : Base
    {
        Interactions action;
        LoginPage loginpage;
        AdminSiteHomePage adminhomepage;
        BannedWordPhrasesPage bannedworphrasepage;
        [Test]
        public void EditBannedWords()
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
                bannedworphrasepage.ClickOnEdit();
            }
            catch(Exception e)
            {
                Console.WriteLine("Edit banned words failed due to " + e);
                Assert.Fail();
            }
        }
    }
}