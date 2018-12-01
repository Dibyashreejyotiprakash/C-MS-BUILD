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
    public class IISmokeNonVariableTemplateInvoiceCheckout : Base
    {
        [Test]
        public void SmokeNonVariableTemplateInvoiceCheckout()
        {
            BrowserSetUp();
             Interactions action = new Interactions(Driver);
            LoginPage loginpage = new LoginPage(Driver);
            HomePage homepage = new HomePage(Driver);
            ItemSearchPage itemsearchpage = new ItemSearchPage(Driver);
            CreateDesignPage createdesignpage = new CreateDesignPage(Driver);
            CheckOutPage chekoutpage = new CheckOutPage(Driver);
            OrderFormPage orderformpage = new OrderFormPage(Driver);
            try
            {
                GetUrl("INSTANTIMPACT");
                loginpage.CorporationLogin();
                loginpage.SelectLoginType("Corp Dist.");
                chekoutpage.NonVariableTemplateCheckout();
            }
            catch (Exception e)
            {
                Console.WriteLine("Non Variable Template Invoice Checkout Failed :-" + e);
                Assert.Fail();
            }
        }
    }
}