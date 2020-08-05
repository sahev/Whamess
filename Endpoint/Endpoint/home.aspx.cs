using Endpoint.Controllers;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web.UI.WebControls;


namespace Endpoint.upload
{


    public partial class upload : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //    GetDataTable();
        }

        public void btnUpload_Click(object sender, EventArgs e)
        {

            if (!FileUpload1.HasFile)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "uploadstatus('question','Cadê o arquivo?')", true);
            }

                if (FileUpload1.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                if (fileExtension.ToLower() != ".xls" && fileExtension.ToLower() != ".xlsx")
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "", "uploadstatus('warning','Somente arquivos .xls ou .xlsx permitidos :(')", true);

                }
                else
                {


                    string fileLocation = Server.MapPath("~/files/data.xlsx");

                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                          fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";

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

                        lblmessage.Text = "Pré-visualização do arquivo:";

                        ClientScript.RegisterStartupScript(this.GetType(), "", "uploadstatus('success','Arquivo Processado')", true);

                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "uploadstatus('error,'"+ex+")", true);
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

            string fileLocation = Server.MapPath("~/files/data.xlsx");

            string message = TextBox1.Text.Replace("\n", "</br>").Replace("\r", "");

            if (message == "" || message == " " || message == null)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "", "uploadstatus('warning','Insira uma mensagem!')", true);
            }
            else if (!File.Exists(fileLocation))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "uploadstatus('warning','Insira um arquivo!')", true);
            }
            else if (message.Contains("{7}") || message.Contains("{8}") || message.Contains("{9}"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "uploadstatus('warning','Sua variável deve ser menor ou igual que {6}')", true);
            } else
            { 
                run.executesendmstest(message);
                ClientScript.RegisterStartupScript(this.GetType(), "", "uploadstatus('success','Mensagem enviada! ;)')", true);
            }

        }


        public void GetDataTable()
        {

            string fileLocation = Server.MapPath("~/files/data.xlsx");

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                  fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";

            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();

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

            conn.Close();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetDataTable();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "info()", true);
        }
    }
}