<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientesAlteracao.aspx.cs" Inherits="UI.Web.ClientesAlteracao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 190px;
        }
        .auto-style3 {
            width: 190px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
            width: 606px;
        }
        .auto-style5 {
            width: 606px;
        }
        .auto-style6 {
            width: 171px;
        }
        .auto-style8 {
            width: 234px;
        }
        .auto-style9 {
            width: 171px;
            height: 23px;
        }
        .auto-style13 {
            height: 23px;
        }
        .auto-style16 {
            height: 23px;
            width: 99px;
        }
        .auto-style17 {
            width: 99px;
        }
        .auto-style20 {
            width: 100px;
            height: 23px;
        }
        .auto-style21 {
            width: 100px;
        }
        .auto-style26 {
            width: 226px;
            height: 23px;
        }
        .auto-style27 {
            width: 226px;
        }
        .auto-style28 {
            height: 23px;
            width: 52px;
        }
        .auto-style29 {
            width: 52px;
        }
        .auto-style31 {
            width: 235px;
        }
        .auto-style32 {
            width: 186px;
            height: 23px;
        }
        .auto-style33 {
            width: 186px;
        }
        .auto-style34 {
            width: 190px;
            height: 30px;
        }
        .auto-style38 {
            width: 115px;
        }
        .auto-style39 {
            height: 23px;
            width: 115px;
        }
        .auto-style40 {
            width: 314px;
        }
        .auto-style41 {
            width: 314px;
            height: 23px;
        }
        .auto-style43 {
            width: 234px;
            height: 20px;
        }
        .auto-style44 {
            width: 171px;
            height: 20px;
        }
        .auto-style45 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Italic="True" Text="Cadastro de Clientes"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        ID</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtID" runat="server" Width="206px" BackColor="#FFFF66" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Nome Completo"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtNomeCompleto" runat="server" Width="589px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">CPF/CNPJ</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtCPFCNPJ" runat="server" Width="206px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="E-mail"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtEmail" runat="server" Width="589px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="Observação"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtObs" runat="server" Width="589px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style34" colspan="2">
                        <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" />
                        <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Voltar" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2">
                        <asp:Label ID="lblMsg" runat="server" Text="..."></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <table id="tblEnderecos" class="auto-style1">
            <tr>
                <td class="auto-style44">
                    ID</td>
                <td class="auto-style43" colspan="2" dir="ltr">
                    <asp:TextBox ID="txtIDEndereco" runat="server" Width="90px"></asp:TextBox>
                    <asp:Button ID="btnLocalizar" runat="server" OnClick="btnLocalizar_Click" style="height: 26px" Text="Localizar" />
                </td>
                <td class="auto-style45">
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label4" runat="server" Text="Endereço"></asp:Label>
                </td>
                <td class="auto-style8" colspan="2">
                    <asp:TextBox ID="txtEndereco" runat="server" Width="377px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnIncluirEndereco" runat="server" Text="Incluir Endereço" OnClick="btnIncluirEndereco_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label5" runat="server" Text="Numero"></asp:Label>
                </td>
                <td class="auto-style40">
                    <asp:TextBox ID="txtNumero" runat="server" Width="206px"></asp:TextBox>
                </td>
                <td class="auto-style38">
                    <asp:Label ID="Label6" runat="server" Text="Bairro"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBairro" runat="server" Width="206px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label7" runat="server" Text="Cidade"></asp:Label>
                </td>
                <td class="auto-style40">
                    <asp:TextBox ID="txtCidade" runat="server" Width="206px"></asp:TextBox>
                </td>
                <td class="auto-style38">
                    <asp:Label ID="Label8" runat="server" Text="UF"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUF" runat="server" Width="206px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label9" runat="server" Text="CEP"></asp:Label>
                </td>
                <td class="auto-style40">
                    <asp:TextBox ID="txtCEP" runat="server" Width="206px"></asp:TextBox>
                    <asp:Button ID="btnConsultaCEP" runat="server" OnClick="btnConsultaCEP_Click" Text="Consulta" />
                </td>
                <td class="auto-style38">
                    <asp:Label ID="Label10" runat="server" Text="Pais"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPais" runat="server" Width="206px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label11" runat="server" Text="Complemento"></asp:Label>
                </td>
                <td class="auto-style40">
                    <asp:TextBox ID="txtComplemento" runat="server" Width="206px"></asp:TextBox>
                </td>
                <td class="auto-style38">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6" dir="ltr">
                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Endereços"></asp:Label>
                </td>
                <td class="auto-style8" colspan="3">
                    <asp:GridView ID="dgEnderecos" runat="server" Width="669px">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style40">
                    <asp:Button ID="btnExcluirEndereco" runat="server" Text="Excluir" OnClick="btnExcluirEndereco_Click" />
                </td>
                <td class="auto-style38">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style41">
                    <asp:Label ID="lblMsgEnderecos" runat="server" Text="..."></asp:Label>
                </td>
                <td class="auto-style39"></td>
                <td class="auto-style13"></td>
            </tr>
        </table>
        <table id="tblTelefones" class="auto-style1">
            <tr>
                <td class="auto-style32">
                    <asp:Label ID="Label18" runat="server" Text="ID"></asp:Label>
                </td>
                <td class="auto-style20">
                    <asp:TextBox ID="txtIDTelefone" runat="server" Width="97px"></asp:TextBox>
                </td>
                <td class="auto-style16">
                    <asp:Button ID="btnLocalizarTelefone" runat="server" OnClick="btnLocalizarTelefone_Click" style="height: 26px" Text="Localizar" />
                </td>
                <td class="auto-style26">
                    &nbsp;</td>
                <td class="auto-style28">&nbsp;</td>
                <td class="auto-style13">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style32">
                    <asp:Label ID="Label14" runat="server" Text="DDD"></asp:Label>
                </td>
                <td class="auto-style20">
                    <asp:TextBox ID="txtDDD" runat="server" Width="72px"></asp:TextBox>
                </td>
                <td class="auto-style16">
                    <asp:Label ID="Label15" runat="server" Text="Telefone"></asp:Label>
                </td>
                <td class="auto-style26">
                    <asp:TextBox ID="txtTelefone" runat="server" Width="162px"></asp:TextBox>
                </td>
                <td class="auto-style28">Tipo</td>
                <td class="auto-style13">
                    <asp:DropDownList ID="ddTipoTelefone" runat="server" Height="16px" Width="137px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style32"></td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style16"></td>
                <td class="auto-style26"></td>
                <td class="auto-style28"></td>
                <td class="auto-style13">
                    <asp:Button ID="btnIncluirTelefone" runat="server" Text="Incluir Telefone" OnClick="btnIncluirTelefone_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style33">
                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Telefones"></asp:Label>
                </td>
                <td class="auto-style31" colspan="5">
                    <asp:GridView ID="dgTelefones" runat="server" Width="669px">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style33">&nbsp;</td>
                <td class="auto-style21">
                    <asp:Button ID="btnExcluirTelefone" runat="server" Text="Excluir" OnClick="btnExcluirTelefone_Click" />
                </td>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style27">&nbsp;</td>
                <td class="auto-style29">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style33">&nbsp;</td>
                <td class="auto-style21" colspan="5">
                    <asp:Label ID="lblMsgTelefones" runat="server" Text="..."></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
