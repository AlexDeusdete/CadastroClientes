<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="UI.Web.Clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 93px;
        }
        .auto-style3 {
            width: 93px;
            height: 311px;
        }
        .auto-style4 {
            height: 311px;
            width: 724px;
        }
        .auto-style5 {
            width: 93px;
            height: 30px;
        }
        .auto-style6 {
            height: 30px;
            width: 724px;
        }
        .auto-style7 {
            width: 724px;
        }
    </style>
</head>
<body style="height: 469px">
    <form id="cliente" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" dir="ltr">&nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4">
                    <asp:GridView ID="gdClientes" runat="server" Height="295px" Width="723px">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">ID</td>
                <td dir="ltr" class="auto-style6">
                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Localizar" Width="73px" OnClick="Button1_Click" />
                    <asp:Label ID="lblClienteNome" runat="server" Text="..."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td dir="ltr" class="auto-style6">
                    <asp:Button ID="btnIncluir" runat="server" Text="Incluir" Width="73px" OnClick="btnIncluir_Click" />
                    <asp:Button ID="btnAlterar" runat="server" Text="Alterar" Width="73px" OnClick="btnAlterar_Click" />
                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" Width="73px" OnClick="btnExcluir_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style7">
                    <asp:Label ID="lblMsg" runat="server" Text="..."></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
