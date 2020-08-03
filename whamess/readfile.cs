using interop = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace whamess
{

    public class readfile {

        private string GetValueOrDefault(string data)
        {

            if (string.IsNullOrEmpty(data))
            {
                return "0";
            }
            return data;
        }

        public List<data> Readfiledata()
        {


            string basePath = Environment.CurrentDirectory;

            string fullpath = basePath + "\\endpoint\\endpoint\\files\\" + ConfigurationManager.AppSettings["filepath"];

            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fullpath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'");

            string command = "select * from [Vendas$]";
            
            OleDbCommand comando = new OleDbCommand(command, conn);

            List<data> listdata = new List<data>();


            try
            {
                conn.Open();
                OleDbDataReader rd = comando.ExecuteReader();
               
                Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
                var wb = xl.Workbooks.Open(fullpath);

                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets["Vendas"];

                string number = ws.Range["A1"].Value;
                string name = ws.Range["B1"].Value;
                string var2 = ws.Range["C1"].Value;
                string var3 = ws.Range["D1"].Value;
                string var4 = ws.Range["E1"].Value;
                string var5 = ws.Range["F1"].Value;
                string var6 = ws.Range["G1"].Value;

                while (rd.Read())
                {
                    if (rd["Telefone"].ToString() != "")
                    {
                        listdata.Add(new data()
                        {
                            Number = rd[number].ToString(),
                            Name = rd[name].ToString(),

                            v2 = var2 != null ? rd[var2].ToString() : null,
                            v3 = var3 != null ? rd[var3].ToString() : null,
                            v4 = var4 != null ? rd[var4].ToString() : null,
                            v5 = var5 != null ? rd[var5].ToString() : null,
                            v6 = var6 != null ? rd[var6].ToString() : null

                        }); 
                    }
                }

                if (listdata.Count() > 0)
                    return listdata;
                else
                    return null;
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Erro: " + e.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }


    }



    public class data
    {
        public string Number { get; set; } 
        public string Name { get; set; }
        public string v2 { get; set; } 
        public string v3 { get; set; } 
        public string v4 { get; set; } 
        public string v5 { get; set; } 
        public string v6 { get; set; } 

    }
}
