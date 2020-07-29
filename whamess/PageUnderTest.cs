using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Polly;
using System;
using System.Configuration;


namespace whamess
{
    class AttachResquest 
    {
        public IWebDriver Driver { get; set; }

        public void AttachRequestMessageToChrome()
        {
            ChromeOptions options = new ChromeOptions();
            options.DebuggerAddress = ConfigurationManager.AppSettings["DebuggerAddress"];

            var policy = Policy
              .Handle<InvalidOperationException>()
              .WaitAndRetry(10, t => TimeSpan.FromSeconds(1));

            policy.Execute(() =>
            {
                string UriRemoteWebDriver = ConfigurationManager.AppSettings["UriRemoteWebDriver"];
                Driver = new RemoteWebDriver(new Uri(UriRemoteWebDriver), options);

            });
        }
    }
}
