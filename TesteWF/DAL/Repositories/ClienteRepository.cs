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
    public class ClienteRepository
    {
        public List<Cliente> GetClientes()
        {
            try
            {
                string sql = "SELECT ID, NomeCompleto, CPF_CNPJ, Email, Observacao FROM Cliente";
                var table = ConnectionDB.GetDataTable(sql);

                List<Cliente> result = new List<Cliente>();
                foreach (var row in table.Rows)
                    result.Add(ParseCliente((DataRow)row));

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente GetClienteByID(int ID)
        {
            try
            {
                string sql = "SELECT ID, NomeCompleto, CPF_CNPJ, Email, Observacao FROM Cliente WHERE ID = @ID";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@ID", ID }
                };

                var table = ConnectionDB.GetDataTable(sql, parameters);

                if (table.Rows.Count > 0)
                    return ParseCliente((DataRow)table.Rows[0]);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteClienteByID(int ID)
        {
            try
            {
                string sql = "DELETE FROM Cliente WHERE ID = @ID";
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

        public int UpdateClienteByID(Cliente cliente)
        {
            try
            {
                string sql = "UPDATE Cliente " +
                    "SET NomeCompleto = @NomeCompleto," +
                    "	CPF_CNPJ = @CPF_CNPJ," +
                    "	Email = @Email," +
                    "	Observacao = @Observacao" +
                    " WHERE ID = @ID";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@NomeCompleto", cliente.NomeCompleto },
                    { "@CPF_CNPJ", cliente.CPF_CNPJ },
                    { "@Email", cliente.Email },
                    { "@Observacao", cliente.Observacao },
                    { "@ID", cliente.ID }
                };

                return ConnectionDB.NonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente InsertCliente(Cliente cliente)
        {
            try
            {
                string sql = "INSERT INTO Cliente " +
                    "VALUES(@NomeCompleto, @CPF_CNPJ, @Email, @Observacao)";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@NomeCompleto", cliente.NomeCompleto },
                    { "@CPF_CNPJ", cliente.CPF_CNPJ },
                    { "@Email", cliente.Email },
                    { "@Observacao", cliente.Observacao }
                };

                if (ConnectionDB.NonQuery(sql, parameters) > 0)
                {
                     sql = "SELECT ID, NomeCompleto, CPF_CNPJ, Email, Observacao FROM Cliente " +
                        "WHERE ID = (SELECT MAX(ID) FROM Cliente)";

                        var table = ConnectionDB.GetDataTable(sql);

                        if (table.Rows.Count > 0)
                            return ParseCliente((DataRow)table.Rows[0]);
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

        private Cliente ParseCliente(DataRow cliente)
        {
            try
            {
                Cliente clienteResult = new Cliente();
                clienteResult.ID = Convert.ToInt32(cliente[0]);
                clienteResult.NomeCompleto = Convert.ToString(cliente[1]);
                clienteResult.CPF_CNPJ = Convert.ToString(cliente[2]);
                clienteResult.Email = Convert.ToString(cliente[3]);
                clienteResult.Observacao = Convert.ToString(cliente[4]);

                return clienteResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
