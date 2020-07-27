using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using System.Windows;


namespace whamess
{

    class SendMessage
    {

        [TearDown]
        public void Close()
        {
            Page.Driver.Quit();
        }

        [Test]
        public void AttachNavRequest()
        {

            string text = NUnit.Framework.TestContext.Parameters.Get("text");

            string num = NUnit.Framework.TestContext.Parameters.Get("number");

            string jsnumber = "const openChat = phone =>{ const link = document.createElement('a'); link.setAttribute('href', 'whatsapp://send?phone=" + num + "'); document.body.append(link);link.click(); document.body.removeChild(link); }; openChat();";

            string jstext = 
                "var eventFire = (MyElement, ElementType) => " +
                    "{ var MyEvent = document.createEvent(\"MouseEvents\"); " +
                    "MyEvent.initMouseEvent (ElementType, true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null); " +
                    "MyElement.dispatchEvent(MyEvent); }; " +
                "function myFunc() " +
                    "{ " +
                    "messageBox = document.querySelectorAll(\"[contenteditable='true']\")[1]; " +
                    "message = \"" + text + "\"; event = document.createEvent(\"UIEvents\"); " +
                    "messageBox.innerHTML = message.replace(/ /gm, ' '); " +
                    "event.initUIEvent(\"input\", true, true, window, 1); " +
                    "messageBox.dispatchEvent(event); " +
                    "eventFire(document.querySelector('span[data-icon=\"send\"]'), 'click'); " +
                    "}; " +
                "myFunc();";


            Page.AttachRequestMessageToChrome();

            ((IJavaScriptExecutor)Page.Driver).ExecuteScript(jsnumber);

            Thread.Sleep(200);

            ((IJavaScriptExecutor)Page.Driver).ExecuteScript(jstext);
            
        }
        private Window Window => new Window();
        public AttachResquest Page { get; } = new AttachResquest();
  
    }
}
