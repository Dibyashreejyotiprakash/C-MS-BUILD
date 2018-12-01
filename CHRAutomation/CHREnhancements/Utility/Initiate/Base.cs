using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;

namespace CHREnhancements.Initiate
{
    [SetUpFixture]
    public class Base
    {
        public IWebDriver Driver;
        DesiredCapabilities capability = new DesiredCapabilities();
        string Dir = Path.GetDirectoryName(typeof(Base).Assembly.Location);
        public void BrowserSetUp(string BrowserName)
        {
            if (BrowserName.Equals("chrome"))
            {
                Driver = new ChromeDriver(Dir + @"\Assets");
                Driver.Manage().Window.Maximize();
            }
            else if (BrowserName.Equals("ie"))
            {
                capability.SetCapability("EnableNativeEvents", false);
                capability.SetCapability("ignoreZoomSetting", true);
                Driver = new InternetExplorerDriver(Dir + @"\Assets");
                Driver.Manage().Window.Maximize();
            }
            else if (BrowserName.Equals("firefox"))
            {
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Dir +@"\Assets");
                Driver = new FirefoxDriver(service);
                Driver.Manage().Window.Maximize();
            }
            else if (BrowserName.Equals("edge"))
            {
                EdgeDriverService service = EdgeDriverService.CreateDefaultService(Dir + @"\Assets");
                Driver = new EdgeDriver(service);
                Driver.Manage().Window.Maximize();
            }
            else if(BrowserName.Equals("safari"))
            {
                SafariDriverService service = SafariDriverService.CreateDefaultService();
                Driver = new SafariDriver(service);
                Driver.Manage().Window.Maximize();
            }
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }

        public static IEnumerable<String> BrowserToRunWith()
        {
            string[] browsers = BrowserName.browsers.Split(',');

            foreach (String browsername in browsers)
            {
                yield return browsername;
            }
        }
    }
}
