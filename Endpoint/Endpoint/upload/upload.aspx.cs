using Endpoint.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
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
                    
                    //string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    
                    string fileLocation = Server.MapPath("~/files/data.xlsx");

                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                          fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";

                    lblMessage.Text = "<br/>Arquivo processado.";

                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    FileUpload1.SaveAs(fileLocation);


                    OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = new OleDbCommand();

                    try
                    {

                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = conn;
                        OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
                        DataTable dtExcelRecords = new DataTable();
                        conn.Open();
                        DataTable dtExcelSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                        cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                        dAdapter.SelectCommand = cmd;
                        dAdapter.Fill(dtExcelRecords);
                        GridView1.DataSource = dtExcelRecords;
                        GridView1.DataBind();

                        lblMessage.Text = "<br/>Arquivo processado.";

                        lblMessage.ForeColor = System.Drawing.Color.Green;

                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    finally
                    {
                        conn.Close();
                    }


                }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Runcmdline run = new Runcmdline();

            string message = TextBox1.Text.Replace("\n", "</br>").Replace("\r", "");

            lblMessage.Text = "<br/>Contato realizado.";

            lblMessage.ForeColor = System.Drawing.Color.Green;

            run.executesendmstest(message);
        }
    }

}