using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BDProjeto.Dominio
{
    public class Usuario
    {
        public Int32 Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public String nome { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "O campo cargo é obrigatório")]
        public String cargo { get; set; }
                
        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "O campo data é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime data { get; set; }
    }
}
