<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Upload.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Lbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server">View Uploaded Image</asp:HyperLink>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
