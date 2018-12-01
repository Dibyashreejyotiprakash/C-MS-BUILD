using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace CHREnhancements.Initiate
{
    [SetUpFixture]
    public class Base
    {

        public IWebDriver Driver;
        DesiredCapabilities capability = new DesiredCapabilities();

        string Dir = Path.GetDirectoryName(typeof(Base).Assembly.Location);
        public string getBrowser()
        {
            string browsername = ConfigurationManager.AppSettings["BROWSER"].ToString();
            return browsername;
        }

        public void BrowserSetUp()
        {
            string BrowserName = getBrowser();
            switch (BrowserName)
            {
                case "Chrome":
                    Driver = new ChromeDriver(Dir + @"\Assets");
                    Driver.Manage().Window.Maximize();
                    break;
                case "Firefox":
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Dir + @"\Assets");
                    Driver = new FirefoxDriver(service);
                    Driver.Manage().Window.Maximize();
                    break;
                case "IE":
                    capability.SetCapability("EnableNativeEvents", false);
                    capability.SetCapability("ignoreZoomSetting", true);
                    Driver = new InternetExplorerDriver(Dir + @"\Assets");
                    Driver.Manage().Window.Maximize();
                    break;
                case "Edge":
                    EdgeDriverService service2 = EdgeDriverService.CreateDefaultService(Dir + @"\Assets");
                    Driver = new EdgeDriver(service2);
                    Driver.Manage().Window.Maximize();
                    break;
                case "Safari":
                    SafariDriverService service1 = SafariDriverService.CreateDefaultService();
                    Driver = new SafariDriver(service1);
                    Driver.Manage().Window.Maximize();
                    break;
                default:
                    Driver = new ChromeDriver(Dir + @"\Assets");
                    Driver.Manage().Window.Maximize();
                    break;
            }

        }

        public string GetEnvironment()
        {
            string environment = ConfigurationManager.AppSettings["ENVIRONMENT"].ToString();
            return environment;


        }

        public void GetUrl(string BuName)
        {
            try
            {
                if (BuName.ToUpper().Contains("INSTANTIMPACT"))
                {
                    string EnvironmentName = GetEnvironment();
                    if (EnvironmentName.Equals("UAT"))
                    {
                        Driver.Url = ConfigurationManager.AppSettings["URLUAT"].ToString().Trim();
                    }
                    else if (EnvironmentName.Equals("STAGING"))
                    {
                        Driver.Url = ConfigurationManager.AppSettings["URLSTAGE"].ToString().Trim();
                    }
                    else if (EnvironmentName.Equals("PROD"))
                    {
                        Driver.Url = ConfigurationManager.AppSettings["URLPROD"].ToString().Trim();
                    }
                }
                else if (BuName.ToUpper().Contains("PROOFGALLERY"))
                {
                    string EnvironmentName = GetEnvironment();
                    if (EnvironmentName.Equals("UAT"))
                    {
                        Driver.Url = ConfigurationManager.AppSettings["URLPGUAT"].ToString().Trim();
                    }
                    else if (EnvironmentName.Equals("STAGING"))
                    {
                        Driver.Url = ConfigurationManager.AppSettings["URLPGSTAGE"].ToString().Trim();
                    }
                    else if (EnvironmentName.Equals("PROD"))
                    {
                        Driver.Url = ConfigurationManager.AppSettings["URLPGPROD"].ToString().Trim();
                    }
                    else if (EnvironmentName.Equals("DEV"))
                    {
                        Driver.Url = ConfigurationManager.AppSettings["URLPGDEV"].ToString().Trim();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("GetUrl failed due to " + e);

            }
        }

        [TearDown]
        public void CleanUp()
        {
            Driver.Quit();
        }

    }
}
