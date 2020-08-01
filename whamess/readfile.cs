using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace whamess
{


    public class readfile {

        public List<data> Readfiledata()
        {
            string filepath = ConfigurationManager.AppSettings["filepath"];
            string pathh = Path.GetDirectoryName(filepath);
            
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'");

            string command = "select * from [Vendas$]";
            
            OleDbCommand comando = new OleDbCommand(command, conn);

            List<data> listdata = new List<data>();


            try
            {
                conn.Open();
                OleDbDataReader rd = comando.ExecuteReader();
                while (rd.Read())
                {
                    if (rd["Telefone"].ToString() != "")
                    {
                        listdata.Add(new data()
                        {
                            Number = rd["Telefone"].ToString(),
                            Name = rd["Nome do comprador"].ToString(),
                            Product = rd["Nome do Produto"].ToString(),
                            Request = rd["Número do Pedido"].ToString()
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
        public string Name { get; set; }
        public string Number { get; set; }
        public string Product { get; set; }
        public string Request { get; set; }
        
    }
}
