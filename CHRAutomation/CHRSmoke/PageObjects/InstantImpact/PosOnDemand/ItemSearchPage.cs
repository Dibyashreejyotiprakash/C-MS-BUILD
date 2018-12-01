using System;
using System.Collections.Generic;
using CHRSmoke.Initiate;
using CHRSmoke.Interaction;
using CHRSmoke.PageObjects.InstantImpact.Home;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace CHRSmoke.PageObjects.InstantImpact.PosOnDemand
{
    public class ItemSearchPage : Base
    {
        public By btnBack { get { return By.XPath("//a[@id='Body_lnkBack']"); } }
        public By txbSearch { get { return By.XPath("//input[@id='Body_txtSearch']"); } }
        public By imgLoading { get { return By.XPath("//img[@src='/Content/Images/loading.gif']"); } }
        public By lblSearchResultCount { get { return By.XPath("//span[@id='Body_lblItemCount']"); } }
        public By lblTempName { get { return By.XPath("//div[@id='ctl00_Body_ctl00_Body_rlvSearchResultsPanel']//div/a"); } }
        public By lblTemplateID { get { return By.XPath("//span[@id='Body_lblDesignNumber']/p"); } }
        public By lstMenu { get { return By.XPath("//div[@id='ctl00_RadMenu1']/ul/li"); } }
        public By btnCreateYourDesign { get { return By.XPath("//input[@id='Body_btnProductDesign']"); } }
        public By tabPosTemplate { get { return By.XPath("//*[(@target='_self') and contains(text(),'POS Templates')]"); } }


        HomePage homepage;
        Interactions action;
        public ItemSearchPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            homepage = new HomePage(Driver);
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //====================click on creteYour design btn
        public void ClickOnCreateYourDesignButton()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (action.IsElementPresent(btnCreateYourDesign))
                {
                    action.ScrollToViewElement(btnCreateYourDesign);
                    action.Click(btnCreateYourDesign);
                    action.WaitForPageToLoad();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Select menus
        public void SelectMenu(string MenuName)
        {
            Interactions action = new Interactions(Driver);
            try
            {
                string MenuNameUpper = MenuName.ToString().ToUpper();
                IList<IWebElement> lstMenus = action.GetElements(lstMenu);
                for (int i = 0; i < lstMenus.Count; i++)
                {
                    if (lstMenus[i].Text.ToString().ToUpper().Equals(MenuNameUpper))
                    {
                        lstMenus[i].Click();
                        action.WaitForPageToLoad(60);
                        break;
                    }
                }
                //action.WaitVisible(tabPosTemplate);
                //action.Click(tabPosTemplate);


            }
            catch (Exception e)
            {
                Console.WriteLine("Menu selection method failed Error : " + e);
                throw e;
            }
        }

        //Search Items
        public void SearchItem(string keyword)
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (action.IsElementPresent(btnBack))
                {
                    action.WaitVisible(btnBack);
                    action.Click(btnBack);
                }
                action.WaitVisible(txbSearch);
                action.Clear(txbSearch);
                action.WaitForPageToLoad();
                action.Type(txbSearch, keyword);
                action.Type(txbSearch, Keys.Enter);
                action.WaitWhileNotVisible(imgLoading);
                action.WaitForPageToLoad(60);
            }
            catch (Exception e)
            {
                Console.WriteLine("Template NOT Found " + e);
            }
        }

        //selct search item
        public void SelectSearchItem()
        {
            Interactions action = new Interactions(Driver);
            try
            {
                string searchResultMsg = action.GetText(lblSearchResultCount);
                string[] searchResultCount = searchResultMsg.Split(' ');
                //Console.WriteLine(searchResultCount[0].ToString());
                if (searchResultCount[0].ToString().Contains("1"))

                {
                    action.WaitVisible(lblTempName);
                    action.ScrollToViewElement(lblTempName);
                    action.Click(lblTempName);
                    action.WaitForPageToLoad();
                }
                else
                {
                    Console.WriteLine("No Search Result Found");
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Item not selected " + e);
                throw e;
            }
        }

        //validate search items for supplier
        public void ValidateSearchItemForCorpWithoutDist(string keyword)
        {
            Interactions action = new Interactions(Driver);
            try
            {
                string searchResultMsg = action.GetText(lblSearchResultCount).ToString();
                string[] searchResultCount = searchResultMsg.Split(' ');
                //Console.WriteLine(searchResultCount[0].ToString());
                if (searchResultCount[0].ToString().Contains("1"))
                {
                    SelectSearchItem();
                    //action.Click(obj_InstantImpact.lblTempName);
                    action.WaitForPageToLoad();
                    string templateID = action.GetText(lblTemplateID).ToString();
                    string[] stringArray = templateID.Split(' ');

                    if (stringArray[2].Equals(keyword))
                    {
                        Assert.IsTrue(stringArray[2].Equals(keyword));
                        Console.WriteLine(keyword + " is present for Instant Impact 4.0 Demo Corp (Supp.)");
                    }
                }
                else if (searchResultCount[0].ToString().Contains("0"))
                {
                    Assert.IsTrue(searchResultCount[0].ToString().Contains("0"));
                    Console.WriteLine(keyword + " is NOT present for Instant Impact 4.0 Demo Corp (Supp.)");
                    Console.WriteLine(searchResultMsg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ValidateSearchItemForCorpWithoutDist method failed due to " + e);
                throw e;
            }
        }

        //validate search items for supplier
        public void ValidateSearchItemForCorpWithDist(string keyword)
        {
            Interactions action = new Interactions(Driver);
            try
            {
                string searchResultMsg = action.GetText(lblSearchResultCount).ToString();
                string[] searchResultCount = searchResultMsg.Split(' ');
                //Console.WriteLine(searchResultCount[0].ToString());
                if (searchResultCount[0].ToString().Contains("1"))
                {
                    SelectSearchItem();
                    //action.Click(obj_InstantImpact.lblTempName);
                    action.WaitForPageToLoad();
                    string templateID = action.GetText(lblTemplateID).ToString();
                    string[] stringArray = templateID.Split(' ');

                    if (stringArray[2].Equals(keyword))
                    {
                        Assert.IsTrue(stringArray[2].Equals(keyword));
                        Console.WriteLine(keyword + " is present for Instant Impact 4.0 Demo Corp (Supp.)");
                    }
                }
                else if (searchResultCount[0].ToString().Contains("0"))
                {
                    Assert.IsTrue(searchResultCount[0].ToString().Contains("0"));
                    Console.WriteLine(keyword + " is NOT present for Instant Impact 4.0 Demo Corp (Supp.)");
                    Console.WriteLine(searchResultMsg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ValidateSearchItemForCorpWithDist failed due to " +e);
                throw e;
            }
        }

        //Validate search POS
        public void ValidateSearchPOS(string SelectCorp)
        {
            Interactions action = new Interactions(Driver);
            try
            {
                if (SelectCorp.ToUpper().Equals("CORP SUPP"))
                {
                    homepage.SelectMenuType("Dropdown");
                    SearchItem("130718");

                    ValidateSearchItemForCorpWithoutDist("130718");
                    if (action.IsElementPresent(btnBack))
                    {
                        action.Click(btnBack);
                        action.WaitForPageToLoad();
                    }
                    SearchItem("130725");
                    ValidateSearchItemForCorpWithoutDist("130725");

                }
                else if (SelectCorp.ToUpper().Equals("CORP DIST."))
                {
                    homepage.SelectMenuType("Dropdown");
                    SearchItem("130725");

                    ValidateSearchItemForCorpWithoutDist("130725");
                    if (action.IsElementPresent(btnBack))
                    {
                        action.Click(btnBack);
                        action.WaitForPageToLoad();
                    }
                    SearchItem("130718");
                    ValidateSearchItemForCorpWithoutDist("130718");

                }
                else
                {
                    SelectMenu("POS TEMPLATES");
                    SearchItem("130719");
                    ValidateSearchItemForCorpWithDist("CORP DIST");
                    if (action.IsElementPresent(btnBack))
                    {
                        action.Click(btnBack);
                        action.WaitForPageToLoad();
                    }
                    SearchItem("130719");
                    ValidateSearchItemForCorpWithDist("CORP DIST");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("ValidateSearchPOS method failed due to " +e);
                throw e;
            }
        }
    }
}