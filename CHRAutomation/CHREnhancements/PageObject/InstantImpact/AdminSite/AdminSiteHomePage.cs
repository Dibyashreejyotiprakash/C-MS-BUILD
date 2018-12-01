using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.AdminSite
{
    public class AdminSiteHomePage : Base
    {
        public static By InstantImpactTab
        { get { return (By.XPath("//*[text()='Instant Impact']")); } }

        public static By MetaTaggingCategory
        { get { return (By.XPath("//*[text()='Meta Tagging Category/Item Maintenance']")); } }

        public static By ItemSearchTagging
        { get { return (By.XPath("//*[text()='Item Search Tagging']")); } }

        public static By TemplateFulfilment
        { get { return (By.XPath("//*[text()='Instant Impact - Templates & Fulfillment']")); } }

        public static By CorporationDropDown
        { get { return (By.XPath("//*[@id='ctl00_cphMain_rcbCorp_Arrow']")); } }

        public static By SelectCorporation
        { get { return (By.XPath("//*[@class='rcbList']/li[text()='44 - Diageo']")); } }

        public static By ItemTypeDropDown
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rcbItemType_Input']")); } }

        public static By SelectItemType
        { get { return (By.XPath("//*[@class='rcbList']/li[text()='Template']")); } }

        public static By SelectedItemType
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rcbItemType_Input']")); } }

        public static By Table
        { get { return (By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rgTemplate']")); } }

        public static By SelectData
        { get { return (By.XPath("//*[@class='rgMasterTable']/tbody/tr[1]/td[1]/a")); } }

        public static By BrandName
        { get { return (By.XPath("//*[text()='Brandy']/../input")); } }

        public static By Save
        { get { return (By.XPath("//*[@id='cphMain_cphMain_btnSave']")); } }

        public static By Fulfillment
        { get { return (By.XPath("(//*[text()='Fulfillment'])[1]")); } }

        public static By FulfillmentSearch
        { get { return (By.XPath("//*[text()='Fulfillment Search']")); } }

        public static By CreateFulfillmentItem
        { get { return (By.XPath("//*[text()='Create Fulfillment Item']")); } }

        public static By CreateFulfillmentItemTab
        { get { return (By.XPath("(//*[text()='Create Fulfillment Item'])[1]")); } }

        public static By BannedPhrases
        { get { return (By.XPath("//*[text()='Banned Phrases']")); } }

        public static By FulfillmentGrid
        { get { return (By.XPath("//*[@id='ctl00_cphMain_radGrdFulfillmentSearch']")); } }

        public static By SearchBtn
        { get { return (By.XPath("//*[@name='ctl00$cphMain$btnSearch']")); } }

        public static By EditBtnFromFulfillmentItemGrid
        { get { return (By.XPath("//*[@id='ctl00_cphMain_radGrdFulfillmentSearch']/table/tbody/tr/td[2]/a")); } }

        public static By EditBtnFromSkusGrid
        { get { return (By.XPath("//*[@id='ctl00_cphMain_radGridFulfillmentItems']/table/tbody/tr/td[1]/a")); } }
        
        public static By SkuGrid
        { get { return (By.XPath("//*[@id='ctl00_cphMain_radGridFulfillmentItems']")); } }

        public static By InActiveCheckBox
        { get { return (By.XPath("//*[text()='Inactive']/../input")); } }

        public static By SkuInSkuDetails
        { get { return (By.XPath("//*[@id='ctl00_cphMain_rtbSku']")); } }

        public static By UpdateBtn
        { get { return (By.XPath("//*[@id='cphMain_btnUpdate']")); } }

        public static By ActivateBtns
        { get { return (By.XPath("//*[@id='ctl00_cphMain_radGridFulfillmentItems']/table/tbody/tr/td[4]/a")); } }

        public static By FirstEditBtnInSkuGrid
        { get { return (By.XPath("//*[@id='ctl00_cphMain_radGridFulfillmentItems']/table/tbody/tr[1]/td[1]/a")); } }

        public static By FirstActivateBtn
        { get { return (By.XPath("//*[@id='ctl00_cphMain_radGridFulfillmentItems']/table/tbody/tr[1]/td[4]/a")); } }

        public static By SkuInputFiled
        { get { return (By.XPath("//*[@id='ctl00_cphMain_txtSku']")); } }

        public static By ConfirmationMsgDeactivation
        { get { return (By.XPath("//*[@id='cphMain_lblMainMessage']")); } }

        public static By ProductBtn
        { get { return (By.XPath("//*[@id='ctl00_cphMain_rcbProductUnit_Arrow']")); } }

        public static By SelectProduct
        { get { return (By.XPath("//*[text()='No Product Unit']")); } }

        public static By ItemWithoutProductChkBox
        { get { return (By.XPath("//*[@id='cphMain_chkWithoutProductUnit']")); } }

        public static By EditForDisassociation
        { get { return (By.XPath("//*[text()='Add Item']/../../td[2]")); } }

        public static By SkuGridInFulfillMentSearch
        { get { return (By.XPath("//*[@id='ctl00_cphMain_radGrdFulfillmentSearch']")); } }

        public static By DisassociatedSkuInGrid
        { get { return (By.XPath("//*[@id='ctl00_cphMain_radGrdFulfillmentSearch']/table/tbody/tr/td[5]")); } }

        public static By BrandMuscleTab
        { get { return (By.XPath("//*[text()='Brandmuscle']")); } }

        public static By SiteSecurityTab
        { get { return (By.XPath("//*[@class='rmItem ']//div/ul/li/a/span[text()='Site Security']")); } }

        public static By CreditCardTab
        { get { return (By.XPath("//*[text()='Credit Cards']")); } }

        public static By PostCreditCardChargesTab
        { get { return (By.XPath("//*[text()='Post Credit Card Charges']")); } }

        public static By BudgetManagerTab
        { get { return (By.XPath("//*[text()='Budget Manager']")); } }

        public static By BudgetSetUpTab
        { get { return (By.XPath("//*[text()='Budget Setup']")); } }

        public static By DistributorBudgetSetUpTab
        { get { return (By.XPath("//*[text()='Distributor Budget Setup']")); } }

        public static By BudgetMaintenanceTab
        { get { return (By.XPath("//*[text()='Budget Maintenance']")); } }

        public static By ResourcesMessage
        { get { return (By.XPath("//*[text()='Resource Message']")); } }

        public static By ItemGatingGroupManagementTab
        { get { return (By.XPath("//*[text()='Item Gating Group Management']")); } }

        public static By StandardItemGating
        { get { return (By.XPath("//*[text()='Standard Item Gating']")); } }

        public static By ReddBullStichLabTab
        { get { return (By.XPath("//*[text()='Red Bull/Stitch Labs']")); } }

        public static By ShippingErrors
        { get { return (By.XPath("//*[text()='Shipping Errors']")); } }

        public static By FulfillmentProductUnitTab
        { get { return (By.XPath("//*[text()='Fulfillment Product Unit']")); } }

        public static By CreateFulfillmentTab
        { get { return (By.XPath("//*[text()='Create Fulfillment Product Unit']")); } }

        public static By AssociateItemToProductUnit
        { get { return (By.XPath("//*[text()='Associate Items to Product Unit']")); } }

        public static By ReportsTab
        { get { return (By.XPath("//*[@href='/Fulfillment/Reports.aspx']/span")); } }

        Interactions action;
        public AdminSiteHomePage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Verify Home Page
        public void VerifyAdminHomePage()
        {
            try
            {
                action.VerifyCurrentPage("Home page", "brandmuscle.net");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Admin Home Page failed due to " + e);
                throw e;
            }
        }
        //Click on Item Search Tagging
        public void ClickOnItemSearchTagging()
        {
            try
            {
                //Hover on InstantImpact
                action.WaitVisible(InstantImpactTab);
                action.MouseOverOnElement(InstantImpactTab);
                //Hover on Meta Tagging
                action.WaitVisible(MetaTaggingCategory);
                action.MouseHoverAndClick(MetaTaggingCategory,ItemSearchTagging);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click On Item Search Tagging failed due to " + e);
                throw e;
            }
        }

        //Click on FulfillmentSearch
        public void ClickOnFulfillmentSearch()
        {
            try
            {
                //Hover on InstantImpact
                action.WaitVisible(Fulfillment);
                action.MouseOverOnElement(Fulfillment);
                Console.WriteLine("Mouse hover on Fulfillment tab");
                //Hover on Fulfillment Saerch
                action.WaitVisible(FulfillmentSearch);
                action.MouseHoverAndClick(FulfillmentSearch);
                Console.WriteLine("Mouse hover on Fulfillment Search tab");
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on fulfillment search failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Banned Phrases
        public void ClickOnBannedPhrases()
        {
            try
            {
                //Hover on InstantImpact
                action.WaitVisible(InstantImpactTab);
                action.MouseOverOnElement(InstantImpactTab);
                Console.WriteLine("Mouse hover on Instant Impact Tab");
                //Click on Banned Phrases
                action.WaitVisible(BannedPhrases);
                action.MouseHoverAndClick(BannedPhrases);
                Console.WriteLine("Mouse hover on Banned Phrases Tab");
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on Banned phrases failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Create Fulfillment Items
        public void ClickOnFulfillmentItems()
        {
            try
            {
                //Hover on InstantImpact
                action.WaitVisible(Fulfillment);
                action.MouseOverOnElement(Fulfillment);
                Console.WriteLine("Mouse hover on Fulfillment tab");
                //Hover on Meta Tagging
                action.WaitVisible(CreateFulfillmentItemTab);
                action.MouseHoverAndClick(CreateFulfillmentItemTab);
                Console.WriteLine("Mouse hover on CreateFulfill mentItem tab");
            }
            catch (Exception e)
            {
                Console.WriteLine("Click on fulfillment search failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Create Fulfillment Item
        public void ClickOnCreateFulfillmentItem()
        {
            try
            {
                //Hover on InstantImpact
                action.WaitVisible(Fulfillment);
                action.MouseOverOnElement(Fulfillment);
                //Hover on Meta Tagging
                action.WaitVisible(CreateFulfillmentItem);
                action.MouseHoverAndClick(CreateFulfillmentItem);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Create Fulfillment Item failed due to " + e);
                //Closing browser
                Driver.Quit();
                throw e;
            }
        }

        public void VerifyInstantImpactTemplatesFulfillment()
        {
            try
            {
                action.WaitVisible(TemplateFulfilment);
                bool status = action.IsElementDisplayed(TemplateFulfilment);
                Console.WriteLine("Status of header is " + status);
                Assert.IsTrue(status);
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Instant Impact Templates Fulfillment page failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        public void SelectCorporationFromDropDown()
        {
            try
            {
                action.WaitVisible(CorporationDropDown);
                action.Click(CorporationDropDown);
                action.WaitVisible(SelectCorporation);
                action.Click(SelectCorporation);
                action.WaitTime(10);
            }
            catch(Exception e)
            {
                Console.Write("Select Corporation failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Search
        public void ClickOnSearch()
        {
            try
            {
                action.WaitVisible(SearchBtn);
                action.Click(SearchBtn);
            }
            catch (Exception e)
            {
                Console.Write("Click on Search failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Edit from Fulfillment Item grid
        public void ClickOnEditFromFulfillmentGrid()
        {
            try
            {
                action.WaitVisible(FulfillmentGrid);
                bool status = action.IsElementDisplayed(FulfillmentGrid);
                if(status)
                {
                    IList<IWebElement> fulfillmentitems = action.GetElements(EditBtnFromFulfillmentItemGrid);
                    for (int i = 0; i < fulfillmentitems.Count; i++)
                    {
                        fulfillmentitems[i].Click();
                        if(i==0)
                        {
                            break;
                        }
                    }
                }   
            }
            catch(Exception e)
            {
                Console.Write("Click on edit failed due to " + e);
                Console.WriteLine("There is no fulfillment items for the corporation");
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Edit for Disassociation
        public void ClickOnEditForDisassociation()
        {
            try
            {
                action.WaitVisible(EditForDisassociation);
                action.Click(EditForDisassociation);
            }
            catch(Exception e)
            {
                Console.Write("Click on edit for disassociation failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Edit fron Skus grid
        public void ClickOnEditFromSkuGrid()
        {
            try
            {
                action.WaitVisible(SkuGrid);
                bool status = action.IsElementDisplayed(SkuGrid);
                if (status)
                {
                    bool statusoffirsteditbtn = action.IsElementEnabled(FirstEditBtnInSkuGrid);
                    if(statusoffirsteditbtn)
                    {
                        action.WaitVisible(FirstEditBtnInSkuGrid);
                        action.Click(FirstEditBtnInSkuGrid);
                    }
                    else
                    {
                        action.WaitVisible(FirstActivateBtn);
                        action.Click(FirstActivateBtn);
                        action.WaitVisible(FirstEditBtnInSkuGrid);
                        action.Click(FirstEditBtnInSkuGrid);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on edit fron skus grid failed due to " + e);
                Console.WriteLine("There is no SKUS in grid");
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //Select Product as No Product Unit
        public void DisassociateSku()
        {
            try
            {
                action.WaitVisible(ProductBtn);
                action.Click(ProductBtn);
                action.WaitVisible(SelectProduct);
                action.Click(SelectProduct);
            }
            catch(Exception e)
            {
                Console.WriteLine("Select product failed due to "+ e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }
        
        //Select Inactive
        public void SelectInactiveChkBox()
        {
            try
            {
                action.WaitVisible(InActiveCheckBox);
                if(!(action.IsElementSelected(InActiveCheckBox)))
                {
                    action.Click(InActiveCheckBox);
                }
                else
                {
                    Console.WriteLine("Deactivation check box is lready selected");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Select as inactive failed due to "+ e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        public static string actualsku = "";
        //Capture SKU 
        public string CaptureSku()
        {
            try
            {
                IWebElement skufield = Driver.FindElement(By.Id("ctl00_cphMain_rtbSku"));
                string fullsku = skufield.GetAttribute("value");
                actualsku = fullsku.Trim();
                Console.Write("Sku is " + actualsku);
                return actualsku;
            }
            catch(Exception e)
            {
                Console.WriteLine("Capture sku failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Update
        public void ClickOnUpdate()
        {
            try
            {
                action.WaitVisible(UpdateBtn);
                action.Click(UpdateBtn);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on update failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //Verify Disassociated Fulfillment Item
        public void VerifyDisassociatedItem()
        {
            try
            {
                action.WaitVisible(SkuInputFiled);
                action.Type(SkuInputFiled,actualsku);
                action.WaitVisible(ItemWithoutProductChkBox);
                action.Click(ItemWithoutProductChkBox);
                ClickOnSearch();
                if(action.IsElementDisplayed(SkuGridInFulfillMentSearch))
                {
                    action.WaitVisible(DisassociatedSkuInGrid);
                    bool status = action.IsElementDisplayed(DisassociatedSkuInGrid);
                    if (status)
                    {
                        Console.WriteLine("Disassociated sku found");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify disasociated item failed due to " + e);
            }
        }


        //Verify Deactivated Sku
        public void VerifyDeactivatedSku()
        {
            try
            {
                action.WaitVisible(ConfirmationMsgDeactivation);
                string confirmationmsg = action.GetText(ConfirmationMsgDeactivation);
                Console.WriteLine("Message after update is " + confirmationmsg);
                Assert.IsTrue(confirmationmsg.Contains("You successfully updated the item."), confirmationmsg + "Error msg -Confirmation message after updation is not displaying");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify deactivated sku failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //Select Item type 
        public void SelectItemTypeFromDropDown()
        {
            try
            {
                action.WaitVisible(ItemTypeDropDown);
                action.Click(ItemTypeDropDown);
                action.WaitVisible(SelectItemType);
                action.Click(SelectItemType);
                action.WaitTime(10);
            }
            catch (Exception e)
            {
                Console.Write("Select Item Type From Drop Down failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        public void SelectDataFromTable()
        {
            try
            {
                action.WaitVisible(Table);
                if(action.IsElementDisplayed(Table))
                {
                    action.WaitVisible(SelectData);
                    action.Click(SelectData);
                }
                action.WaitTime(10);
            }
            catch (Exception e)
            {
                Console.Write("Select data failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //Select Brand and Click on save
        public void SelectBrandAndSave()
        {
            try
            {
                action.WaitVisible(BrandName);
                action.Click(BrandName);
                action.WaitVisible(Save);
                action.Click(Save);
            }
            catch (Exception e)
            {
                Console.Write("Select brand failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //Verify the selected value from the Item Drop down is Template
        public void VerifySelectedValueFromItemType()
        {
            try
            {
                string actitemptype = Driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_cphMain_cphMain_rcbItemType_Input']")).GetAttribute("value");
                Console.WriteLine("Actual item type is " + actitemptype);
                string expitemtype = "Template";
                if(actitemptype.Equals(expitemtype))
                {
                    Console.WriteLine("Item type matching");
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Console.Write("Verify Selected Value From Item Type failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on Site Security
        public void ClickOnSiteSecurity()
        {
            try
            {
                action.WaitVisible(BrandMuscleTab);
                action.MouseOverOnElement(BrandMuscleTab);
                action.MouseOverOnElement(SiteSecurityTab);
                action.Click(SiteSecurityTab);
            }
            catch(Exception e)
            {
                Console.WriteLine("Clcik on Site Security failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //CLick on Post Credit card Charges
        public void ClickOnPostCreditCardCharges()
        {
            try
            {
                action.WaitVisible(InstantImpactTab);
                action.MouseOverOnElement(InstantImpactTab);
                action.WaitTime(5);
                action.WaitVisible(CreditCardTab);
                //action.MouseHoverAndClick(CreditCardTab, PostCreditCardChargesTab);
                action.MouseOverOnElement(CreditCardTab);
                action.WaitTime(5);
                action.MouseOverOnElement(PostCreditCardChargesTab);
                action.Click(PostCreditCardChargesTab);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click On Post Credit Card Charges failed due to " + e);
                //Closing Browser
                Driver.Quit();
                throw e;
            }
        }

        //Click on DistributorbudgetManager
        public void ClickOnDisrtibutorBudgetSetup()
        {
            try
            {
                action.MouseOverOnElement(BudgetManagerTab);
                Console.WriteLine("Mouse hover on Budget Manager Tab Done");
                action.WaitVisible(BudgetSetUpTab);
                action.MouseOverOnElement(BudgetSetUpTab);
                Console.WriteLine("Mouse hover on Budget SetUp Tab Done");
                action.WaitVisible(DistributorBudgetSetUpTab);
                action.MouseHoverAndClick(DistributorBudgetSetUpTab);
                Console.WriteLine("Mouse hover on Distributor Budget SetUp Tab Done");
            }
            catch(Exception e)
            {
                Console.WriteLine("Click On DisrtibutorBudgetSetup due to " + e);
                throw e;
            }
            
        }

        //Click on Budget Maintenance tab
        public void ClickOnBudgetMaintenance()
        {
            try
            {
                action.MouseOverOnElement(BudgetManagerTab);
                Console.WriteLine("Mouse hover on Budget maintenance");
                action.MouseHoverAndClick(BudgetSetUpTab, BudgetMaintenanceTab);
                Console.WriteLine("Mouse hover on Budget SetUp and clicked on Budget Maintenance tab");
            }
            catch(Exception e)
            {
                Console.WriteLine("Click On BudgetMaintenance due to " + e);
                throw e;
            }
        }

        //Click on Resorces Message
        public void ClickOnResourcesMessage()
        {
            try
            {
                action.MouseOverOnElement(InstantImpactTab);
                action.MouseHoverAndClick(ResourcesMessage, ResourcesMessage);

            }
            catch(Exception e)
            {
                Console.WriteLine("Click On Resources Message failed due to " + e);
                throw e;
            }
        }

        //Click on Standard Item Gating 
        public void ClickOnStandardItemGating()
        {
            try
            {
                action.WaitVisible(InstantImpactTab);
                action.MouseOverOnElement(InstantImpactTab);
                action.MouseOverOnElement(ItemGatingGroupManagementTab);
                action.MouseHoverAndClick(StandardItemGating);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Standard Item Gating tab failed due to " + e);
                throw e;
            }
        }

        //CLick on Shipping Errors tab
        public void ClickOnReportsTab()
        {
            try
            {
                action.WaitVisible(Fulfillment);
                action.MouseOverOnElement(Fulfillment);
                action.WaitVisible(FulfillmentProductUnitTab);
                action.MouseOverOnElement(FulfillmentProductUnitTab);
                action.WaitVisible(CreateFulfillmentItemTab);
                action.MouseOverOnElement(CreateFulfillmentItemTab);
                action.WaitVisible(AssociateItemToProductUnit);
                action.MouseOverOnElement(AssociateItemToProductUnit);
                action.WaitVisible(ReportsTab);
                action.MouseOverOnElement(ReportsTab);
                //action.Click(ReportsTab);
                //action.WaitForPageToLoad();
            }
            catch(Exception e)

            {
                Console.WriteLine("Click on Shiiping Error tab failed due to" + e);
                throw e;
            }
        }
        
    }
}

