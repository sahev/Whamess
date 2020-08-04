<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="Endpoint.upload.upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <asp:Label ID="lblMessage" runat="server" Font-bold="true" TextMode="MultiLine" Wrap="true"></asp:Label>
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
            <asp:Button ID="btnUpload" runat="server" Text="Processar" OnClick="btnUpload_Click" />
        <br />
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Height="160px" style="margin-top: 0px" Width="358px"
                Font-Bold="true" TextMode="MultiLine" Wrap="true" ></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enviar" />
        </p>
    </form>
</body>

</html>

