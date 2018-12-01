using System;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace CHREnhancements.PageObject.InstantImpact.Shopping_Cart
{
    class ShoppingCartPage : Base
    {
        public static By ShoppingCartHeader
        { get { return (By.XPath("//*[@id='shopCartHeader']")); } }

        public static By ReflectedTemplateIdInShoppingCart
        { get { return (By.XPath("//*[contains(text(),'Template #')]")); } }

        public static By ClearAll
        { get { return (By.XPath("//*[@id='Body_lnkDeleteAll']")); } }

        public static By RemoveOne
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_delLineItemBtn']")); } }

        public static By YesFromRemove
        { get { return (By.XPath("//*[@class='boxes']/a[1]")); } }

        public static By VerifyEmptyCartHeader
        { get { return (By.XPath("//*[text()='Your shopping cart is empty ']")); } }

        public static By YesFromClearAll
        { get { return (By.XPath("//*[@class='confirmInnerBox']/div[2]/a[1]")); } }

        public static By ShoppingCartCounter
        { get { return (By.XPath("//*[@id='ctl00_Body_ctl00_lblNumberOfCartItemsPanel']/span")); } }

        public static By ListOfItemsInShoppingCart
        { get { return (By.XPath("//*[@class='leftTopAlign shopCartTableBorder templateColumnWidth']")); } }

        public static By ShoppingCartImage
        { get { return (By.XPath("//*[@class='cartImage']")); } }

        public static By EditInShoppingCart
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_editItemDesignLink']")); } }

        public static By AddressDopdown
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_addComboBox_Arrow']")); } }

        public static By Address
        { get { return (By.XPath("//*[@class='rcbList']/li[text()='Chad Mease, Diageo - 727 Normandy Euless, TX 76039 - USA'][1]")); } }

        public static By UseAnotherAddress
        { get { return (By.XPath("//*[text()='Use another address'][1]")); } }

        public static By CompanyName
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_ucAB_addBookCompName']")); } }

        public static By FirstName
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_ucAB_addBookFirstName']")); } }

        public static By LastName
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_ucAB_addBookLastName']")); } }

        public static By City
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_ucAB_addBookCity']")); } }

        public static By Address1
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_ucAB_addBookStrAdd']")); } }

        public static By Address2
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_ucAB_addBookStrAdd2']")); } }

        public static By States
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_ucAB_ddlState_Arrow']")); } }

        public static By Country
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_ucAB_ddlCountry_Arrow']")); } }

        public static By SelectCountry
        { get { return (By.XPath("//*[@class='rcbList']/li[text()='United States                           ']")); } }

        public static By PostalCode
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_ucAB_addBookZip']")); } }

        public static By SelectStates
        { get { return (By.XPath("//*[@class='rcbList']/li[contains(text(),'*International                          ')]")); } }

        public static By UseThisAddress
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_ucAB_addBookSaveAdd']")); } }

        public static By SearchFieldInHeader
        { get { return (By.XPath("//*[@id='txtSearch']")); } }

        public static By Account
        { get { return (By.XPath("//*[@href='/Account/MyAccountPage.aspx']")); } }

        public static By RushRequestLebel
        { get { return (By.XPath("//*[@class='rbText rbToggleCheckboxChecked']")); } }

        public static By RushRequest
        { get { return (By.XPath("//*[@id='ctl00_Body_chkRush_ClientState']")); } }

        public static By CheckOut
        { get { return (By.XPath("//*[@id='ctl00_Body_bottomContToCheckOutBtn']")); } }

        public static By UserAnotherAddress
        { get { return (By.XPath("//*[@id='ctl00_Body_shopCartItemsListView_ctrl0_anotherAddLink']")); } }

        public static By ContinueToCheckOut
        { get { return (By.XPath("//*[@id='ctl00_Body_sideContToCheckOutBtn']")); } }

        Interactions action;
        public ShoppingCartPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }


        public void VerifyShoppingCartPage()
        {
            try
            {
                action.WaitVisible(ShoppingCartHeader);
                bool status_of_header = action.IsElementDisplayed(ShoppingCartHeader);
                Console.WriteLine("Status of Shopping Cart Header is " + status_of_header);
                action.WaitVisible(ShoppingCartImage);
                bool status_of_catrt = action.IsElementDisplayed(ShoppingCartImage);
                Console.WriteLine("Status of Cart image is " + status_of_catrt);
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Shopping Cart Page failed due to: " + e);
                throw e;
            }
        }

        //Click on Accounts
        public void ClickOnAccounts()
        {
            try
            {
                action.Click(Account);
            }
            catch (Exception e)
            {
                Console.WriteLine("Navigate from acconts to projects failed due to : " + e);
                throw e;
            }
        }

        //Verify seach Field
        public void VerifySeachFiled()
        {
            try
            {
                action.WaitVisible(SearchFieldInHeader);
                bool status = action.IsElementDisplayed(SearchFieldInHeader);
                Console.WriteLine("Status of search field is in Shopping Cart page " + status);
                Assert.IsTrue(status);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Search Field failed due to: " + e);
                throw e;
            }
        }

        //Verify Template-Id in Shopping Cart page...
        public void VerifyTemplateIdInShoppingCartPage(string original_templateid)
        {
            try
            {
                string templateid_in_shoppingcartpage = action.GetText(ReflectedTemplateIdInShoppingCart);
                Console.WriteLine("Template id is in ShoppingCart Page " + templateid_in_shoppingcartpage);
                string only_id = templateid_in_shoppingcartpage.Substring(12);
                Console.WriteLine("Only Template id is in ShoppingCart Page " + only_id);
                bool match = original_templateid.Contains(only_id);
                Console.WriteLine("Status of matching two id is " + match);
                Assert.IsTrue(match);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Template Id In Shopping Cart Page failed due to : " + e);
                throw e;
            }
        }

        //Click on Clear All Items
        public void RemoveAllItems()
        {
            try
            {
                action.WaitVisible(ClearAll);
                action.Click(ClearAll);
                action.WaitVisible(YesFromClearAll);
                action.Click(YesFromClearAll);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Clear all failed due to : " + e);
                throw e;
            }
        }

        //Verify All Items are claerd
        public void VerifyEmptyCart()
        {
            try
            {
                bool status = action.IsElementDisplayed(VerifyEmptyCartHeader);
                if(status)
                {
                    Console.WriteLine("The message in emplty cart is " + action.GetText(VerifyEmptyCartHeader));
                }
                else
                {
                    Console.WriteLine("The message is not visible");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify empty cart failed due to : " + e);
                throw e;
            }
        }

        //Remove Sigle item
        public void RemoveOneItem()
        {
            try
            {
                action.WaitVisible(RemoveOne);
                action.Click(RemoveOne);
                action.WaitVisible(YesFromRemove);
                action.Click(YesFromRemove);
            }
            catch(Exception e)
            {
                Console.WriteLine("Remove one item failed due to : " + e);
                throw e;
            }
        }

        //Click on Edit in Shopping Cart page
        public void ClickOnEditInShoppingCart()
        {
            try
            {
                action.WaitVisible(EditInShoppingCart);
                action.Click(EditInShoppingCart);
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Edit in Shopping Cart failed due to : " + e);
                throw e;
            }
        }

        //Verify Number of Items present in cart should be same as in the shopping cart counter
        public void VerifyListOfItemWithShoppingCart()
        {
            try
            {
                action.WaitVisible(ListOfItemsInShoppingCart);
                IList<IWebElement> totalitems = action.GetElements(ListOfItemsInShoppingCart);
                Console.WriteLine("Total number of items present in shopping cart page is "+ totalitems.Count);
                string actual_totalitems = totalitems.ToString();
                action.WaitVisible(ShoppingCartCounter);
                string counter = action.GetText(ShoppingCartCounter);
                Console.WriteLine("Number of items present in cart is " + counter);
                int real_counter = Int32.Parse(counter);
                Console.WriteLine("Real counter in shopping cart image is " + real_counter);
                if(real_counter>=0)
                {
                    Console.WriteLine("Items quantity is shopping cart is not negative and meets requirements.");
                }
                else
                {
                    Console.WriteLine("Items quantity is shopping cart is negative and does not meet requirements.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify list of item with shopping cart failed due to : " + e);
                throw e;
            }
        }

        //Click on Another Address
        public void ClickOnUseAnotherAddress()
        {
            try
            {
                action.WaitVisible(UseAnotherAddress);
                action.Click(UseAnotherAddress);
                action.WaitVisible(CompanyName);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Use Another Address failed due to " + e);
                throw e;
            }
        }

        //Vreify Max Length In Shopping cart page
        public void VerifyMaxInputsToTextFields()
        {
            try
            {
                //Give Company Name
                action.WaitVisible(CompanyName);
                string companyname = action.StringGenerator(100);
                action.Type(CompanyName,companyname);
                int lenghth_of_companyname = companyname.Length;
                Assert.AreEqual(100, lenghth_of_companyname);
                Console.WriteLine("Maximum field length for Company Name meets requirement..");

                //Give First Name
                action.WaitVisible(FirstName);
                string firstname = action.StringGenerator(50);
                action.Type(FirstName,firstname);
                int lenghth_of_firstname = firstname.Length;
                Assert.AreEqual(100, lenghth_of_firstname);
                Console.WriteLine("Maximum field length for First Name meets requirement..");

                //Give Last Name
                action.WaitVisible(LastName);
                string lastname = action.StringGenerator(50);
                action.Type(LastName,lastname);
                int lenghth_of_lastname = lastname.Length;
                Assert.AreEqual(100, lenghth_of_lastname);
                Console.WriteLine("Maximum field length for Last Name meets requirement..");

                //Give Address1
                action.WaitVisible(Address1);
                string address1= action.StringGenerator(70);
                action.Type(Address1,address1);
                int lenghth_of_address1 = address1.Length;
                Assert.AreEqual(100, lenghth_of_address1);
                Console.WriteLine("Maximum field length for Address1 meets requirement..");

                //Give Address2
                action.WaitVisible(Address2);
                string address2 = action.StringGenerator(70);
                action.Type(Address2,address2);
                int lenghth_of_address2 = address2.Length;
                Assert.AreEqual(100, lenghth_of_address2);
                Console.WriteLine("Maximum field length for Address2 meets requirement..");

                //Give City Name
                action.WaitVisible(City);
                string cityname = action.StringGenerator(50);
                action.Type(City,cityname);
                int lenghth_of_cityname = cityname.Length;
                Assert.AreEqual(100, lenghth_of_cityname);
                Console.WriteLine("Maximum field length for City name meets requirement..");

                //Give Postal Code
                action.WaitVisible(PostalCode);
                string postalcode = action.StringGenerator(10);
                action.Type(PostalCode,postalcode);
                int lenghth_of_postalcode = postalcode.Length;
                Assert.AreEqual(100, lenghth_of_postalcode);
                Console.WriteLine("Maximum field length for Posatl code meets requirement..");

            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Max Inputs To Text Fields failed due to " + e);
                throw e;
            }
        }

        //Select   State
        public void VerifymaxLengthForStateCountry()
        {
            try
            {
                //Select States
                action.WaitVisible(States);
                action.Click(States);
                action.WaitVisible(SelectStates);
                action.Click(SelectStates);


                //Select Country
                action.WaitVisible(Country);
                action.Click(Country);
                action.WaitVisible(SelectCountry);
                action.Click(SelectCountry);
            }
            catch(Exception e)
            {
                Console.WriteLine("Select States failed due to " + e);
                throw e;
            }
        }

        //Click on Use This Address
        public void ClickOnUseThisAddress()
        {
            try
            {
                action.WaitVisible(UseThisAddress);
                action.Click(UseThisAddress);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Use this address failed due to " + e);
                throw e;
            }
        }

        //Check the Rush Request check box
        public void ClickOnRushRequest()
        {
            try
            {
                action.ScrollToViewElement(CheckOut);
                action.WaitVisible(RushRequest);
                action.Click(RushRequest);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Rush Request failed due to " + e);
                throw e;
            }
        }

        //Click on CheckOut
        public void ClickOnCheckOut()
        {
            try
            {
                action.ScrollToViewElement(CheckOut);
                action.WaitVisible(CheckOut);
                action.Click(CheckOut);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Checkout failed due to " + e);
                throw e;
            }
        }
    }
}
