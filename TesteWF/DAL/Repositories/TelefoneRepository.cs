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
    public class TelefoneRepository
    {
        private readonly List<TipoTelefone> _tipoTelefones;
        public TelefoneRepository()
        {
            _tipoTelefones = GetTipoTelefones();
        }
        public List<ClienteTelefone> GetTelefonesByClienteID(int clienteID)
        {
            try
            {
                string sql = "select ID, ClienteID, DDD, Telefone, TipoTelefoneID from ClienteTelefone " +
                    "WHERE ClienteID = @ClienteID";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@ClienteID", clienteID }
                };

                var table = ConnectionDB.GetDataTable(sql, parameters);

                List<ClienteTelefone> result = new List<ClienteTelefone>();
                foreach (var row in table.Rows)
                {
                    var tel = ParseTelefone((DataRow)row);
                    tel.TipoTelefone = _tipoTelefones.FirstOrDefault(x => x.ID == tel.TipoTelefoneID);
                    result.Add(tel);
                }
                    
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoTelefone> GetTipoTelefones()
        {
            try
            {
                string sql = "select ID, Descricao from TipoTelefone";
                var table = ConnectionDB.GetDataTable(sql);

                List<TipoTelefone> result = new List<TipoTelefone>();
                foreach (var row in table.Rows)
                    result.Add(ParseTipoTelefone((DataRow)row));

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteTelefone GetTelefoneByID(int ID)
        {
            try
            {
                string sql = "select ID, ClienteID, DDD, Telefone, TipoTelefoneID from ClienteTelefone WHERE ID = @ID";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@ID", ID }
                };

                var table = ConnectionDB.GetDataTable(sql, parameters);

                if (table.Rows.Count > 0)
                {
                    var tel = ParseTelefone((DataRow)table.Rows[0]);
                    tel.TipoTelefone = _tipoTelefones.FirstOrDefault(x => x.ID == tel.TipoTelefoneID);
                    return tel;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteTelefoneByID(int ID)
        {
            try
            {
                string sql = "DELETE FROM ClienteTelefone WHERE ID = @ID";
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

        public int DeleteTelefoneByClienteID(int clienteID)
        {
            try
            {
                string sql = "DELETE FROM ClienteTelefone WHERE ClienteID = @ClienteID";
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

        public int UpdateTelefoneByID(ClienteTelefone telefone)
        {
            try
            {
                string sql = "UPDATE ClienteTelefone " +
                    "SET DDD = @DDD," +
                    "	Telefone = @Telefone," +
                    "	TipoTelefoneID = @TipoTelefoneID" +
                    " WHERE ID = @ID";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@DDD", telefone.DDD },
                    { "@Telefone", telefone.Telefone },
                    { "@TipoTelefoneID", telefone.TipoTelefoneID },
                    { "@ID", telefone.ID }
                };

                return ConnectionDB.NonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteTelefone InsertTelefone(ClienteTelefone telefone)
        {
            try
            {
                string sql = "INSERT INTO ClienteTelefone " +
                    "VALUES(@ClienteID, @DDD, @Telefone, @TipoTelefoneID)";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@ClienteID", telefone.ClienteID },
                    { "@DDD", telefone.DDD },
                    { "@Telefone", telefone.Telefone },
                    { "@TipoTelefoneID", telefone.TipoTelefoneID }
                };

                if (ConnectionDB.NonQuery(sql, parameters) > 0)
                {
                    sql = "SELECT ID, ClienteID, DDD, Telefone, TipoTelefoneID FROM ClienteTelefone " +
                       "WHERE ID = (SELECT MAX(ID) FROM ClienteTelefone)";

                    var table = ConnectionDB.GetDataTable(sql);

                    if (table.Rows.Count > 0)
                    {
                        var tel = ParseTelefone((DataRow)table.Rows[0]);
                        tel.TipoTelefone = _tipoTelefones.FirstOrDefault(x => x.ID == tel.TipoTelefoneID);
                        return tel;
                    }                        
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

        private ClienteTelefone ParseTelefone(DataRow telefone)
        {
            try
            {
                ClienteTelefone clienteTelefone = new ClienteTelefone();
                clienteTelefone.ID = Convert.ToInt32(telefone[0]);
                clienteTelefone.ClienteID = Convert.ToInt32(telefone[1]);
                clienteTelefone.DDD = Convert.ToString(telefone[2]);
                clienteTelefone.Telefone = Convert.ToString(telefone[3]);
                clienteTelefone.TipoTelefoneID = Convert.ToInt32(telefone[4]);

                return clienteTelefone;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private TipoTelefone ParseTipoTelefone(DataRow tipoTelefone)
        {
            try
            {
                TipoTelefone tipoTelefoneResult = new TipoTelefone();
                tipoTelefoneResult.ID = Convert.ToInt32(tipoTelefone[0]);
                tipoTelefoneResult.Descricao = Convert.ToString(tipoTelefone[1]);

                return tipoTelefoneResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
