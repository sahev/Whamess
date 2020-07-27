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

            // Using Polly library: https://github.com/App-vNext/Polly
            // Polly probably isn't needed in a single scenario like this, but can be useful in a broader automation project
            // Once we attach to Chrome with Selenium, use a WebDriverWait implementation
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
