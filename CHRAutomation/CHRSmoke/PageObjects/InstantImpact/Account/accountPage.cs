using System;
using CHRSmoke.Initiate;
using CHRSmoke.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using CHRSmoke.PageObjects.InstantImpact.ShoppingCart;
using CHRSmoke.PageObjects.InstantImpact.Home;
using CHRSmoke.PageObjects.InstantImpact.PosOnDemand;
using CHRSmoke.PageObjects.InstantImpact.ItemConfiguration;
using CHRSmoke.PageObjects.InstantImpact.ProductSelection;
using System.Collections.Generic;
using NUnit.Framework;

namespace CHRSmoke.PageObjects.InstantImpact.Account
{
    public class AccountPage : Base
    {
        public By lnkAccount { get { return By.XPath("//a[@href='/Account/MyAccountPage.aspx']"); } }
        public By lnkViewProfile { get { return By.XPath("//a[@href='Profile.aspx']"); } }
        public By ddlCreditCard { get { return By.XPath("//select[@id='CustomerCreditCardID']"); } }
        public By ddlCreditCardOptions { get { return By.XPath("//*[@id='CustomerCreditCardID']/option"); } }
        public By lnkAddCreditCard { get { return By.XPath("//a[@id='lnkShowAddCreditCard']"); } }
        public By txbCardnumber { get { return By.XPath("//input[@id='NewCustomerCreditCard_CardNumber']"); } }
        public By txbSecurityCode { get { return By.XPath("//input[@id='NewCustomerCreditCard_SecurityCode']"); } }
        public By ddlExpirationMonth { get { return By.XPath("//select[@id='NewCustomerCreditCard_ExpirationMonth']"); } }
        public By ddlExpirationYear { get { return By.XPath("//select[@id='NewCustomerCreditCard_ExpirationYear']"); } }
        public By btnEnterCard { get { return By.XPath("//input[@value='Enter Card']"); } }
        public By imgLoading { get { return By.XPath("//img[@src='/Content/Images/loading.gif']"); } }
        public By lblCreditCardHeader { get { return By.XPath("//*[text()='Credit Card Information']"); } }
        public By lstPrimaryMenu { get { return By.XPath("//div[@id='ctl00_RadMenu1']/ul/li/a/span[1]"); } }
        public By btnDelete { get { return By.XPath("//*[@value='Delete']"); } }



















        Interactions action;
        ShoppingCartPage shoppingcartpage;
        HomePage homepage;
        ItemSearchPage itemsearchpage;
        CreateDesignPage createdesignpage;
        ProductSelectionPage productselectionpage;
        
        public AccountPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            action = new Interactions(Driver);
            PageFactory.InitElements(Driver, this);
            homepage = new HomePage(Driver);
            shoppingcartpage = new ShoppingCartPage(Driver);
            itemsearchpage = new ItemSearchPage(Driver);
            createdesignpage = new CreateDesignPage(Driver);
            productselectionpage = new ProductSelectionPage(Driver);
            

        }
        //Set  credit card
        public void SetCreditCard()
        {
            try
            {
                action.WaitVisible(lnkAccount,300);
                createdesignpage.ClickOnAccountLink();
                action.WaitForPageToLoad();
                action.WaitVisible(lnkViewProfile);
                action.Click(lnkViewProfile);
                action.WaitWhileNotVisible(imgLoading);
                try
                {
                    action.ScrollToViewElement(lblCreditCardHeader);
                    action.WaitTime(5);
                    bool statusofcreditcarddropdown = action.IsElementDisplayed(ddlCreditCard);
                    if (statusofcreditcarddropdown == true)
                    {
                        action.WaitWhileNotVisible(imgLoading);                 
                        action.Click(ddlCreditCard);
                        action.WaitVisible(ddlCreditCard, 300);
                        IList<string> creditcardvalues = action.GetAllOptions(ddlCreditCard);
                        for (int i = 0; i < creditcardvalues.Count; i++)
                        {
                            List<string> allvalues = new List<string>();                           
                            Console.WriteLine("Credit card valiues " + creditcardvalues[i].ToString());
                            allvalues.Add(creditcardvalues[i].ToString().Trim());
                            for (int j = 0; j < allvalues.Count; j++)
                            {
                                if (allvalues[j].Contains("4242"))
                                {
                                    action.WaitVisible(ddlCreditCard,300);
                                    action.SelectByText(ddlCreditCard, "4242");
                                    action.WaitVisible(btnDelete);
                                }

                            }
                        }
                    }
                    else
                    {
                        action.WaitVisible(lnkAddCreditCard, 300);
                        action.Click(lnkAddCreditCard);
                        action.WaitVisible(btnEnterCard);
                        action.ScrollToViewElement(txbCardnumber);
                        action.WaitVisible(txbCardnumber, 300);
                        action.Type(txbCardnumber, "4242424242424242");
                        action.WaitVisible(txbSecurityCode, 300);
                        action.Type(txbSecurityCode, "123");
                        action.WaitVisible(ddlExpirationMonth);
                        action.ScrollToViewElement(ddlExpirationMonth);
                        action.SelectByText(ddlExpirationMonth, "12");
                        action.WaitVisible(ddlExpirationYear);
                        action.SelectByText(ddlExpirationYear, "2024");
                        action.WaitVisible(btnEnterCard);
                        action.ScrollToViewElement(btnEnterCard);
                        action.WaitVisible(btnEnterCard);
                        action.Click(btnEnterCard);
                        action.WaitForPageToLoad();
                        action.WaitWhileNotVisible(imgLoading);
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine("Set Credit Card failed due to " + e);
                    throw e;
                }






































                // bool statusofcreditcarddropdown = action.IsElementDisplayed(ddlCreditCard);
                //    if (statusofcreditcarddropdown == true)
                //    {
                //        action.WaitWhileNotVisible(imgLoading);
                //       // action.WaitTime(5);
                //        //action.ScrollToBottomOfPage();


                //        action.Click(ddlCreditCard);
                //        //action.WaitTime(5);
                //        IList<IWebElement> creditcardvalue = action.GetElements(ddlCreditCardOptions);

                //        for (int i = 0; i < creditcardvalue.Count; i++)
                //        {
                //            string values = creditcardvalue[i].Text.ToString();

                //            List<string> value = new List<string>();
                //            value.Add(values);

                //            for (int j = 0; j < value.Count; j++)
                //            {
                //                if (value[j].Contains("4242"))
                //                {
                //                    action.SelectByText(ddlCreditCard, "4242 ");
                //                    action.WaitTime(5);
                //                    string selectedvalue=action.GetSelectedOption(ddlCreditCard);
                //                    Console.WriteLine("selectedvalue");
                //                    action.WaitTime(10);
                //                    action.ScrollToBottomOfPage();
                //                    action.WaitTime(5);
                //                }

                //            }



                //        }
                //    }
                //    else
                //    {
                //        action.WaitVisible(lnkAddCreditCard);
                //        action.Click(lnkAddCreditCard);
                //        action.WaitTime(2);
                //        action.ScrollToViewElement(txbCardnumber);
                //        action.Type(txbCardnumber, "4242424242424242");
                //        action.Type(txbSecurityCode, "123");
                //        action.WaitTime(2);
                //        action.ScrollToViewElement(ddlExpirationMonth);
                //        action.WaitVisible(ddlExpirationMonth);
                //        action.SelectByText(ddlExpirationMonth, "12");
                //        action.WaitTime(2);
                //        action.SelectByText(ddlExpirationYear, "2024");
                //        action.WaitTime(2);
                //        action.ScrollToViewElement(btnEnterCard);
                //        action.WaitTime(2);
                //        action.Click(btnEnterCard);
                //        action.WaitForPageToLoad();
                //        action.WaitWhileNotVisible(imgLoading);
                //        // action.WaitTime(5);

                //    }
                //    //action.ClickAndWait(ddlCreditCard, 2);
                //    //action.SelectByIndex(ddlCreditCardOptions, 2);
                //    //action.Click(lstPrimaryMenu, 2);

                //}
                //catch (Exception e)
                //{

                //    // action.WaitVisible(lnkAddCreditCard);
                //    // action.Click(lnkAddCreditCard);
                //    // action.WaitTime(2);
                //    // action.ScrollToViewElement(txbCardnumber);
                //    // action.Type(txbCardnumber, "4242424242424242");
                //    // action.Type(txbSecurityCode, "123");
                //    // action.WaitTime(2);
                //    // action.ScrollToViewElement(ddlExpirationMonth);
                //    // action.WaitVisible(ddlExpirationMonth);
                //    // action.SelectByText(ddlExpirationMonth, "12");
                //    // action.WaitTime(2);
                //    // action.SelectByText(ddlExpirationYear, "2024");
                //    // action.WaitTime(2);
                //    // action.ScrollToViewElement(btnEnterCard);
                //    // action.WaitTime(2);
                //    // action.Click(btnEnterCard);
                //    // action.WaitForPageToLoad();
                //    // action.WaitWhileNotVisible(imgLoading);
                //    //// action.WaitTime(5);
                //    // Console.WriteLine(e);
                //    Console.WriteLine("Select Credit card failed due to " + e);
                //}

            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}