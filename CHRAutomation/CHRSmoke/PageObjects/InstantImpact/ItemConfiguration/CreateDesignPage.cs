using System;
using CHRSmoke.Initiate;
using CHRSmoke.Interaction;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using CHRSmoke.PageObjects.InstantImpact.Home;
using CHRSmoke.PageObjects.InstantImpact.Login;
using CHRSmoke.PageObjects.InstantImpact.PosOnDemand;
using System.Collections.Generic;

namespace CHRSmoke.PageObjects.InstantImpact.ItemConfiguration
{
    public class CreateDesignPage : Base
    {
        public By btnCreateYourDesign { get { return By.XPath("//input[@id='Body_btnProductDesign']"); } }
        public By imgCorporationLogo { get { return By.XPath("//img[@id='imgCorporationLogo']"); } }
        public By divHeadline { get { return By.XPath("//div[@id='Body_txtQMHeadline___livespell_proxy']"); } }
        public By ddlHeadLine { get { return By.XPath("//select[@id='Body_ddlHeadline']"); } }
        public By imgLoading { get { return By.XPath("//img[@src='/Content/Images/loading.gif']"); } }
        public By ddlChooseFont { get { return By.XPath("//select [@id='Body_ddlChooseFont']"); } }
        public By ddlChooseColor { get { return By.XPath("//select[@id='Body_ddlChooseColor']"); } }
        public By divPrice { get { return By.XPath("//div[@id='Body_txtQTPrice___livespell_proxy']"); } }
        public By btnNextStep { get { return By.XPath("//input[@id='btnNextStep']"); } }
        public By divMessage { get { return By.XPath("//div[@id='Body_txtQMMessage___livespell_proxy']"); } }
        public By divAccount { get { return By.XPath("//div[@id='Body_txtQMAccount___livespell_proxy']"); } }
        public By lnkViewProof { get { return By.XPath("//div[@id='Body_divViewProof']"); } }
        public By lnkSaveDesign { get { return By.XPath("(//div[@class='icProofButton'])[2]"); } }
        public By divViewProject { get { return By.XPath("//div[@id='Body_projectsDiv']/div/a"); } }
        public By lnkAccount { get { return By.XPath("//a[@href='/Account/MyAccountPage.aspx']"); } }
        public By colDesignName { get { return By.XPath("//table[@id='ctl00_Body_RadGridTemplate_ctl00']/tbody/tr/td[5]"); } }
        public By btnNextPage { get { return By.XPath(".//*[@id='ctl00_Body_RadGridTemplate_ctl00']/tfoot/tr/td/div/div[3]/button[1]"); } }
        public By btnPreviewChanges { get { return By.XPath("//input[@id='btnRepaintImage']"); } }
        public By ddlChooseLayout { get { return By.XPath("//select[@id='Body_ddlChooseLayout']"); } }
        public By ddlAccount { get { return By.XPath("//select[@id='Body_ddlAccount']"); } }
        public By txbCreateDesign { get { return By.XPath("//input[@id='Body_txtQTText']"); } }
        public By txbDesignName { get { return By.XPath("//input[@id='ctl00_Body_rwSaveDesignModal_C_txtDesignName']"); } }
        public By btnSave { get { return By.XPath("//input[@id='ctl00_Body_rwSaveDesignModal_C_btnDesignSave']"); } }
        public By btnNext { get { return By.XPath("//input[@id='btnNextStep']"); } }
        public By btnYes { get { return (By.XPath("//*[@class='btn GenericRedButton']/span/span[text()='Yes']")); } }


        IWebDriver Driver;
        LoginPage loginpage;
        HomePage homepage;
        Interactions action;
        ItemSearchPage itemsearchpage;
        public CreateDesignPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            action = new Interactions(Driver);
           // PageFactory.InitElements(Driver, this);
            loginpage = new LoginPage(Driver);
            homepage = new HomePage(Driver);
            itemsearchpage = new ItemSearchPage(Driver);
        }

        public static string createdUserName;
        public static string TempDesingName;
        internal static string UniqueName(string name)
        {
            string timeStamp = DateTime.Now.ToString();
            timeStamp = timeStamp.Replace("/", "").Replace(" ", "").Replace(":", "");
            return name + timeStamp;
        }

        //====== click on brandmuscle corporation logo
        public void ClickOnBrandmuscleLogo()
        {
            try
            {
                action.WaitVisible(imgCorporationLogo,300);
                if (action.IsElementPresent(imgCorporationLogo))
                {
                    action.ScrollToViewElement(imgCorporationLogo);
                    try
                    {
                        action.Click(imgCorporationLogo);
                        action.AcceptAlert();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    action.WaitForPageToLoad();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ClickOnBrandmuscleLogo method failed due to " +e);
                throw e;
            }
        }

        //====================click on creteYour design btn
        public void ClickOnCreateYourDesignButton()
        {
            try
            {
                if (action.IsElementPresent(btnCreateYourDesign))
                {
                    action.WaitVisible(btnCreateYourDesign,300);
                    action.ScrollToViewElement(btnCreateYourDesign);
                    action.Click(btnCreateYourDesign);
                    action.WaitForPageToLoad();
                    action.WaitVisible(btnPreviewChanges);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ClickOnCreateYourDesignButton method failed due to " +e);
                throw e;
            }
        }

        //click on next step
        public void ClickOnNextStep()
        {
            try
            {
                action.WaitVisible(btnNextStep);
                action.Click(btnNextStep);
                action.WaitWhileNotVisible(imgLoading);
            }
            catch (Exception e)
            {
                Console.WriteLine("ClickOnNextStep method failed due to " +e);
                throw e;
            }
        }

        //create your design
        public void CreateAndSaveYourDesign()
        {
            try
            {
                if (action.IsElementEnabled(btnCreateYourDesign))
                {
                    action.ScrollToBottomOfPage();
                    action.WaitUntilElementClickable(btnCreateYourDesign, 20);
                    //click on create your design btn
                    action.Click(btnCreateYourDesign);
                    if (action.IsElementPresent(divHeadline))
                    {
                        action.WaitVisible(divHeadline,300);
                        action.Type(divHeadline, "testHeadline");
                    }
                    if (action.IsElementPresent(txbCreateDesign))
                    {
                        action.WaitVisible(txbCreateDesign, 300);
                        //type create design text
                        action.Type(txbCreateDesign, "TestDesign");
                    }
                    if (action.IsElementPresent(ddlChooseLayout))
                    {
                        action.WaitVisible(ddlChooseLayout, 300);
                        action.SelectByText(ddlChooseLayout, "English");
                    }
                    if (action.IsElementPresent(divPrice))
                    {
                        action.WaitVisible(divPrice, 300);
                        action.ScrollToViewElement(divPrice);
                        action.Type(divPrice, "10");
                    }
                    if (action.IsElementPresent(divMessage))
                    {
                        action.WaitVisible(divMessage, 300);
                        action.Type(divMessage, "TestMessage");
                    }
                    if (action.IsElementPresent(ddlAccount))
                    {
                        action.WaitVisible(ddlAccount, 300);
                        action.ScrollToViewElement(ddlAccount);
                        action.SelectByIndex(ddlAccount, 1);
                    }
                    if (action.IsElementPresent(divAccount))
                    {
                        action.WaitVisible(divAccount, 300);
                        action.ScrollToViewElement(divAccount);
                        action.Type(divAccount, "textAccount");
                    }
                    action.WaitVisible(btnPreviewChanges, 300);
                    //click on preview change
                    action.Click(btnPreviewChanges);
                    action.WaitWhileNotVisible(imgLoading);
                    action.WaitForPageToLoad(60);
                    action.WaitVisible(lnkViewProof,300);
                    action.WaitVisible(btnNext, 300);
                    action.Click(btnNext);
                    action.WaitVisible(btnYes, 300);
                    //Click on yes btn
                    action.Click(btnYes);
                    //create unique design name
                    string uniqueDesignName = UniqueName("Test");
                    action.Type(txbDesignName, uniqueDesignName);
                    TempDesingName = action.GetAttribute(txbDesignName, "value").ToString().Trim();
                    //click on save btn
                    action.WaitVisible(btnSave, 300);
                    action.Click(btnSave);
                    action.WaitWhileNotVisible(imgLoading);
                    action.WaitForPageToLoad(60);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("CreateAndSaveYourDesign failed due to "+e);
                throw e;
            }

        }

        public void SaveDesign()
        {
            try
            {

                if (action.IsElementPresent(divHeadline))
                {
                    action.WaitVisible(divHeadline, 300);
                    action.Type(divHeadline, "testHeadline");
                }
                if (action.IsElementPresent(ddlHeadLine))
                {
                    action.WaitVisible(ddlHeadLine, 300);
                    action.SelectByIndex(ddlHeadLine, 2);
                    action.WaitWhileNotVisible(imgLoading);
                }
                if (action.IsElementPresent(ddlChooseFont))
                {
                    action.WaitVisible(ddlChooseFont, 300);
                    action.SelectByIndex(ddlChooseFont, 1);
                    action.WaitWhileNotVisible(imgLoading);
                }
                if (action.IsElementPresent(ddlChooseColor))
                {
                    action.WaitVisible(ddlChooseColor, 300);
                    action.SelectByIndex(ddlChooseColor, 1);
                    action.WaitWhileNotVisible(imgLoading);
                }
                if (action.IsElementPresent(ddlChooseLayout))
                {
                    action.WaitVisible(ddlChooseLayout, 300);
                    action.ScrollToBottomOfPage();
                    action.SelectByIndex(ddlChooseLayout, 2);
                    action.WaitWhileNotVisible(imgLoading);
                }
                if (action.IsElementPresent(ddlAccount))
                {
                    action.WaitVisible(ddlAccount, 300);
                    action.SelectByIndex(ddlAccount, 1);
                    action.WaitWhileNotVisible(imgLoading);
                }
                if (action.IsElementPresent(txbCreateDesign))
                {
                    action.WaitVisible(txbCreateDesign, 300);
                    action.Type(txbCreateDesign, "TestDesign");
                }
                if (action.IsElementPresent(divPrice))
                {
                    action.WaitVisible(divPrice, 300);
                    action.ScrollToViewElement(divPrice);
                    action.Type(divPrice, "10");
                }
                if (action.IsElementPresent(divMessage))
                {
                    action.WaitVisible(divMessage,300);
                    action.Type(divMessage, "TestMessage");
                }
                if (action.IsElementPresent(ddlAccount))
                {
                    action.WaitVisible(ddlAccount, 300);
                    action.ScrollToViewElement(ddlAccount);
                    action.SelectByIndex(ddlAccount, 1);
                }
                if (action.IsElementPresent(divAccount))
                {
                    action.WaitVisible(divAccount, 300);
                    action.ScrollToViewElement(divAccount);
                    action.Type(divAccount, "textAccount");
                }
                action.WaitVisible(btnPreviewChanges, 300);
                action.Click(btnPreviewChanges);
                action.WaitWhileNotVisible(imgLoading);
                action.WaitForPageToLoad(60);
                action.WaitVisible(lnkViewProof);
                action.WaitVisible(lnkSaveDesign, 300);
                action.Click(lnkSaveDesign);
                string uniqueDesignName = UniqueName("Test");
                action.WaitVisible(txbDesignName, 300);
                action.Type(txbDesignName, uniqueDesignName);
                TempDesingName = action.GetAttribute(txbDesignName, "value").ToString().Trim();
                action.WaitVisible(btnSave, 300);
                action.Click(btnSave);
                action.WaitWhileNotVisible(imgLoading);
                action.WaitForPageToLoad(60);
                ClickOnNextStep();
            }
            catch (Exception e)
            {
                Console.WriteLine("SaveDesign method failed due to "+ e);
                throw e;
            }
        }

        //==================Click on Account link===============
        public void ClickOnAccountLink()
        {
            try
            {
                if (action.IsElementPresent(lnkAccount))
                {
                    action.ScrollToViewElement(lnkAccount);
                    action.Click(lnkAccount);
                    action.WaitForPageToLoad();
                    action.WaitTime(5);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("ClickOnAccountLink method failed due to " + e);
                throw e;
            }
        }

        //==================click on view project
        public void ClickOnViewProjecDivision()
        {
            try
            {
                action.WaitVisible(divViewProject);
                if (action.IsElementPresent(divViewProject))
                {
                    action.Click(divViewProject);
                    action.WaitForPageToLoad();
                    action.WaitTime(10);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ClickOnViewProjecDivision method failed due to "+ e);
                throw e;
            }
        }

        //verify save design name
        public bool VerifyTemplateDesignName()
        {
            try
            {
                bool IsTemplateDesignNameFound = false;
                IList<IWebElement> designNameCol = action.GetElements(colDesignName);

                for (int i = 0; i < designNameCol.Count; i++)
                {
                    if (designNameCol[i].Text.ToString().Equals(TempDesingName))
                    {
                        IsTemplateDesignNameFound = true;
                        Console.WriteLine("Saved  Design Name verified successfully, Template Design Name = " + TempDesingName);
                        break;
                    }
                    else
                    {
                        action.ScrollToViewElement(btnNextPage);
                        action.Click(btnNextPage);
                        action.WaitForPageToLoad();
                        for (int j = 0; j < designNameCol.Count; j++)
                        {
                            if (designNameCol[i].Text.ToString().Equals(TempDesingName))
                            {
                                IsTemplateDesignNameFound = true;
                                Console.WriteLine("Saved  Design Name verified successfully");
                                break;
                            }

                        }
                    }
                }
                return IsTemplateDesignNameFound;
            }
            catch (Exception e)
            {
                Console.WriteLine("VerifyTemplateDesignName method failed due to "+ e);
                throw e;
            }
            
        }

        //==========================SAVE AND VARIFY VARIABLE TEMPLATE=======================================================

        public void SaveAndVarifyVariableTemplate()
        {
            try
            {
                homepage.SelectMenuType("Dropdown");               
                //search items
                itemsearchpage.SearchItem("130719");
                //select search items
                itemsearchpage.SelectSearchItem();
                //click on create your design button
                ClickOnCreateYourDesignButton();
                //save design
                SaveDesign();
                //click on brandmuscle corporation logo
                ClickOnBrandmuscleLogo();
                //click on account link
                ClickOnAccountLink();
                //click on view project
                //click on project link/project div
                ClickOnViewProjecDivision();
                bool IstempDesignNameFoundSuccessfully = VerifyTemplateDesignName();
                Assert.IsTrue(IstempDesignNameFoundSuccessfully);
            }
            catch (Exception e)
            {
                Console.WriteLine("Save Variable Template Failed: Error- " + e);
                throw e;
            }
        }
    }
}