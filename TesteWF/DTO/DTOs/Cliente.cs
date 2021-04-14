using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class Cliente
    {
        public int ID { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
    }
}
