using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Endpoint.Controllers
{
    public class Runcmdline
    {
        public string executesend(string number, string text)
        {
            string strFilePath = ConfigurationManager.AppSettings["strFilePath"];

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardError = true;
            psi.WorkingDirectory = ConfigurationManager.AppSettings["WorkingDirectory"]; ;

            try 
            { 
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(psi);

                System.IO.StreamReader strm = System.IO.File.OpenText(strFilePath);

                System.IO.StreamReader sOut = proc.StandardOutput;

                System.IO.StreamWriter sIn = proc.StandardInput;

                while (strm.Peek() != -1)
                    {
                        sIn.WriteLine(strm.ReadLine());
                    }

                strm.Close();

                sIn.WriteLine("NunitConsole\\nunit3-console.exe --testparam:number=\"" + number + "\" --testparam:text=\"" + text + "\" --where cat=\"AttachNavRequest\" whamess\\bin\\Debug\\whamess.dll");

                sIn.WriteLine("EXIT");

                proc.Close();

                string results = sOut.ReadToEnd().Trim();

                sIn.Close();

                sOut.Close();

                return "success!";
            }

            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }

        }

        public string executesendmstest(string message)
        {

            Encoding seuEncoding = Encoding.GetEncoding("Windows-1252");
            Encoding cp850 = Encoding.GetEncoding(850);

            byte[] cpBytes = cp850.GetBytes(message);
            string msg = seuEncoding.GetString(cpBytes);

            string strFilePath = ConfigurationManager.AppSettings["strFilePath"];

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardError = true;
            psi.WorkingDirectory = ConfigurationManager.AppSettings["WorkingDirectory"];

            try
            {
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(psi);

                System.IO.StreamReader strm = System.IO.File.OpenText(strFilePath);

                System.IO.StreamReader sOut = proc.StandardOutput;

                System.IO.StreamWriter sIn = proc.StandardInput;

                while (strm.Peek() != -1)
                {
                    sIn.WriteLine(strm.ReadLine());
                }

                strm.Close();



                sIn.WriteLine("NunitConsole\\nunit3-console.exe --testparam:text=\"" + msg + "\" --where cat=\"SendViaExcel\"  whamess\\bin\\Debug\\whamess.dll");

                sIn.WriteLine("EXIT");

                proc.Close();

                string results = sOut.ReadToEnd().Trim();

                sIn.Close();

                sOut.Close();

                string deletefile = ConfigurationManager.AppSettings["WorkingDirectory"] + "endpoint\\endpoint\\files\\data.xlsx";

                File.Delete(deletefile);

                return "success!";
            }

            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }

        }

    }
}

