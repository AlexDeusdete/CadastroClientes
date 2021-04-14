using BLL.BLLs;
using DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Clientes : System.Web.UI.Page
    {
        private ClienteBLL _clienteBLL = new ClienteBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaTela();
        }

        private void AtualizaTela()
        {
            try
            {
                gdClientes.DataSource = _clienteBLL.ListaDeClientes();
                gdClientes.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void LocalizarCliente()
        {
            var clienteSelecionado = _clienteBLL.ConsultarCliente(Convert.ToInt32(txtID.Text));
            if (clienteSelecionado != null)
                lblClienteNome.Text = clienteSelecionado.NomeCompleto;
        }

        private void ExcluirCliente()
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                lblMsg.Text = "";
                var clienteSelecionado = _clienteBLL.ConsultarCliente(Convert.ToInt32(txtID.Text));
                if (_clienteBLL.ExcluirCliente(clienteSelecionado.ID))
                    AtualizaTela();
                else
                    lblMsg.Text = "Erro ao Excluir. Tente Novamente!";
            }
            else
                lblMsg.Text = "Antes de Excluir um cliente utilize o função de localizar";

        }

        private void AlterarCliente()
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                Response.Redirect("~/Web/ClientesAlteracao.aspx?clienteID=" + txtID.Text);
            }
            else
                lblMsg.Text = "Antes de Excluir um cliente utilize o função de localizar";
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Web/ClientesAlteracao.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LocalizarCliente();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirCliente();
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            AlterarCliente();
        }
    }
}