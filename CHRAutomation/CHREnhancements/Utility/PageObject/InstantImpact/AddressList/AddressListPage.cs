using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using System.Windows.Forms;
using System.IO;
using OpenQA.Selenium.Remote;

namespace CHREnhancements.PageObject.InstantImpact.AddressList
{
    class AddressListPage : Base
    {
        public static By ImportAddressList
        { get { return (By.XPath("//*[@id='Body_btnImportAddressList']")); } }

        public static By ListName
        { get { return (By.XPath("//*[@id='Body_txtListName']")); } }

        public static By SearchFieldInHeader
        { get { return (By.XPath("//*[@id='txtSearch']")); } }

        public static By AddAddressLink
        { get { return (By.XPath("//*[@id='Body_btnAddAddress']")); } }

        public static By CompanyName
        { get { return (By.XPath("//*[@id='Body_txtCompanyName']")); } }

        public static By FirstName
        { get { return (By.XPath("//*[@id='Body_txtFirstName']")); } }

        public static By LastName
        { get { return (By.XPath("//*[@id='Body_txtLastName']")); } }

        public static By StreetAddress
        { get { return (By.XPath("//*[@id='Body_txtStreetAddress']")); } }

        public static By City
        { get { return (By.XPath("//*[@id='Body_txtCity']")); } }

        public static By Pin
        { get { return (By.XPath("//*[@id='Body_txtZipCode']")); } }

        public static By AddAddressBtn
        { get { return (By.XPath("//*[@id='Body_btnSave']")); } }

        public static By UploadAddress
        { get { return (By.XPath("//*[@id='Body_btnImportAddressList']")); } }

        public static By UploadFileBtn
        { get { return (By.XPath("//*[@class='ruFakeInput radPreventDecorate']")); } }

        public static By UploadListBtn
        { get { return (By.XPath("//*[@id='Body_btnUploadList']")); } }

        public static By SelectBtn
        { get { return (By.XPath("(//*[@id='ctl00_Body_radAsyncImportListfile0']")); } }

        public static By DownloadBtn
        { get { return (By.XPath("//*[@id='Body_btnDownload']")); } }

        Interactions action;
        public AddressListPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }
        //Verify Address List Page
        public void VerifyAddressListPage()
        {
            try
            {
                action.VerifyCurrentPage("AddressList", "AddressLists.aspx");
            }
            catch(Exception e)
            {
                Console.WriteLine("Verify Address list failed due to " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
        //Click on Adress List
        public void ClickOnImportAdressList()
        {
            try
            {
                action.ScrollToViewElement(ImportAddressList);
                action.WaitVisible(ImportAddressList);
                action.Click(ImportAddressList);
            }
            catch(Exception e)
            {
                Console.WriteLine("Click on Address list failed due to " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }


        //Verify Max Length for List name
        public void VerifyListnameMaxlength()
        {
            try
            {
                string listname = action.StringGenerator(100);
                action.WaitVisible(ListName);
                action.Type(ListName,listname);
                int lenghth_of_listname = listname.Length;
                Console.WriteLine("Length of account name is " + lenghth_of_listname);
                Assert.AreEqual(100,lenghth_of_listname);
                Console.WriteLine("Maximum field length for List Name meets requirement..");
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Max Length For List Name failed due to " + e);
                //**Closing browser
                Driver.Quit();
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
                Console.WriteLine("Status of search field is in Address List page " + status);
                Assert.IsTrue(status);
            }
            catch (Exception e)
            {
                Console.WriteLine("Verify Search Field failed due to: " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }

        //Add new Address to address list
        public void AddNewAddress()
        {
            try
            {
                action.WaitVisible(AddAddressLink);
                action.Click(AddAddressLink);
                action.WaitForPageToLoad();
                action.Type(CompanyName,"BrandMuscle");
                action.Type(FirstName,"mark");
                action.Type(LastName,"brad");
                action.Type(StreetAddress,"Street1");
                action.Type(City,"Chicago");
                action.Type(Pin,"153654");
                action.Click(AddAddressBtn);
            }
            catch(Exception e)
            {
                Console.WriteLine("Add new address failed due to: " + e);
                //**Closing browser
                Driver.Quit();
                throw e;
            }
        }
        //Upload New Address List
        public void UploadNewAddressList()
        {
            try
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
                string Dir = Path.GetDirectoryName(typeof(Base).Assembly.Location);
                action.WaitVisible(ListName);
                action.Type(ListName,"Test1");
                string addresslistpath = Dir + @"\InputFiles\ImportAddressListTemplate.csv";
                Driver.FindElement(ListName).SendKeys(OpenQA.Selenium.Keys.Tab+ OpenQA.Selenium.Keys.Enter);
                SendKeys.SendWait(@"C:\Users\dibyashree.jyoti\Desktop\ImportAddressListTemplate.csv");
                SendKeys.SendWait(@"{Enter}");
                //action.ClickJavaScript(UploadListBtn);
                jse.ExecuteScript("document.getElementById('Body_btnUploadList').click();");
                action.WaitTime(5);
            }
            catch(Exception e)
            {
                Console.WriteLine("Upload new address list failed due to: " + e);
                throw e;
            }
        }

        //Download Template File
        public void DownloadTemplateFile()
        {
            try
            {
                ICapabilities capabilities = ((RemoteWebDriver)Driver).Capabilities;
                String browserName = capabilities.BrowserName;
                Console.WriteLine(browserName);
                if(browserName == "chrome")
                {
                    action.Click(DownloadBtn);
                }
                else if(browserName == "firefox")
                {
                   action.Click(DownloadBtn);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Download  failed due to: " + e);
                throw e;
            }
           
        }




    }
}
