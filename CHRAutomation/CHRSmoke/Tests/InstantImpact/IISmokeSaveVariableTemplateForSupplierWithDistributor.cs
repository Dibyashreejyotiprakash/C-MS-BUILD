using System;
using NUnit.Framework;
using CHRSmoke.Initiate;

using CHRSmoke.Interaction;

using CHRSmoke.PageObjects.InstantImpact.Login;
using CHRSmoke.PageObjects.InstantImpact.Home;
using CHRSmoke.PageObjects.InstantImpact.PosOnDemand;
using CHRSmoke.PageObjects.InstantImpact.ItemConfiguration;
using CHRSmoke.PageObjects.InstantImpact.CheckOut;
using CHRSmoke.PageObjects.InstantImpact.OrderForm;
using CHRSmoke.PageObjects.InstantImpact.Confirmation;


namespace CHRSmoke.Tests.InstantImpact
{
    [TestFixture]
    [Parallelizable, Category("SMOKE")]
    public class IISmokeSaveVariableTemplateForSupplierWithDistributor : Base
    {
        [Test]
        public void SmokeSaveVariableTemplateForSupplierWithDistributor()
        {
            BrowserSetUp();
            Interactions action = new Interactions(Driver);
            LoginPage loginpage = new LoginPage(Driver);
            HomePage homepage = new HomePage(Driver);
            ItemSearchPage itemsearchpage = new ItemSearchPage(Driver);
            OrderFormPage orderformpage = new OrderFormPage(Driver);
            CreateDesignPage createdesignpage = new CreateDesignPage(Driver);
            try
            {
                GetUrl("INSTANTIMPACT");
                loginpage.CorporationLogin();
                loginpage.SelectLoginType("Corp Dist.");
                createdesignpage.SaveAndVarifyVariableTemplate();
            }
            catch (Exception e)
            {
                Console.WriteLine("Save Variable Template  Failed :-" + e);
                Assert.Fail();
            }
        }
    }
}