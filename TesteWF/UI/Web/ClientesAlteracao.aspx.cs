using BLL.BLLs;
using DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ClientesAlteracao : System.Web.UI.Page
    {
        private ClienteBLL _clienteBLL = new ClienteBLL();
        private EnderecoBLL _enderecoBLL = new EnderecoBLL();
        private TelefoneBLL _telefoneBLL = new TelefoneBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            var clienteID = Request.QueryString["clienteID"];
            if (!string.IsNullOrEmpty(clienteID))
                CarregaDados(clienteID);
            BloquearEndereco(string.IsNullOrEmpty(txtID.Text));
            BloquearTelefone(string.IsNullOrEmpty(txtID.Text));
            txtPais.Text = "Brasil";
            lblMsg.Text = "Salvar para continuar o cadastro!";

            var tiposTelefones = _telefoneBLL.ListaDeTipoTelefones();
            ddTipoTelefone.DataSource = tiposTelefones.Select(x => x.Descricao);
            ddTipoTelefone.DataBind();
        }

        private void CarregaDados(string clienteID)
        {
            txtID.Text = clienteID;
            Cliente cliente = null;
            if (int.TryParse(clienteID, out int clienteid))
            {
                cliente = _clienteBLL.ConsultarCliente(clienteid);
                AtualizarCliente(cliente);

                dgEnderecos.DataSource = _enderecoBLL.ListaDeEnderecos(clienteid);
                dgEnderecos.DataBind();

                dgTelefones.DataSource = _telefoneBLL.ListaDeTelefones(clienteid);
                dgTelefones.DataBind();
            }
        }

        private void AtualizaEndereco(ClienteEndereco endereco)
        {
            txtEndereco.Text = endereco?.Endereco;
            txtNumero.Text = endereco?.Numero;
            txtCidade.Text = endereco?.Cidade;
            txtCEP.Text = endereco?.CEP;
            txtComplemento.Text = endereco?.Complemento;
            txtBairro.Text = endereco?.Bairro;
            txtUF.Text = endereco?.UF;
            txtPais.Text = endereco?.Pais;
            dgEnderecos.DataSource = _enderecoBLL.ListaDeEnderecos(endereco.ClienteID);
            dgEnderecos.DataBind();
        }

        private void AtualizaTelefone(ClienteTelefone telefone)
        {
            txtDDD.Text = telefone?.DDD;
            txtTelefone.Text = telefone?.Telefone;
            ddTipoTelefone.SelectedValue = telefone?.TipoTelefone?.Descricao;
            dgTelefones.DataSource = _telefoneBLL.ListaDeTelefones(telefone.ClienteID);
            dgTelefones.DataBind();
        }

        private void AtualizarCliente(Cliente cliente)
        {
            txtID.Text = cliente.ID.ToString();
            txtNomeCompleto.Text = cliente?.NomeCompleto;
            txtCPFCNPJ.Text = cliente?.CPF_CNPJ;
            txtEmail.Text = cliente?.Email;
            txtObs.Text = cliente?.Observacao;
        }

        private void BloquearEndereco(bool value)
        {
            txtEndereco.Enabled = !value;
            txtNumero.Enabled = !value;
            txtCidade.Enabled = !value;
            txtCEP.Enabled = !value;
            txtComplemento.Enabled = !value;
            txtBairro.Enabled = !value;
            txtUF.Enabled = !value;
            txtPais.Enabled = !value;
            btnIncluirEndereco.Enabled = !value;
            btnExcluirEndereco.Enabled = !value;
            btnLocalizar.Enabled = !value;
            btnConsultaCEP.Enabled = !value;
            txtIDEndereco.Enabled = !value;
        }

        private void BloquearTelefone(bool value)
        {
            txtDDD.Enabled = !value;
            txtTelefone.Enabled = !value;
            ddTipoTelefone.Enabled = !value;
            btnIncluirTelefone.Enabled = !value;
            btnExcluirTelefone.Enabled = !value;
            btnLocalizarTelefone.Enabled = !value;
            txtIDTelefone.Enabled = !value;
        }

        private void LocalizarEndereco()
        {
            var endereco = _enderecoBLL.ConsultarEndereco(Convert.ToInt32(txtIDEndereco.Text));
            if (endereco != null)
                AtualizaEndereco(endereco);
        }

        private void IncluirEndereco()
        {
            try
            {
                var endereco = new ClienteEndereco()
                {
                    ClienteID = Convert.ToInt32(txtID.Text),
                    Endereco = txtEndereco.Text,
                    Numero = txtNumero.Text,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                    UF = txtUF.Text,
                    CEP = txtCEP.Text,
                    Pais = txtPais.Text,
                    Complemento = txtComplemento.Text
                };

                endereco = _enderecoBLL.CriarEndereco(endereco);
                if (endereco != null)
                {
                    AtualizaEndereco(endereco);
                    lblMsgEnderecos.Text = "Informações Salvas!";
                }
            }
            catch (Exception ex)
            {
                lblMsgEnderecos.Text = ex.Message;
            }
        }

        private void ExcluirEndereco()
        {
            if (!string.IsNullOrEmpty(txtIDEndereco.Text))
            {
                lblMsgEnderecos.Text = "";
                var endereco = _enderecoBLL.ConsultarEndereco(Convert.ToInt32(txtIDEndereco.Text));
                if (_enderecoBLL.ExcluirEndereco(endereco.ID))
                    AtualizaEndereco(new ClienteEndereco() { ClienteID = endereco.ClienteID });
                else
                    lblMsgEnderecos.Text = "Erro ao Excluir. Tente Novamente!";
            }
            else
                lblMsgEnderecos.Text = "Antes de Excluir um Endereço utilize o função de localizar";

        }

        private void LocalizarTelefone()
        {
            var telefone = _telefoneBLL.ConsultarTelefone(Convert.ToInt32(txtIDTelefone.Text));
            if (telefone != null)
                AtualizaTelefone(telefone);
        }

        private void IncluirTelefone()
        {
            try
            {
                var telefone = new ClienteTelefone()
                {
                    ClienteID = Convert.ToInt32(txtID.Text),
                    DDD = txtDDD.Text,
                    Telefone = txtTelefone.Text,
                    TipoTelefoneID = ddTipoTelefone.SelectedIndex + 1
                };

                telefone = _telefoneBLL.CriarTelefone(telefone);
                if (telefone != null)
                {
                    AtualizaTelefone(telefone);
                    lblMsgTelefones.Text = "Informações Salvas!";
                }
            }
            catch (Exception ex)
            {
                lblMsgTelefones.Text = ex.Message;
            }
        }

        private void ExcluirTelefone()
        {
            if (!string.IsNullOrEmpty(txtIDTelefone.Text))
            {
                lblMsgTelefones.Text = "";
                var telefone = _telefoneBLL.ConsultarTelefone(Convert.ToInt32(txtIDTelefone.Text));
                if (_telefoneBLL.ExcluirTelefone(telefone.ID))
                    AtualizaTelefone(new ClienteTelefone() { ClienteID = telefone.ClienteID });
                else
                    lblMsgTelefones.Text = "Erro ao Excluir. Tente Novamente!";
            }
            else
                lblMsgTelefones.Text = "Antes de Excluir um Telefone utilize o função de localizar";
        }

        private void ConsultaCEP()
        {
            try
            {
                var endereco = _enderecoBLL.ConsultaCEP(txtCEP.Text);
                endereco.ClienteID = Convert.ToInt32(txtID.Text);
                AtualizaEndereco(endereco);
            }
            catch (Exception ex)
            {
                lblMsgEnderecos.Text = ex.Message;
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Web/Clientes.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = new Cliente()
                {
                    CPF_CNPJ = txtCPFCNPJ.Text,
                    Email = txtEmail.Text,
                    NomeCompleto = txtNomeCompleto.Text,
                    Observacao = txtObs.Text
                };


                int clienteID;
                if (int.TryParse(txtID.Text, out clienteID))
                {
                    cliente.ID = clienteID;
                    cliente = _clienteBLL.AtualizarCliente(cliente);
                }
                else
                    cliente = _clienteBLL.CriarCliente(cliente);
                if (cliente != null)
                {
                    AtualizarCliente(cliente);
                    BloquearEndereco(false);
                    BloquearTelefone(false);
                    lblMsg.Text = "Informações Salvas!";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }

        }

        protected void btnLocalizar_Click(object sender, EventArgs e)
        {
            LocalizarEndereco();
        }

        protected void btnIncluirEndereco_Click(object sender, EventArgs e)
        {
            IncluirEndereco();
        }

        protected void btnExcluirEndereco_Click(object sender, EventArgs e)
        {
            ExcluirEndereco();
        }

        protected void btnLocalizarTelefone_Click(object sender, EventArgs e)
        {
            LocalizarTelefone();
        }

        protected void btnIncluirTelefone_Click(object sender, EventArgs e)
        {
            IncluirTelefone();
        }

        protected void btnExcluirTelefone_Click(object sender, EventArgs e)
        {
            ExcluirTelefone();
        }

        protected void btnConsultaCEP_Click(object sender, EventArgs e)
        {
            ConsultaCEP();
        }
    }
}