using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using whamess;

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
        [NUnit.Framework.CategoryAttribute("AttachNavRequest")]
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

        [Test]
        [NUnit.Framework.CategoryAttribute("SendViaExcel")]
        public void SendViaExcel()
        {

            string messs = NUnit.Framework.TestContext.Parameters.Get("text");
            //string messs = "telefone {0} nome {1} pedido {2} email {3} produto {4} posicao5 {5} posicao6 {6}";

            Page.AttachRequestMessageToChrome();

            readfile readd = new readfile();

            List<data> listdata = readd.Readfiledata();

            foreach (var a in listdata)
            {
                string number = "55" + a.Number;
                string name = a.Name;
                string v2 = a.v2;
                string v3 = a.v3;
                string v4 = a.v4;
                string v5 = a.v5;
                string v6 = a.v6;

                string script = String.Format(messs, number, name, v2, v3, v4, v5, v6);

                //System.Console.WriteLine(messs);

                string jsnumber = "const openChat = phone =>{ const link = document.createElement('a'); link.setAttribute('href', 'whatsapp://send?phone=" + number + "'); document.body.append(link);link.click(); document.body.removeChild(link); }; openChat();";

                string jstext =
                    "var eventFire = (MyElement, ElementType) => " +
                        "{ var MyEvent = document.createEvent(\"MouseEvents\"); " +
                        "MyEvent.initMouseEvent (ElementType, true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null); " +
                        "MyElement.dispatchEvent(MyEvent); }; " +
                    "function myFunc() " +
                        "{ " +
                        "messageBox = document.querySelectorAll(\"[contenteditable='true']\")[1]; " +
                        "message = \"" + script + "\"; event = document.createEvent(\"UIEvents\"); " +
                        "messageBox.innerHTML = message.replace(/ /gm, ' '); " +
                        "event.initUIEvent(\"input\", true, true, window, 1); " +
                        "messageBox.dispatchEvent(event); " +
                        "eventFire(document.querySelector('span[data-icon=\"send\"]'), 'click'); " +
                        "}; " +
                    "myFunc();";

                //System.Console.WriteLine(String.Format("Number: {0} Name: {1} Var1: {2} Var2: {3} Var3: {4} Var4: {5} Var5: {6} ", a.Number, a.Name, a.v2, a.v3, a.v4, a.v5, a.v6));


                ((IJavaScriptExecutor)Page.Driver).ExecuteScript(jsnumber);

                Thread.Sleep(200);

                ((IJavaScriptExecutor)Page.Driver).ExecuteScript(jstext);

            }
        }
      
        private Window Window => new Window();
        public AttachResquest Page { get;  } = new AttachResquest();
  
    }
}
