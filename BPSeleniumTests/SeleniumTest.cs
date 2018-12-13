// automated user acceptance testing using Selenium
// C# binding to WebDriver (Selenium 2.0)
// tests app deployed on Azure e.g. http://gc-temperatureconverter-qa.azurewebsites.net
// as in runsettings file (SeleniumTest.runsettings)

// MSTest
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

// NuGet install Selenium WebDriver package and Support Classes
using OpenQA.Selenium;

// NuGet install PhantomJS driver (or Chrome or Firefox...)
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumUnitTest
{
    [TestClass]
    public class SeleniumUnitTest1
    {
        private string _url;
       // private TestContext testContextInstance;
        /*
        // .runsettings file contains test run parameters
        // e.g. URI for app
        // test context for this run

        private TestContext testContextInstance;

        // test harness uses this property to initliase test context
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        // URI for web app being tested
        private String webAppUri;

        // .runsettings property overriden in vsts test runner
        // release task
        [TestInitialize]                // run before each unit test
        public void Setup()
        {
            this.webAppUri = testContextInstance.Properties["webAppUri"].ToString();
        }

        // one unit test
        */
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

       
        [TestInitialize]
        public void TestInit() {
        }
        [TestMethod]
        public void TestForLowBP()
        {
            // Init the driver
            IWebDriver driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));


            string webAppUrl = TestContext.Properties["appURL"].ToString();
            Console.WriteLine(webAppUrl);
          //  Console.WriteLine("derp derp derp");
          //  Console.WriteLine(webAppUrl);
            // navigate to URI for Blood Pessure Converter
          //  var webAppUrl = context.Properties["this._url"].ToString();
            driver.Navigate().GoToUrl(webAppUrl);

            // get form elements
           
            IWebElement systolicElement = driver.FindElement(By.Id("BP_Systolic"));

            // clear elements and enter new values 

            systolicElement.Click();
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys("81");
            // diastolicElement;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement form1 = driver.FindElement(By.Id("form1"));
            form1.Submit();
            IWebElement diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicElement.Click();
            diastolicElement.Clear();

            diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
          
            diastolicElement.SendKeys("44");
         
          // reinitialise element as it disappears and reappears when form (auto) submitted
             systolicElement = driver.FindElement(By.Id("BP_Systolic"));
               systolicElement.Click();

            // Find result       
            string bpResult = driver.FindElement(By.XPath("//form[@id='form1']/div[3]")).Text;
            // Check result

            Assert.AreEqual(bpResult, "Low Blood Pressure");


            driver.Quit();

        }
        [TestMethod]
        public void TestForNormalBP()
        {
            // Init the driver
            IWebDriver driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));



            // navigate to URI for Blood Pessure Converter
            string webAppUrl = TestContext.Properties["appURL"].ToString();
            driver.Navigate().GoToUrl(webAppUrl);

            // get form elements

            IWebElement systolicElement = driver.FindElement(By.Id("BP_Systolic"));

            // clear elements and enter new values 

            systolicElement.Click();
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys("90");
            // diastolicElement;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement form1 = driver.FindElement(By.Id("form1"));
            form1.Submit();
            IWebElement diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicElement.Click();
            diastolicElement.Clear();

            diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));

            diastolicElement.SendKeys("60");

            // reinitialise element as it disappears and reappears when form (auto) submitted
            systolicElement = driver.FindElement(By.Id("BP_Systolic"));
            systolicElement.Click();

            // Find result       
            string bpResult = driver.FindElement(By.XPath("//form[@id='form1']/div[3]")).Text;
            // Check result

            Assert.AreEqual(bpResult, "Normal Blood Pressure");


            driver.Quit();

        }
        [TestMethod]
        public void TestForPreHighBP()
        {
            // Init the driver
            IWebDriver driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));



            // navigate to URI for Blood Pessure Converter

            string webAppUrl = TestContext.Properties["appURL"].ToString();
            driver.Navigate().GoToUrl(webAppUrl);
            // get form elements

            IWebElement systolicElement = driver.FindElement(By.Id("BP_Systolic"));

            // clear elements and enter new values 

            systolicElement.Click();
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys("120");
            // diastolicElement;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement form1 = driver.FindElement(By.Id("form1"));
            form1.Submit();
            IWebElement diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicElement.Click();
            diastolicElement.Clear();

            diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));

            diastolicElement.SendKeys("80");

            // reinitialise element as it disappears and reappears when form (auto) submitted
            systolicElement = driver.FindElement(By.Id("BP_Systolic"));
            systolicElement.Click();

            // Find result       
            string bpResult = driver.FindElement(By.XPath("//form[@id='form1']/div[3]")).Text;
            // Check result

            Assert.AreEqual(bpResult, "Pre-High Blood Pressure");


            driver.Quit();

        }
        [TestMethod]
        public void TestForHighBP()
        {
            // Init the driver
            IWebDriver driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));



            // navigate to URI for Blood Pessure Converter

            string webAppUrl = TestContext.Properties["appURL"].ToString();
            driver.Navigate().GoToUrl(webAppUrl);
            // get form elements

            IWebElement systolicElement = driver.FindElement(By.Id("BP_Systolic"));

            // clear elements and enter new values 

            systolicElement.Click();
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys("140");
            // diastolicElement;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement form1 = driver.FindElement(By.Id("form1"));
            form1.Submit();
            IWebElement diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicElement.Click();
            diastolicElement.Clear();

            diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));

            diastolicElement.SendKeys("90");

            // reinitialise element as it disappears and reappears when form (auto) submitted
            systolicElement = driver.FindElement(By.Id("BP_Systolic"));
            systolicElement.Click();

            // Find result       
            string bpResult = driver.FindElement(By.XPath("//form[@id='form1']/div[3]")).Text;
            // Check result

            Assert.AreEqual(bpResult, "High Blood Pressure");


            driver.Quit();

        }
        [TestMethod]
        public void TestForNormalTip()
        {
            // Init the driver
            IWebDriver driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));



            // navigate to URI for Blood Pessure Converter
            string webAppUrl = TestContext.Properties["appURL"].ToString();
            driver.Navigate().GoToUrl(webAppUrl);

            // get form elements

            IWebElement systolicElement = driver.FindElement(By.Id("BP_Systolic"));

            // clear elements and enter new values 

            systolicElement.Click();
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys("90");
            // diastolicElement;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement form1 = driver.FindElement(By.Id("form1"));
            form1.Submit();
            IWebElement diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicElement.Click();
            diastolicElement.Clear();

            diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));

            diastolicElement.SendKeys("60");

            // reinitialise element as it disappears and reappears when form (auto) submitted
            systolicElement = driver.FindElement(By.Id("BP_Systolic"));
            systolicElement.Click();

            // Find result       
            string bpResult = driver.FindElement(By.XPath("//form[@id='form1']/div[4]")).Text;
            // Check result

            Assert.AreEqual(bpResult, "Keep up the good work!");


            driver.Quit();

        }
        [TestMethod]
        public void TestForLowTip()
        {
            // Init the driver
            IWebDriver driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));


            string webAppUrl = TestContext.Properties["appURL"].ToString();
            Console.WriteLine(webAppUrl);
            //  Console.WriteLine("derp derp derp");
            //  Console.WriteLine(webAppUrl);
            // navigate to URI for Blood Pessure Converter
            //  var webAppUrl = context.Properties["this._url"].ToString();
            driver.Navigate().GoToUrl(webAppUrl);

            // get form elements

            IWebElement systolicElement = driver.FindElement(By.Id("BP_Systolic"));

            // clear elements and enter new values 

            systolicElement.Click();
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys("81");
            // diastolicElement;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement form1 = driver.FindElement(By.Id("form1"));
            form1.Submit();
            IWebElement diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicElement.Click();
            diastolicElement.Clear();

            diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));

            diastolicElement.SendKeys("44");

            // reinitialise element as it disappears and reappears when form (auto) submitted
            systolicElement = driver.FindElement(By.Id("BP_Systolic"));
            systolicElement.Click();

            // Find result       
            string bpResult = driver.FindElement(By.XPath("//form[@id='form1']/div[4]")).Text;
            // Check result

            Assert.AreEqual(bpResult, "TIP: Factor some salt into your diet, eat healthy fruits and grains and consult a physician.");


            driver.Quit();

        }
        [TestMethod]
        public void TestForHighTip()
        {
            // Init the driver
            IWebDriver driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));



            // navigate to URI for Blood Pessure Converter

            string webAppUrl = TestContext.Properties["appURL"].ToString();
            driver.Navigate().GoToUrl(webAppUrl);
            // get form elements

            IWebElement systolicElement = driver.FindElement(By.Id("BP_Systolic"));

            // clear elements and enter new values 

            systolicElement.Click();
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys("140");
            // diastolicElement;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement form1 = driver.FindElement(By.Id("form1"));
            form1.Submit();
            IWebElement diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicElement.Click();
            diastolicElement.Clear();

            diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));

            diastolicElement.SendKeys("90");

            // reinitialise element as it disappears and reappears when form (auto) submitted
            systolicElement = driver.FindElement(By.Id("BP_Systolic"));
            systolicElement.Click();

            // Find result       
            string bpResult = driver.FindElement(By.XPath("//form[@id='form1']/div[4]")).Text;
            // Check result

            Assert.AreEqual(bpResult, "Consult a physician.");


            driver.Quit();

        }
        [TestMethod]
        public void TestForPreHighTip()
        {
            // Init the driver
            IWebDriver driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));



            // navigate to URI for Blood Pessure Converter

            string webAppUrl = TestContext.Properties["appURL"].ToString();
            driver.Navigate().GoToUrl(webAppUrl);
            // get form elements

            IWebElement systolicElement = driver.FindElement(By.Id("BP_Systolic"));

            // clear elements and enter new values 

            systolicElement.Click();
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Backspace);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys(Keys.Delete);
            systolicElement.SendKeys("120");
            // diastolicElement;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement form1 = driver.FindElement(By.Id("form1"));
            form1.Submit();
            IWebElement diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicElement.Click();
            diastolicElement.Clear();

            diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));

            diastolicElement.SendKeys("80");

            // reinitialise element as it disappears and reappears when form (auto) submitted
            systolicElement = driver.FindElement(By.Id("BP_Systolic"));
            systolicElement.Click();

            // Find result       
            string bpResult = driver.FindElement(By.XPath("//form[@id='form1']/div[4]")).Text;
            // Check result

            Assert.AreEqual(bpResult, "TIP: Reduce weight, increase exercise and reduce alcohol consumption.");


            driver.Quit();

        }
    }
}
