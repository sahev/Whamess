using Endpoint.Controllers;
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


        public void btnUpload_Click(object sender, EventArgs e)
        {

            Runcmdline run = new Runcmdline();

            if (FileUpload1.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                if (fileExtension.ToLower() != ".xls" && fileExtension.ToLower() != ".xlsx")
                {
                    lblMessage.Text = "<br/>Somente arquivos .xls ou .xlsx permitidos";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    FileUpload1.SaveAs(Server.MapPath("~/files/" + "data.xlsx"));

                    lblMessage.Text = "<br/>Arquivo processado e campanha finalizada.";

                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    string message = TextBox1.Text.Replace("\n", "</br>").Replace("\r","");

                    run.executesendmstest(message);

                }

            }

        }

    }

}