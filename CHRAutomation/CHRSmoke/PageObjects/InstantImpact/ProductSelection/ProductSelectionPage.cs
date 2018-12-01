using System;
using System.Collections.Generic;
using CHRSmoke.Initiate;
using CHRSmoke.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CHRSmoke.PageObjects.InstantImpact.ProductSelection
{
    public class ProductSelectionPage : Base
    {
        public By txbItemType { get { return By.XPath("//div[@id='Body_itemTypeContainer1']/span"); } }
        public By divItemType { get { return By.XPath("//div[@id='ctl00_Body_ItemTypeDropDownList1']"); } }
        public By lstItemType1 { get { return By.XPath("//input[@id='ctl00_Body_ItemTypeDropDownList1_Input']"); } }
        public By lstDivision { get { return By.XPath("//div[@class='rcbScroll rcbWidth']/ul"); } }
        public By lstItemType { get { return By.XPath("//ul[@class='rcbList']/li"); } }
        public By imgLoading { get { return By.XPath("//img[@src='/Content/Images/loading.gif']"); } }
        public By txbDimensions { get { return By.XPath("//div[@id='Body_dimensionContainer1']/span"); } }
        public By divDimension { get { return By.XPath("//input[@id='ctl00_Body_ddlDimension1_Input']"); } }
        public By lstDimension { get { return By.XPath("//div[@id='ctl00_Body_ddlDimension1_DropDown']/div/ul/li"); } }
        public By txbLamination { get { return By.XPath("//div[@id='Body_laminationContainer1']/span"); } }
        public By txbMounting { get { return By.XPath("//div[@id='Body_accessoriesContainer1']/span"); } }
        public By divMediaType { get { return By.XPath("//div[@id='ctl00_Body_ddlLamination1']"); } }
        public By lstMediaType { get { return By.XPath("//ul[@class='rcbList']/li"); } }
        public By divMounting { get { return By.XPath("//input[@id='ctl00_Body_ddlAccessories1_Input']"); } }
        public By txbQuantity { get { return By.XPath("//input[@id='ctl00_Body_qtyText1']"); } }
        public By btnnO { get { return By.XPath("//input[@id='Body_btnNo1']"); } }
        public By btnAddToCart { get { return By.XPath("//input[@id='Body_btnAddToCart']"); } }


        IWebDriver Driver;
        public ProductSelectionPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            //PageFactory.InitElements(Driver, this);
        }


        //Add to cart
        public void AddToCart1()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (!action.IsElementVisible(txbItemType))
                {
                    if (action.IsElementDisplayed(divItemType))
                    {
                        if (action.IsElementEnabled(lstItemType1))
                        {
                            action.WaitVisible(lstItemType1,300);
                            action.Click(lstItemType1);
                            action.WaitVisible(lstDivision,300);//Division of list
                            action.WaitTime(2);
                            IList<IWebElement> lstItemTypes = action.GetElements(lstItemType);
                            for (int i = 0; i < lstItemTypes.Count; i++)
                            {
                                lstItemTypes[1].Click();
                                action.WaitWhileNotVisible(imgLoading);
                                action.WaitForPageToLoad();
                                break;
                            }
                        }
                    }
                }
                if (!action.IsElementVisible(txbDimensions))
                {
                    if (action.IsElementDisplayed(divDimension))
                    {
                        if (action.IsElementEnabled(divDimension))
                        {
                            action.Click(divDimension);
                            action.WaitVisible(lstDivision);
                            action.WaitTime(2);
                            IList<IWebElement> lstDimensions = action.GetElements(lstDimension);
                            for (int i = 1; i < lstDimensions.Count; i++)
                            {
                                lstDimensions[i].Click();
                                action.WaitWhileNotVisible(imgLoading);
                                action.WaitForPageToLoad();
                                break;
                            }
                        }
                    }

                }
                if (!action.IsElementVisible(txbLamination))
                {
                    if (action.IsElementDisplayed(divMediaType))
                    {
                        if (action.IsElementEnabled(divMediaType))
                        {
                            action.Click(divMediaType);
                            action.WaitVisible(lstMediaType,300);
                            action.WaitTime(2);
                            IList<IWebElement> lstMediaTypes = action.GetElements(lstMediaType);
                            for (int i = 1; i < lstMediaTypes.Count; i++)
                            {
                                lstMediaTypes[i].Click();
                                // action.WaitUntilNotVisible(lstDivision);
                                action.WaitWhileNotVisible(imgLoading);
                                action.WaitForPageToLoad();
                                break;
                            }
                        }
                    }
                }
                if (!action.IsElementVisible(txbMounting))
                {
                    if (action.IsElementPresent(divMounting))
                    {
                        action.Click(divMounting);
                        action.WaitVisible(lstDivision,300);
                        action.WaitTime(2);
                        IList<IWebElement> lstMounting = action.GetElements(divMounting);
                        for (int i = 1; i < lstMounting.Count; i++)
                        {
                            lstMounting[i].Click();
                            action.WaitWhileNotVisible(imgLoading);
                            action.WaitForPageToLoad();
                            break;
                        }
                    }

                }
                if (action.IsElementPresent(txbQuantity))
                {
                    action.WaitVisible(txbQuantity,300);
                    action.ScrollToViewElement(txbQuantity);
                    action.Clear(txbQuantity);
                    action.Type(txbQuantity, "10");
                    action.Enter(txbQuantity);
                    action.WaitWhileNotVisible(imgLoading);
                    action.WaitForPageToLoad();
                }
                if (action.IsElementEnabled(btnnO))
                {
                    action.WaitVisible(btnnO, 300);
                    action.ScrollToViewElement(btnnO);
                    action.Click(btnnO);
                    action.WaitWhileNotVisible(imgLoading);
                    action.WaitForPageToLoad();
                }
                if (action.IsElementPresent(btnAddToCart))
                {
                    action.WaitVisible(btnAddToCart, 300);
                    action.ScrollToViewElement(btnAddToCart);
                    action.Click(btnAddToCart);
                    action.WaitWhileNotVisible(imgLoading);
                    action.WaitForPageToLoad();
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}