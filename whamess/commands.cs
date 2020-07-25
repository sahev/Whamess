using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Threading;

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
                    options.AddArgument("--disable-extensions");
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
                    rem_chrome.AddArgument("--disable-extensions");
                    rem_chrome.AddArguments("--user-data-dir=/tmp/Default");
                    driver = new RemoteWebDriver(new Uri(uri), rem_chrome);

                    break;
            }

            try
            {

                driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=" + Uri.EscapeDataString(number));
                //driver.Navigate().GoToUrl("chrome://version");
                Thread.Sleep(10000);
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("1.png", ScreenshotImageFormat.Png);

            }
            catch(Exception e)
            {
                //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("1.png", ScreenshotImageFormat.Png);
                Console.WriteLine(e.StackTrace);
                
            }
            

            Thread.Sleep(5000);

            return driver;

        }
        #endregion
    }
}
