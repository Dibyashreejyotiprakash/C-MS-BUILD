using System;
using CHRSmoke.Initiate;
using CHRSmoke.Interaction;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CHRSmoke.PageObjects.InstantImpact.Confirmation
{
    public class ConfirmationPage : Base
    {
        public By lblPlacedOrder { get { return By.XPath("//div[@id='ctl00_Body_radAjaxPanel']/div/h1"); } }
        public By lblConfirmationNumber { get { return By.XPath("//div[@id='ctl00_Body_radAjaxPanel']/div/h3[1]"); } }
        public By LblOrderNumber { get { return By.XPath("//*[@id='Body_lblDtNumber']"); } }

        public By LblConfirmationNumber { get { return By.XPath("//*[@id='Body_lblInvoiceNumber']"); } }
        public ConfirmationPage(IWebDriver Driver)
        {
            this.Driver = Driver;
           // PageFactory.InitElements(Driver, this);
        }

        //get confirmation msg
        public bool IsOrderPlace()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                bool statusofordernumber = action.IsElementDisplayed(LblConfirmationNumber);
                if (statusofordernumber == true)
                {
                    string ordernumber = action.GetText(LblConfirmationNumber);
                    Console.WriteLine("Order Successfully placed with order Number is " + ordernumber);
                }
                else
                {
                    Console.WriteLine("Order process failed.");
                }

                return statusofordernumber;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}