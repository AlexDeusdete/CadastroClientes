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
    public class TelefoneBLL
    {
        private readonly TelefoneRepository _telefoneRepository;

        public TelefoneBLL()
        {
            _telefoneRepository = new TelefoneRepository();
        }

        public ClienteTelefone ConsultarTelefone(int id)
        {
            return _telefoneRepository.GetTelefoneByID(id);
        }

        public List<ClienteTelefone> ListaDeTelefones(int clienteID)
        {
            return _telefoneRepository.GetTelefonesByClienteID(clienteID);
        }

        public List<TipoTelefone> ListaDeTipoTelefones()
        {
            return _telefoneRepository.GetTipoTelefones();
        }

        public ClienteTelefone CriarTelefone(ClienteTelefone telefone)
        {
            telefone.Telefone = String.Join("", Regex.Split(telefone.Telefone, @"[^\d]"));
            telefone.DDD = String.Join("", Regex.Split(telefone.DDD, @"[^\d]"));

            var valida = Valida(telefone);
            if (!valida.Key)
                throw new ArgumentException(valida.Value);

            return _telefoneRepository.InsertTelefone(telefone);
        }

        public bool ExcluirTelefone(int id)
        {
            return _telefoneRepository.DeleteTelefoneByID(id) > 0;
        }

        private KeyValuePair<bool, string> Valida(ClienteTelefone telefone)
        {
            string msg = "";
            if (telefone.ClienteID <= 0)
                msg += "Erro ao vincular cliente / \n";
            if (string.IsNullOrEmpty(telefone.DDD))
                msg += "O DDD deve ser informado / \n";
            if (string.IsNullOrEmpty(telefone.Telefone))
                msg += "O Telefone deve ser informado / \n";
            if (telefone.TipoTelefoneID <= 0)
                msg += "O Tipo de Telefone deve ser informado / \n";

            if((telefone.TipoTelefoneID == 1 && telefone.Telefone.Length != 9) ||
                (telefone.TipoTelefoneID == 2 && telefone.Telefone.Length != 8))
                msg += "A quantidade de digitos do telefone não é compativel com o tipo / \n";

            if (msg == "")
                return new KeyValuePair<bool, string>(true, msg);
            else
                return new KeyValuePair<bool, string>(false, msg);
        }
    }
}
