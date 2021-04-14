using DAL.Repositories;
using DTO.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL.BLLs
{
    public class EnderecoBLL
    {
        private readonly EnderecoRepository _enderecoRepository;
        public EnderecoBLL()
        {
            _enderecoRepository = new EnderecoRepository();
        }

        public ClienteEndereco ConsultaCEP(string CEP)
        {
            try
            {
                var consulta = ConsultaViaCep(CEP);
                
                var result = new ClienteEndereco()
                {
                    Bairro = consulta.bairro,
                    CEP = consulta.cep,
                    Cidade = consulta.localidade,
                    Endereco = consulta.logradouro,
                    UF = consulta.uf,
                    Pais = "Brasil"
                };

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        public ClienteEndereco ConsultarEndereco(int id)
        {
            return _enderecoRepository.GetEnderecoByID(id);
        }

        public List<ClienteEndereco> ListaDeEnderecos(int clienteID)
        {
            return _enderecoRepository.GetEnderecosByClienteID(clienteID);
        }

        public ClienteEndereco CriarEndereco(ClienteEndereco endereco)
        {
            var valida = Valida(endereco);
            if (!valida.Key)
                throw new ArgumentException(valida.Value);
            return _enderecoRepository.InsertEndereco(endereco);
        }

        public bool ExcluirEndereco(int id)
        {
            return _enderecoRepository.DeleteEnderecoByID(id) > 0;
        }

        private  ConsultaCEPResponse ConsultaViaCep(string Cep)
        {
            ConsultaCEPResponse consulta;
            string cepTratado = String.Join("", Regex.Split(Cep, @"[^\d]"));
            var request = WebRequest.Create("https://viacep.com.br/ws/" + cepTratado + "/json/unicode/");
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";

            using (var response = request.GetResponse())
            {
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(0));
                string result = streamReader.ReadToEnd();
                consulta = JsonConvert.DeserializeObject<ConsultaCEPResponse>(result);
            }

            return consulta;
        }

        private KeyValuePair<bool, string> Valida(ClienteEndereco endereco)
        {
            string msg = "";
            if (endereco.ClienteID <= 0)
                msg += "Erro ao vincular cliente / \n";
            if (string.IsNullOrEmpty(endereco.Endereco))
                msg += "O Endereco deve ser informado / \n";
            if (string.IsNullOrEmpty(endereco.Numero))
                msg += "O Numero deve ser informado / \n";
            if (string.IsNullOrEmpty(endereco.Bairro))
                msg += "O Bairro deve ser informado / \n";
            if (string.IsNullOrEmpty(endereco.Cidade))
                msg += "O Cidade deve ser informado / \n";
            if (string.IsNullOrEmpty(endereco.UF))
                msg += "O UF deve ser informado / \n";
            if (string.IsNullOrEmpty(endereco.CEP))
                msg += "O CEP deve ser informado / \n";
            if (string.IsNullOrEmpty(endereco.Pais))
                msg += "O Pais deve ser informado / \n";

            if (msg == "")
                return new KeyValuePair<bool, string>(true, msg);
            else
                return new KeyValuePair<bool, string>(false, msg);
        }
    }
}
