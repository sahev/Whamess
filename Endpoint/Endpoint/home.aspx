<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Endpoint.upload.upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="styles/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.5.1.js"></script>
    <script src="Scripts/jquery.bootpag.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
    <script src="scripts/scripts.js"></script>

</head>
<body>
   
       <form id="form1" runat="server" class="control-label"> 
           <br />
            <div style="width:50%; margin-left:auto;margin-right:auto; height: 70px;">
                    <asp:FileUpload ID="FileUpload1" class="btn btn-info" runat="server" Font-Names="Helvetica" Style="display: inline-block; float: left;" Width="200px"/>
                    <asp:Button ID="btnUpload" runat="server" class="btn btn-info" Text="Processar" OnClick="btnUpload_Click" Style="float: right; display: inline-block;" />

            </div>
            <div style="width:670px;margin-left:auto;margin-right:auto;">
            
                &nbsp;
            
                <asp:Label ID="lblmessage" runat="server" Font-bold="true" TextMode="MultiLine" font-names="Helvetica" Wrap="true" >
            </asp:Label>
                <asp:GridView ID="GridView1" runat="server" style="height:180px; width:98%; margin-left:auto;margin-right:auto;" CssClass="table table-striped table-bordered table-condensed" AllowPaging="True" PageSize="5"  OnPageIndexChanging="GridView1_PageIndexChanging" >
                </asp:GridView>
            </div>
      
       
            <div style="width:50%; margin-left:auto;margin-right:auto;" aria-grabbed="undefined" aria-orientation="horizontal" aria-sort="none">
            <asp:Label ID="Label1" runat="server" Font-bold="true" TextMode="MultiLine" font-names="Helvetica" Wrap="true" >Script:
            </asp:Label>
        
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Digite sua mensagem aqui" font-names="Helvetica" style="height:180px; width:98%; margin-left:auto;margin-right:auto;"
                TextMode="MultiLine" wrap="true" ></asp:TextBox>
                <br /><br />

                <div>
                    <asp:Button ID="Button2" class="btn btn-info" Style="display: inline-block; float: left;" runat="server" Text="Info" OnClick="Button2_Click1" Width="80px" />

                    <asp:Button ID="Button1" class="btn btn-success" Style="float: right; display: inline-block;" runat="server" Text="Enviar" OnClick="Button1_Click" />
                </div>
             </div>

     </form>

      <footer style="text-align: center; margin-top: 100px">  
      
           Desenvolvido por <a href="https://www.linkedin.com/in/sahev/" target="_blank">Samuel Evangelista</a>
      
      </footer>    
</body>
    
</html> 
