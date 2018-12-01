using System;
using OpenQA.Selenium;
using CHREnhancements.Initiate;
using CHREnhancements.Interaction;
using OpenQA.Selenium.Support.PageObjects;

namespace CHREnhancements.PageObject.InstantImpact.ImportAddressListPage
{
    public class ImportAddressListPage : Base
    {
        public static By SelectBtn
        { get { return (By.XPath("//*[@id='ctl00_Body_radAsyncImportListfile0']")); } }

        Interactions action;
        public ImportAddressListPage(IWebDriver Driver)
        {
            this.Driver = Driver;
            PageFactory.InitElements(Driver, this);
            action = new Interactions(Driver);
        }

        //Download Sample Temlate
        public void DownloadSampletemplate()
        {
            try
            {

            }
            catch(Exception e)
            {
                Console.WriteLine("Download Sample template failed due to " + e);
                throw e;
            }
        }

        //Upload New CSV File
        public void UploadAdddressList()
        {
            try
            {
                action.Click(SelectBtn);
            }
            catch(Exception e)
            {
                Console.WriteLine("Upload Addresslist failed due to " + e);
                throw e;
            }
        }
    }
}