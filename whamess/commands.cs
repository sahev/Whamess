using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace whamess
{
    class commands
    {

        #region Browser & Login

        public static IWebDriver GetBrowserLocal(IWebDriver driver, String browser, String number)
        {
            switch (browser)
            {
                case "chrome":

                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--disable-extensions");
                    options.AddArguments("--user-data-dir=C:/Users/user_data");
                    driver = new ChromeDriver(options);

                    break;

            }

            driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=" + Uri.EscapeDataString(number));
            //{
            //    WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(2));
            //    wait.Until(driver => driver.FindElement(By.Id("Login1_UserName")).Enabled);
            //}
            Thread.Sleep(5000);



            return driver;
        }

        #endregion

        #region Remote Browser
        public static IWebDriver GetBrowserRemote(IWebDriver driver, String browser, String number, String uri)
        {


            switch (browser)
            {
                case "chrome":

                    ChromeOptions rem_chrome = new ChromeOptions();
                    rem_chrome.AddArguments("--disable-extensions");
                    rem_chrome.AddArguments("--user-data-dir=C:/Users/vmbox-1/Desktop/user_data");
                    driver = new RemoteWebDriver(new Uri(uri), rem_chrome);

                    break;
            }

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=" + Uri.EscapeDataString(number));
                //driver.Navigate().GoToUrl("chrome://version");
                //Thread.Sleep(5000);
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".\\_2UL8j > .\\_3FRCZ")));
                //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("docker_screenshot.png", ScreenshotImageFormat.Png);

            }
            catch(Exception e)
            {
                //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("docker_screenshot.png", ScreenshotImageFormat.Png);
                Console.WriteLine(e.StackTrace);
                
            }
            

            //Thread.Sleep(5000);

            return driver;

        }
        #endregion
    }
}
