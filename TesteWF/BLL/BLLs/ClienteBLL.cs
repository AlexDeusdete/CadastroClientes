using DAL.Repositories;
using DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.BLLs
{
    public class ClienteBLL
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly EnderecoRepository _enderecoRepository;
        private readonly TelefoneRepository _telefoneRepository;

        public ClienteBLL()
        {
            _clienteRepository = new ClienteRepository();
            _enderecoRepository = new EnderecoRepository();
            _telefoneRepository = new TelefoneRepository();
        }
        public Cliente ConsultarCliente(int id)
        {
            return _clienteRepository.GetClienteByID(id);
        }

        public List<Cliente> ListaDeClientes()
        {
            return _clienteRepository.GetClientes();
        }

        public Cliente CriarCliente(Cliente cliente)
        {
            cliente.CPF_CNPJ = String.Join("", Regex.Split(cliente.CPF_CNPJ, @"[^\d]"));

            var valida = Valida(cliente);
            if (!valida.Key)
                throw new ArgumentException(valida.Value);

            return _clienteRepository.InsertCliente(cliente);
        }

        public bool ExcluirCliente(int id)
        {
            _enderecoRepository.DeleteEnderecoByClienteID(id);
            _telefoneRepository.DeleteTelefoneByClienteID(id);
            return _clienteRepository.DeleteClienteByID(id) > 0;
        }

        public Cliente AtualizarCliente(Cliente cliente)
        {
            cliente.CPF_CNPJ = String.Join("", Regex.Split(cliente.CPF_CNPJ, @"[^\d]"));

            var valida = Valida(cliente);
            if (!valida.Key)
                throw new ArgumentException(valida.Value);

            _clienteRepository.UpdateClienteByID(cliente);
            return ConsultarCliente(cliente.ID);
        }

        private KeyValuePair<bool, string> Valida(Cliente cliente)
        {
            string msg = "";
            if (string.IsNullOrEmpty(cliente.NomeCompleto))
                msg += "O Nome do Cliente deve ser informado / \n";
            if (string.IsNullOrEmpty(cliente.CPF_CNPJ))
                msg += "O CPF/CNPJ do Cliente deve ser informado / \n";
            if (string.IsNullOrEmpty(cliente.Email))
                msg += "O E-Mail do Cliente deve ser informado / \n";
            if(!Regex.IsMatch(cliente.CPF_CNPJ, @"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})"))
                msg += "O CPF/CNPJ do Cliente é invalido / \n";
            if (!Regex.IsMatch(cliente.Email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"))
                msg += "O E-Mail do Cliente é invalido / \n";

            if (msg == "")
                return new KeyValuePair<bool, string>(true, msg);
            else
                return new KeyValuePair<bool, string>(false, msg);
        }
    }
}
