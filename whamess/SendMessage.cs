using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
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

            string message = NUnit.Framework.TestContext.Parameters.Get("text");

            Page.AttachRequestMessageToChrome();

            readfile readd = new readfile();

            List<data> listdata = readd.Readfiledata();

            foreach (var a in listdata)
            {
                string name = a.Name;
                string num = "55" + a.Number;
                string prod = a.Product;
                string req = a.Request;


                string script = String.Format(@""+message+"", name, prod, req);

                //string mess = @"Boa Tarde, *" + text + "* <br/>" +
                //    "Tudo bem?  <br/>" +
                //    "<br/>Somos da Beco Nerd, vimos que realizou uma compra em nosso site para a *" + prod + "*, ***(Pedido *#" + req + "*) até o momento não identificamos o pagamento, então passamos aqui para lembrar e enviar uma segunda via de boleto. <br/>" +
                //    "<br/>Você não pode perder a chance de ter essa caneca em sua coleção, nossos estoques estão acabando, estamos vendendo muito essa caneca, então para dar uma forcinha segue um cupom de desconto LUFABECO1, correeee e não perde essa super oportunidade. <br/>" +
                //    "<br/>Link Caneca Mapa do Maroto: *https://www.beconerd.com.br/produtos/algum-produto-listado-em-algum-lugar  <br/>" +
                //    "<br/>Obs: Se realizou o pagamento do boleto, por favor, desconsiderar essa mensagem, e se necessário entrar em contato conosco, para entendermos com o Pagseguro o motivo do valor não ter compensado para nós. <br/>" +
                //    "<br/>Equipe Beco Nerd.";


                string jsnumber = "const openChat = phone =>{ const link = document.createElement('a'); link.setAttribute('href', 'whatsapp://send?phone=" + num + "'); document.body.append(link);link.click(); document.body.removeChild(link); }; openChat();";

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

                System.Console.WriteLine(String.Format("Number: {0} Name: {1}", a.Number, a.Name));


                ((IJavaScriptExecutor)Page.Driver).ExecuteScript(jsnumber);

                Thread.Sleep(200);

                ((IJavaScriptExecutor)Page.Driver).ExecuteScript(jstext);

            }
        }
      
        private Window Window => new Window();
        public AttachResquest Page { get; } = new AttachResquest();
  
    }
}
