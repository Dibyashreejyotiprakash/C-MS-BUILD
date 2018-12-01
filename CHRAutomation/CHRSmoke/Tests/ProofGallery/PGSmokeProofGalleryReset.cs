using CHRSmoke.PageObjects.ProofGallery.Home;
using CHRSmoke.PageObjects.ProofGallery.Login;
using NUnit.Framework;
using System;
using CHRSmoke.Initiate;
using CHRSmoke.Interaction;
namespace CHRSmoke.Tests.ProofGallery
{
    [TestFixture]
    [Parallelizable, Category("SMOKE")]
    public class PGSmokeProofGalleryReset : Base
    {
        [Test]
        public void SmokeProofGalleryReset()
        {
            BrowserSetUp();
            LoginPage loginpage = new LoginPage(Driver);
            HomePage homepage = new HomePage(Driver);
            Interactions action = new Interactions(Driver);
            try
            {

                GetUrl("PROOFGALLERY");
                loginpage.Login("jcrotty@brandmuscle.com", "password");
                homepage.Logout();
            }
            catch (Exception e)
            {
                Console.WriteLine("Login Failed  :-" + e);
            }
        }
    }
}