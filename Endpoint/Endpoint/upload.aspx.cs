using Endpoint.Controllers;
using System;
using System.Data;
using System.Data.OleDb;
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
                lblMessage.Text = "Selecione um arquivo!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

                if (FileUpload1.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                if (fileExtension.ToLower() != ".xls" && fileExtension.ToLower() != ".xlsx")
                {
                    lblMessage.Text = "Somente arquivos .xls ou .xlsx permitidos";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {


                    string fileLocation = Server.MapPath("~/files/data.xlsx");

                    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                          fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";

                    lblMessage.Text = "Arquivo processado.";

                    lblMessage.CssClass = "Mensagens enviadas com sucesso!";

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
            
            if(message == "" || message == " " || message == null)
            {
                
                ClientScript.RegisterStartupScript(this.GetType(), "ramdomtext", "campaigninsuccess()", true);
            }
            else
                run.executesendmstest(message);
                ClientScript.RegisterStartupScript(this.GetType(), "ramdomtext", "campaignsuccess()", true);
                

        }


        public void GetDataTable()
        {

            string fileLocation = @"C:\samuel\Whamess\Endpoint\Endpoint\files\data.xlsx";

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ramdomtext", "uploadbtn()", true);


        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ramdomtext", "info()", true);
        }
    }
}