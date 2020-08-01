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
            <asp:Button ID="btnUpload" runat="server" Text="Adicionar Arquivo" OnClick="btnUpload_Click" />
        </div>
        <asp:Label ID="lblMessage" runat="server" Font-bold="true"></asp:Label>
    </form>
</body>
</html>
