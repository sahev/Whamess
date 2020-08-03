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
        <asp:Label ID="lblMessage0" runat="server" Font-bold="true"></asp:Label>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Height="160px" style="margin-top: 0px" Width="358px"
                Font-Bold="true" TextMode="MultiLine" Wrap="true" ></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnUpload" runat="server" Text="Processar" OnClick="btnUpload_Click" />
        </p>
    </form>
</body>

</html>

<style>
    .auto-style130 {
    /*drug section of script*/
    border: .1px solid #808080;
    white-space: pre-wrap;
    height: 35px;
    width: 402px;
    vertical-align: middle;
}
    </style>