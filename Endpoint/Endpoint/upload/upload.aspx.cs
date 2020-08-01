using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Endpoint.upload
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
           
            if(FileUpload1.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                if(fileExtension.ToLower() != ".xls" && fileExtension.ToLower() != ".xlsx")
                {
                    lblMessage.Text = "<br/>Somente arquivos .xls ou .xlsx permitidos";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("~/files/" + FileUpload1.FileName));
                    
                    lblMessage.Text = "<br/>Processando e enviando mensagens...";
                    
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    executesend();
                }
            }


        }

        public string executesend()
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

                sIn.WriteLine("NunitConsole\\nunit3-console.exe --where cat=\"SendViaExcel\" whamess\\bin\\Debug\\whamess.dll");

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

    }

  
}