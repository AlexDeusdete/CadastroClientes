using DAL.Connection;
using DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EnderecoRepository
    {
        public List<ClienteEndereco> GetEnderecosByClienteID(int clienteID)
        {
            try
            {
                string sql = "SELECT ID, ClienteID, Endereco, Numero, Bairro, Cidade, UF, CEP, Pais, Complemento FROM ClienteEndereco " +
                    "WHERE ClienteID = @ClienteID";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@ClienteID", clienteID }
                };

                var table = ConnectionDB.GetDataTable(sql, parameters);

                List<ClienteEndereco> result = new List<ClienteEndereco>();
                foreach (var row in table.Rows)
                {
                    result.Add(ParseEndereco((DataRow)row));
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteEndereco GetEnderecoByID(int ID)
        {
            try
            {
                string sql = "SELECT ID, ClienteID, Endereco, Numero, Bairro, Cidade, UF, CEP, Pais, Complemento FROM ClienteEndereco WHERE ID = @ID";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@ID", ID }
                };

                var table = ConnectionDB.GetDataTable(sql, parameters);

                if (table.Rows.Count > 0)                
                    return ParseEndereco((DataRow)table.Rows[0]); 
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteEnderecoByID(int ID)
        {
            try
            {
                string sql = "DELETE FROM ClienteEndereco WHERE ID = @ID";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@ID", ID }
                };

                return ConnectionDB.NonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteEnderecoByClienteID(int clienteID)
        {
            try
            {
                string sql = "DELETE FROM ClienteEndereco WHERE ClienteID = @ClienteID";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@ClienteID", clienteID }
                };

                return ConnectionDB.NonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateEnderecoByID(ClienteEndereco endereco)
        {
            try
            {
                string sql = "UPDATE ClienteEndereco " +
                    "SET Endereco = @Endereco," +
                    "	 Numero = @Numero," +
                    "	 Bairro = @Bairro" +
                    "	 Cidade = @Cidade" +
                    "	 UF = @UF" +
                    "	 CEP = @CEP" +
                    "	 Pais = @Pais" +
                    "	 Complemento = @Complemento" +
                    " WHERE ID = @ID";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@Endereco", endereco.Endereco },
                    { "@Numero", endereco.Numero },
                    { "@Bairro", endereco.Bairro },
                    { "@Cidade", endereco.Cidade },
                    { "@UF", endereco.UF },
                    { "@CEP", endereco.CEP },
                    { "@Pais", endereco.Pais },
                    { "@Complemento", endereco.Complemento }
                };

                return ConnectionDB.NonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteEndereco InsertEndereco(ClienteEndereco endereco)
        {
            try
            {
                string sql = "INSERT INTO ClienteEndereco " +
                    "VALUES(@ClienteID, @Endereco, @Numero, @Bairro, @Cidade, @UF, @CEP, @Pais, @Complemento)";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@ClienteID", endereco.ClienteID },
                    { "@Endereco", endereco.Endereco },
                    { "@Numero", endereco.Numero },
                    { "@Bairro", endereco.Bairro },
                    { "@Cidade", endereco.Cidade },
                    { "@UF", endereco.UF },
                    { "@CEP", endereco.CEP },
                    { "@Pais", endereco.Pais },
                    { "@Complemento", endereco.Complemento }
                };

                if (ConnectionDB.NonQuery(sql, parameters) > 0)
                {
                    sql = "SELECT ID, ClienteID, Endereco, Numero, Bairro, Cidade, UF, CEP, Pais, Complemento FROM ClienteEndereco " +
                       "WHERE ID = (SELECT MAX(ID) FROM ClienteEndereco)";

                    var table = ConnectionDB.GetDataTable(sql);

                    if (table.Rows.Count > 0)                    
                        return ParseEndereco((DataRow)table.Rows[0]);                    
                    else
                        return null;
                }
                else
                    throw new Exception("Erro Tente novamente!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ClienteEndereco ParseEndereco(DataRow endereco)
        {
            try
            {
                ClienteEndereco clienteEndereco = new ClienteEndereco();
                clienteEndereco.ID = Convert.ToInt32(endereco[0]);
                clienteEndereco.ClienteID = Convert.ToInt32(endereco[1]);
                clienteEndereco.Endereco = Convert.ToString(endereco[2]);
                clienteEndereco.Numero = Convert.ToString(endereco[3]);
                clienteEndereco.Bairro = Convert.ToString(endereco[4]);
                clienteEndereco.Cidade = Convert.ToString(endereco[5]);
                clienteEndereco.UF = Convert.ToString(endereco[6]);
                clienteEndereco.CEP = Convert.ToString(endereco[7]);
                clienteEndereco.Pais = Convert.ToString(endereco[8]);
                clienteEndereco.Complemento = Convert.ToString(endereco[9]);

                return clienteEndereco;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
