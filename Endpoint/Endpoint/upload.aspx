<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="Endpoint.upload.upload" %>

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

    <div style="width: 245px; margin-left: auto; margin-right: auto;">
        <asp:Label ID="lblMessage" runat="server" Font-Bold="true" TextMode="MultiLine" Wrap="true"></asp:Label>
    </div>    
            <div style="width:245px; margin-left:auto;margin-right:auto;">
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" Font-Names="Helvetica" Width="242px"/>
            <br />
            <br />

            <asp:Button ID="btnUpload" runat="server" Text="Processar" OnClick="btnUpload_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Info" OnClick="Button2_Click1" />
                </div>
        
        <br />
        <br />
            <div style="width:670px;margin-left:auto;margin-right:auto;">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-condensed" AllowPaging="True" PageSize="2"  OnPageIndexChanging="GridView1_PageIndexChanging" >
                </asp:GridView>
            </div>
      
       
            <div style="width:670px; margin-left:auto;margin-right:auto;" aria-grabbed="undefined" aria-orientation="horizontal" aria-sort="none">
            <asp:Label ID="Label1" runat="server" Font-bold="true" TextMode="MultiLine" font-names="Helvetica" Wrap="true" >Script:
            </asp:Label>
        
            <asp:TextBox ID="TextBox1" runat="server" Height="163px" font-names="Helvetica" style="margin-top: 0px" Width="654px"
                TextMode="MultiLine" Wrap="true" ></asp:TextBox>
                <br /><br />

                <asp:Label ID="Label3" runat="server" Font-bold="True" TextMode="MultiLine" font-names="Helvetica" Wrap="true" >Exemplo de uso: </asp:Label> 
                <asp:Label ID="Label2" runat="server" Font-bold="True" TextMode="MultiLine" font-names="Helvetica" Wrap="true" Font-Size="8pt" >
{0} = Número;            
{1} = Nome;
{2} = Variável1; 
{3} = Variável2;
{4} = Variável3; 
{5} = Variável4; 
{6} = Variável5;</asp:Label> 
                        
                <asp:TextBox ID="TextBox2" runat="server" Height="182px" Font-Names="Helvetica" Style="float:left; margin-top: auto" Width="654px" disabled
                    TextMode="MultiLine" Wrap="False" ValidateRequestMode="Disabled" >Bom dia {1}!                                      
Tudo bem?                                                                         
                                                          
Obrigado pela compra! Segue o número de pedido: *{2}*

Estamos enviando também para o seu e-mail, poderia me confirmar se é o *{3}*?

                </asp:TextBox>
        

                <br /><br />
             <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Enviar" OnClick="Button1_Click"  />
                
               
                
                </div>
        
        <div style="width:63px; margin-left:auto;margin-right:auto; height: 27px;">
        <p>
             &nbsp;</p>
        </div>
     </form>
        
</body>
    
</html> 
