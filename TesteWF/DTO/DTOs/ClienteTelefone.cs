using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class ClienteTelefone
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public int TipoTelefoneID { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
        public string TipoTelefoneNome
        {
            get => TipoTelefone.Descricao;
        }
    }
}
