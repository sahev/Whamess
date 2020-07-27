using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Polly;
using System;


namespace whamess
{
    class AttachResquest 
    {
        public IWebDriver Driver { get; set; }

        public void AttachRequestMessageToChrome()
        {
            ChromeOptions options = new ChromeOptions();
            options.DebuggerAddress = "127.0.0.1:9222";

            var policy = Policy
              .Handle<InvalidOperationException>()
              .WaitAndRetry(10, t => TimeSpan.FromSeconds(1));

            policy.Execute(() =>
            {

                Driver = new RemoteWebDriver(new Uri("http://192.168.254.128:5555/wd/hub"), options);

            });
        }
    }
}
